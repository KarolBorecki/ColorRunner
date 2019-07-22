using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsHandler : MonoBehaviour {

    public List<Color> colors;
    public List<Color> additionalColors;

	void Start () {

	}
	
	void Update () {
		
	}

    public int GetRandomColor(int actuall){
        int i = actuall;
        while (i == actuall)
        {
            i = Random.Range(0, colors.Count);
        } 
        return i;
    }

    public Color GetRandomAdditionalColor(){
        int i = Random.Range(0, additionalColors.Count);
        return additionalColors[i];
    }
}
