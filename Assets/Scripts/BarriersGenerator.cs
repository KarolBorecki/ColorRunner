using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersGenerator : MonoBehaviour {
    public Vector2 barrierSpawnTime;
    public Transform barrier;

    public Vector2 barrierY;

    private float time;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(barrier, new Vector2(transform.position.x, Random.Range(barrierY.x, barrierY.y)), transform.rotation);

            Reset();
        }
    }
    private void Reset()
    {
        time = Random.Range(barrierSpawnTime.x, barrierSpawnTime.y);
    }
}
