using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
