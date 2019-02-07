using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundriesGenerator : MonoBehaviour {

    public Transform boundryPrefab;
    public Transform relativityObject;
    public float firstBlockY;
    public float firstBlockX;
    public Vector2 maxBlockYDifference;
    public Vector2 maxBlocksY;
    public Vector2 maxBlocksGrowing;
    public int blocksPerScreen = 10;
    public int safeBlocks = 3;
    public float blockMargin = 1;

    private float blockX;
    private int actuallBlocksGrowing = 0;
    public bool isGrowing = true;
    private int blockNumber = 0;
    private List<Transform> blocks = new List<Transform>();
    private Vector3 stageDimensions;

    void Start () {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        blockX = -stageDimensions.x + firstBlockX;

        FirstGenerate();
    }
	
	void Update () {
        if(relativityObject.position.x + stageDimensions.x - blockMargin/2 >= blocks[blocksPerScreen-safeBlocks].position.x){
            Generate();
        }
	}

    void FirstGenerate(){
        blocks.Add(Instantiate(boundryPrefab, new Vector3(blockX + blockMargin * blockNumber, firstBlockY, 0), transform.rotation));
        blockNumber++;
        actuallBlocksGrowing--;
        for (int i = 1; i < blocksPerScreen; i++){
            if (actuallBlocksGrowing <= 0) ChangeGrowing();
            InstantiateBlock();
        }
    }

    void Generate(){
        if (actuallBlocksGrowing <= 0) ChangeGrowing();
        DeleteBlock();
        InstantiateBlock();
    }

    void InstantiateBlock(){
        blocks.Add(Instantiate(boundryPrefab, new Vector3(blockX + blockMargin * blockNumber, GetRandomY(maxBlockYDifference), 0), transform.rotation));
        blockNumber++;
        actuallBlocksGrowing--;
    }

    void DeleteBlock(){
        Destroy(blocks[0].gameObject);
        blocks.Remove(blocks[0]);
    }

    void ChangeGrowing(){
        isGrowing = !isGrowing;
        actuallBlocksGrowing = (int)GetRandomFloat(maxBlocksGrowing);
    }

    float GetRandomFloat(Vector2 range){
        return Random.Range(range.x, range.y);
    }

    float GetRandomY(Vector2 range){
        float y = isGrowing ? GetRandomFloat(new Vector2(blocks[blocks.Count - 1].position.y,
                                                      blocks[blocks.Count - 1].position.y + range.y))
                : GetRandomFloat(new Vector2(blocks[blocks.Count - 1].position.y - range.x,
                                                      blocks[blocks.Count - 1].position.y));
        return (y < maxBlocksY.x || y > maxBlocksY.y) ? blocks[blocks.Count - 1].position.y : y;
    }
}
