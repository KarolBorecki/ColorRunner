using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArena : MonoBehaviour {

    public int damage = 1;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball") collision.gameObject.GetComponent<Ball>().GetDamage(damage);
    }
}
