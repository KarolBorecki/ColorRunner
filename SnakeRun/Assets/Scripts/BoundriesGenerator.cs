using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundriesGenerator : MonoBehaviour {

    public Transform boundryPrefab;
    public Transform relativityObject;
    public Vector2 maxBlockYPositions;
    public Vector2 maxBlockXPostions;
    public int blocksPerScreen = 10;
    public int safeBlocks = 3;
    public float blockMargin = 1;

    private float blockX;
    private float blockY;
    private int blockNumber = 0;
    private List<Transform> blocks = new List<Transform>();
    private Vector3 stageDimensions;

    void Start () {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        blockX = -stageDimensions.x + maxBlockXPostions.x;
        blockY = -stageDimensions.y + maxBlockYPositions.x;

        FirstGenerate();
    }
	
	void Update () {
        if(relativityObject.position.x + stageDimensions.x - blockMargin/2 >= blocks[blocksPerScreen-safeBlocks].position.x){
            Generate();
        }
	}

    void FirstGenerate(){
        for (int i = 0; i < blocksPerScreen; i++){
            InstantiateBlock();
        }
    }

    void Generate(){
        DeleteBlock();
        InstantiateBlock();
    }

    void InstantiateBlock(){
        blocks.Add(Instantiate(boundryPrefab, new Vector3(blockX + blockMargin * blockNumber, GetRandomY(), 0), transform.rotation));
        blockNumber++;
    }

    void DeleteBlock(){
        Destroy(blocks[0].gameObject);
        blocks.Remove(blocks[0]);
    }

    float GetRandomY(){
        return Random.Range(maxBlockYPositions.x, maxBlockYPositions.y);
    }
}
