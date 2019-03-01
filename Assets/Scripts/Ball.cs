using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public int lifes = 1;
    public float safeTime = 0.5f;
    private float actuallSafeTime;

    public float jumpForce = 5f;

    private Rigidbody2D rgb;

    public float shootForce = 1200f;
    public Rigidbody2D shoot;

    public Transform barrel; 
    public Transform barrel2;

    public Text lifesText;

    public TestPlayBtn deadBtn;

    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        lifesText.text = lifes.ToString();
        actuallSafeTime = safeTime;
	}
	
    void Update () {
        if (actuallSafeTime > 0) actuallSafeTime -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1")){
            float f = (GetComponent<BallColors>().actuallColor == 2) ? 1.7f : 1f;
            rgb.velocity = Vector2.up * jumpForce * f;
            if(Time.timeScale > 0f) Shoot();
        }
    }

    void Shoot()
    {
        int c = GetComponent<BallColors>().actuallColor;
        float f = (c == 0) ? 1.4f : 1f;
        f = (c == 1) ? 0.85f : f;
        Rigidbody2D shootball = Instantiate(shoot, barrel.position, transform.rotation) as Rigidbody2D;

        if (c == 3) shootball.transform.localScale += new Vector3(0.006F, 0.006f, 0);
        shootball.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        shootball.AddForce(Vector2.right * shootForce * f);
        if (c == 1){
            Rigidbody2D shootball2 = Instantiate(shoot, barrel2.position, transform.rotation) as Rigidbody2D;
            shootball2.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            shootball2.AddForce(Vector2.right * shootForce * f);
        }


    }

    public void GetDamage(int amount){
        if (actuallSafeTime <= 0)
        {
            Camera.main.GetComponent<Animator>().SetTrigger("shake");
            lifes -= amount;
            lifesText.text = lifes.ToString();
            if (lifes <= 0) Dead();

            actuallSafeTime = safeTime;
        } 
    }

    public void AddLife(int amount){
        lifes += amount;
        lifesText.text = lifes.ToString();
    }

    void Dead(){
        deadBtn.gameObject.SetActive(true);
        Time.timeScale = 0f;

        int points = FindObjectOfType<PointsCounter>().points;
        if (points > PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", points);
            PlayerPrefs.Save();
        }
    }
}
