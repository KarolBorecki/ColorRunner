using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "barrier" && FindObjectOfType<BallColors>().actuallColor != collision.gameObject.GetComponent<Barrier>().actuallColor)
        {
            collision.gameObject.GetComponent<Barrier>().ChangeColor();
        }
    }
}
