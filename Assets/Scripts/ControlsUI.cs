using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsUI : MonoBehaviour
{
    public Button pauseBtn;
    public Button playBtn;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.GetState() != GameManager.State.PAUSED){ OnClickPause(); }
            else { OnClickResume(); }
        }
    }

    public void OnClickPause()
    {
        // if (GameManager.GetState() == GameManager.State.PAUSED){ return; }
        pauseBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
        gv.core.gameManager.Pause(true);
    }

    public void OnClickResume()
    {
        // if (GameManager.GetState() != GameManager.State.PAUSED){ return; }
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        gv.core.gameManager.Pause(false);
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
