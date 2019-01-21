using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int lives = 1;

    public float shootDelay = .1f;
    private float actuallTime = 0f;

    public float shootForce = 1000f;
    public Rigidbody2D shoot;
    public Transform shootTransform;

    void Start () {
		
	}
	
	void Update () {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        transform.position = new Vector3(mouse.x, mouse.y, transform.position.y);

        if (Input.GetButton("Fire1")) Shoot();
    }

    void Shoot()
    {
        actuallTime += Time.deltaTime;
        if (actuallTime >= shootDelay)
        {
            Rigidbody2D shootball = Instantiate(shoot, shootTransform.position, transform.rotation) as Rigidbody2D;
            shootball.AddForce(Vector2.right * shootForce);
            actuallTime = 0f;
        }
    }

    public void GetDamage(int amount){
        lives -= amount;
        if (lives <= 0) Dead();
    }

    void Dead(){
        Destroy(gameObject);
    }
}
