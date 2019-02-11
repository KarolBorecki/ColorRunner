using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    public float range = 10;

    public int lifes = 2;

    public Transform DeadPrefab;

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
        changeDirection();
        if (collision.gameObject.tag == "shoot")
        {
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.7f, 0.95f), Random.Range(0.7f, 0.95f), Random.Range(0.7f, 0.95f));
            lifes--;
        }

        if (lifes <= 0) Die();
           
    }

    void Die(){
        Transform deadPrefab = Instantiate(DeadPrefab, transform.position, transform.rotation);
        Destroy(deadPrefab.gameObject, 5);
        Destroy(gameObject);
    }

}
