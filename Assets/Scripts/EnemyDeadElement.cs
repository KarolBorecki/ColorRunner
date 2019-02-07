using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadElement : MonoBehaviour {

	public float force;

	void Start () {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force * Random.Range(0.8f,1));

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * force * Random.Range(0.8f, 1));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball") Destroy(gameObject);
    }

}
