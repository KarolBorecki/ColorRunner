using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperPositioning : MonoBehaviour {

    public float Xmargin = 0f;
    void Start()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(stageDimensions.x + Xmargin, transform.position.y, 0);
    }
}
