using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour {

    public int points = 0;
    public Text pointsText;
    public int scores = 0;
    public int pointsMultiplier = 1;

    void Start () {
		
	}
	
	void Update () {
        int realPoints = (int)transform.position.x * pointsMultiplier;
        if (realPoints > points)
            setPoints(realPoints);
    }

    public void addScore(){
        scores += 1;
        setScores(scores);
    }

    void setPoints(int amount){
        points = amount;
        if (amount % 100 == 0)
        {
            GetComponent<CameraXWalk>().SpeedUp();
        }
        pointsText.text = points.ToString();
    }

    void setScores(int amount){
        scores = amount;
    }
}
