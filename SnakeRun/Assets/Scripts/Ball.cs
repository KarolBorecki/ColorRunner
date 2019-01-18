using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        transform.position = new Vector3(mouse.x, mouse.y, transform.position.y);

    }
}
