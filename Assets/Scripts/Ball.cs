using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int lives = 1;

    public float jumpForce = 5f;

    private Rigidbody2D rgb;

    public float shootForce = 1200f;
    public Rigidbody2D shoot;
    public Transform shootTransform;

    void Start () {
        rgb = GetComponent<Rigidbody2D>();
	}
	
    void Update () {
        if(Input.GetButtonDown("Fire1")){
            rgb.velocity = Vector2.up * jumpForce;
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody2D shootball = Instantiate(shoot, shootTransform.position, transform.rotation) as Rigidbody2D;
        shootball.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        shootball.AddForce(Vector2.right * shootForce);
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
