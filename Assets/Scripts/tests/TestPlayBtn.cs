using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayBtn : MonoBehaviour {

    public fade fade;
    public StopBtn stopbtn;

    private void Start(){
        Time.timeScale = 0f;
    }

    public void Play(){
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        stopbtn.gameObject.SetActive(true);
    }

    public void Again(){
        fade.FadeToLevel(0);
    }

    public void Resume(){
        stopbtn.Resume();
    }
}
