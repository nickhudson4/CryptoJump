using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        MENU,
        READY,
        GAMEPLAY,
        GAMEPLAY_END //Ending animation before level over menu
    }
    public State state = State.GAMEPLAY;

    public InputManager inputManager;
    public PlayerManager playerManager;

    //LEVEL SETTINGS
    [SerializeField] private int startAtLevel;
    public List<GameObject> levelPrefabs;
    private int currentLevelIndex = 0;
    private Level currentLevel;
    public GameObject defaultHeroPrefab; //Only used is hero is not selected from start menu
    [HideInInspector] public int coinCount = 0;


    void Start()
    {
        LoadLevel(startAtLevel);
    }

    public void LoadLevel(int num)
    {
        Debug.Log("LOADING LVL " + num);
        if (num < 1){ num = 1;}
        if (num > levelPrefabs.Count){ num = 1; }
        if (currentLevel)
        { 
            Destroy(currentLevel.gameObject); 
        }

        currentLevel = Instantiate(levelPrefabs[num - 1], Vector3.zero, Quaternion.identity).GetComponent<Level>();
        currentLevelIndex = num - 1;

        OnLevelStart();
    }


    public void OnPressAnyButton()
    {
        switch (state)
        {
            case State.READY:
            {
                state = State.GAMEPLAY;
                playerManager.player.OnStartGameplay();
                playerManager.player.Jump(1200);
                gv.core.mainUI.timer.Set(true);
                gv.core.mainUI.timer.StartTimer();
                break;
            }
        }
    } 

    public void OnCollectCoin(Coin coin)
    {
        coinCount+=10;
        gv.core.mainUI.coinCountUI.SetCount(coinCount);
    }

    public void OnHitLastPlatform(Platform platform)
    {
        state = State.GAMEPLAY_END;
        gv.core.cameraController.mode = CameraController.Mode.NONE;
        playerManager.player.OnHitLastPlatform(platform);
    }

    public void OnLevelWin()
    {
        gv.core.mainUI.OnGameWin();
        state = State.MENU;
    }

    public void OnLevelLose()
    {
        gv.core.mainUI.OnGameOver();
        // state = State.MENU;
        // gv.core.RestartScene();
        RetryLevel();
    }

    public void GoToNextLevel()
    {
        LoadLevel(currentLevelIndex + 2);
    }

    public void RetryLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void OnLevelStart()
    {
        Player player;
        if (gv.heroPrefab){ player = playerManager.SpawnPlayer(gv.heroPrefab); }
        else { player = playerManager.SpawnPlayer(defaultHeroPrefab); }
        gv.core.cameraController.OnLevelStart();
        gv.core.mainUI.OnLevelStart();
        state = State.READY;
    }

    public Level GetCurrentLevel()
    {
        return currentLevel;
    }
}
