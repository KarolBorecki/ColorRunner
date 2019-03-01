using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtn : MonoBehaviour {

    public GameObject panelToShow;

    public void Stop(){
        Time.timeScale = 0f;
        panelToShow.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Resume(){
        Time.timeScale = 1f;
        panelToShow.SetActive(false);
        gameObject.SetActive(true);
    }
}
