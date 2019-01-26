using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

	void Start () {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,.4f,1,.6f,.95f);

    }
}
