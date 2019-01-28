using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsHandler : MonoBehaviour {

    public List<Color> colors;

	void Start () {

	}
	
	void Update () {
		
	}

    public int GetRandomColor(int actuall){
        int i = actuall;
        while (i == actuall)
        {
            i = Random.Range(0, colors.Count-1);
        } 
        return i;
    }
}
