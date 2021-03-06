﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColors : MonoBehaviour {

    public int actuallColor = 0;

	void Start () {
        ChangeColor();
    }
	
	void Update () {
		
	}

    void ChangeColor(){
        actuallColor = FindObjectOfType<ColorsHandler>().GetRandomColor(actuallColor);
        SetColor();
    }

    void SetColor(){
        GetComponent<SpriteRenderer>().color = FindObjectOfType<ColorsHandler>().colors[actuallColor];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "colorchange")
        {
            ChangeColor();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "life")
        {
            GetComponent<Ball>().AddLife(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "barrier"){
            if(collision.gameObject.GetComponent<Barrier>().actuallColor != actuallColor){
                GetComponent<Ball>().GetDamage(1);
            }
        }
    }
}
