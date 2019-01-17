using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundriesGenerator : MonoBehaviour {

    public Transform boundryPrefab;
    public Transform relativityObject;
    public Vector2 blockPositioning;
    public int blocksPerScreen = 10;
    public float blockMargin = 1;

    private float blockX;
    private float blockY;
    private List<Transform> blocks = new List<Transform>();

	void Start () {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        blockX = -stageDimensions.x;
        blockY = -stageDimensions.y;

        FirstGenerate();
    }
	
	void Update () {
		
	}

    void FirstGenerate(){
        for (int i = 0; i < blocksPerScreen; i++){
            blocks.Add(Instantiate(boundryPrefab, new Vector3(blockX + blockMargin*i, blockY, 0),transform.rotation));
        }
    }
}
