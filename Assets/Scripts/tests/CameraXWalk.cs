using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXWalk : MonoBehaviour {

    public float speed = 1f;

	void Start () {
		
	}

	void Update () {
        transform.Translate(new Vector3(speed*Time.deltaTime, 0));
	}
}
