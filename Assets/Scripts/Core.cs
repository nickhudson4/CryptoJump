using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class should be accessed though the gv static class. Not directly.

public class Core : MonoBehaviour
{
    public GameManager gameManager;
    public CameraController cameraController;
    public MainUI mainUI;

    void Awake()
    {
        gv.core = this;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
