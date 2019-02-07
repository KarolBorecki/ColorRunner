using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Vector2 enemySpawnTime;
    public List<Enemy> enemies;

    public Vector2 enemyY;
    public Vector2 enemyYWalk;
    public Vector2 enemyYWalkSpeed;

    public Vector2 enemyXWalkSpeed;
    private float time;

	void Start () {
        Reset();
	}
	
	void Update () {
        time -= Time.deltaTime;
        if(time<=0){
            Enemy e = Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(transform.position.x, Random.Range(enemyY.x, enemyY.y)), transform.rotation);
            e.GetComponent<CameraXWalk>().speed = Random.Range(enemyXWalkSpeed.x, enemyXWalkSpeed.y);
            e.range = Random.Range(enemyYWalk.x, enemyYWalk.y);
            e.speed = Random.Range(enemyYWalkSpeed.x, enemyYWalkSpeed.y);
            Reset();
        }
	}
    private void Reset(){
        time = Random.Range(enemySpawnTime.x, enemySpawnTime.y);
    }
}
