using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour {

    public Animator animator;

    private int lvlNumber;

    public void FadeToLevel(int lvl){
        lvlNumber = lvl;
        animator.SetTrigger("FadeOut");
    }

    public void loadScene(){
        SceneManager.LoadScene(lvlNumber);
        Time.timeScale = 1f;
    }
}
