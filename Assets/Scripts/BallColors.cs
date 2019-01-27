using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColors : MonoBehaviour {

    public int actuallColor = 0;

	void Start () {
        SetColor();
    }
	
	void Update () {
		
	}

    void ChangeColor(){
        actuallColor = Random.Range(0, 3);
        SetColor();
        Debug.Log("FA");
    }

    void SetColor(){
        GetComponent<SpriteRenderer>().color = FindObjectOfType<ColorsHandler>().colors[actuallColor];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "colorchange"){
            ChangeColor();
        }
    }
}
