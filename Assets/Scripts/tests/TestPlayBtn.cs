using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayBtn : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Play(){
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void Again(){

    }
}
