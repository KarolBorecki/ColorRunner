using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXWalk : MonoBehaviour {

    public float speed = 1f;
    private float startSpeed;
    public float speedingUp = 1.3f;
    public float speedingReduction = 0.96f;

    private void Start()
    {
        startSpeed = speed;
    }
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
    public void Reset()
    {
        speed = startSpeed;
    }
    public void SpeedUp()
    {
        speed += speedingUp;
        speedingUp *= 0.93f;
    }
}
