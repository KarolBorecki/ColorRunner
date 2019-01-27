using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int actuallColor = 0;

	void Start () {
        GetComponent<SpriteRenderer>().color = FindObjectOfType<ColorsHandler>().colors[actuallColor];

    }
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if(collision.gameObject.GetComponent<BallColors>().actuallColor != actuallColor)
                collision.gameObject.GetComponent<Ball>().GetDamage(1);
        }
    }
}
