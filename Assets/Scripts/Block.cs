using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    void Start()
    {
        SetSize();
    }

    void SetSize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;

        transform.localScale = new Vector3(transform.localScale.x, worldScreenHeight / sr.sprite.bounds.size.y, 1);
    }
}