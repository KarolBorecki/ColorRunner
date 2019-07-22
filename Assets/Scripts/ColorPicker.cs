using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

	void Start () {
        GetComponent<SpriteRenderer>().color = FindObjectOfType<ColorsHandler>().GetRandomAdditionalColor();

    }
}
