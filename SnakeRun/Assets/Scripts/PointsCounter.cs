using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour {

    public int points = 0;
    public int pointsMultiplier = 1;

    void Start () {
		
	}
	
	void Update () {
        int realPoints = (int)transform.position.x * pointsMultiplier;
        if (realPoints > points)
            setPoints(realPoints);
    }

    void setPoints(int amount){
        points = amount;
    }
}
