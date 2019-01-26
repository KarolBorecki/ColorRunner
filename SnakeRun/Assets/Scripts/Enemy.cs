using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    public float range = 10;

    private float actuallrange;
    private int dir = -1;

    void Start(){
        actuallrange = range * dir / 2;
    }

    void Update()
    {
        if (Mathf.RoundToInt(System.Math.Abs(actuallrange)) < range){
            gameObject.transform.Translate(Vector2.up * speed * dir * Time.deltaTime);
            actuallrange += speed * dir * Time.deltaTime;
        }
        else changeDirection();
    }

    void changeDirection()
    {
        actuallrange = Mathf.RoundToInt(range - System.Math.Abs(actuallrange));
        dir *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("AF");
        changeDirection();
        if (collision.gameObject.tag == "shoot") Destroy(gameObject);
           
    }

}
