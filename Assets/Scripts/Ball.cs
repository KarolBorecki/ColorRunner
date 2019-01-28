using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int lives = 1;

    public float jumpForce = 5f;

    private Rigidbody2D rgb;

    public float shootForce = 1200f;
    public Rigidbody2D shoot;

    public Transform barrel; 
    public Transform barrel2;

    void Start () {
        rgb = GetComponent<Rigidbody2D>();
	}
	
    void Update () {
        if(Input.GetButtonDown("Fire1")){
            float f = (GetComponent<BallColors>().actuallColor == 2) ? 1.7f : 1f;
            rgb.velocity = Vector2.up * jumpForce * f;
            Shoot();
        }
    }

    void Shoot()
    {
        int c = GetComponent<BallColors>().actuallColor;
        float f = (c == 0) ? 1.4f : 1f;
        Rigidbody2D shootball = Instantiate(shoot, barrel.position, transform.rotation) as Rigidbody2D;

        if (c == 3) shootball.transform.localScale += new Vector3(0.01F, 0.01f, 0);
        shootball.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        shootball.AddForce(Vector2.right * shootForce * f);
        if (c == 1){
            Rigidbody2D shootball2 = Instantiate(shoot, barrel2.position, transform.rotation) as Rigidbody2D;
            shootball2.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            shootball2.AddForce(Vector2.right * shootForce * f);
        }


    }

    public void GetDamage(int amount){
        lives -= amount;
        if (lives <= 0) Dead();
    }

    void Dead(){
        Time.timeScale = 0f;
        lives = 1;
        FindObjectOfType<TestPlayBtn>().Again();
    }
}
