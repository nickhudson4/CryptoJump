using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int TOTAL_LIVES = 3; 
    public enum State
    {
        MENU,
        READY,
        GAMEPLAY,
        GAMEPLAY_END, //Ending animation before level over menu
        PAUSED,
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
    [HideInInspector] public int coinsCollectedThisLevel= 0;

    [HideInInspector] public int lives = TOTAL_LIVES;

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
            GetCurrentLevel().DestroyLevel();
        }

        currentLevel = Instantiate(levelPrefabs[num - 1], Vector3.zero, Quaternion.identity).GetComponent<Level>();
        currentLevelIndex = num - 1;
        gv.core.mainUI.lvlText.text = "LEVEL " + Utils.IntToString(num);
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
                gv.core.mainUI.OnGameplayStart();
                break;
            }
        }
    } 

    public void OnCollectCoin(Coin coin)
    {
        coinCount += coin.worth;
        coinsCollectedThisLevel += coin.worth;
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
        lives--;
        gv.core.mainUI.healthUI.SetHealth(lives);
        if (lives <= 0)
        {
            OnGameOver();
        }
        else 
        {
            coinCount -= coinsCollectedThisLevel;
            gv.core.mainUI.coinCountUI.SetCount(coinCount);
            RetryLevel();
        }
    }

    public void OnGameOver()
    {
        gv.core.mainUI.OnGameOver();
        coinCount = 0;
		gv.core.mainUI.coinCountUI.SetCount(coinCount);
        playerManager.player.Set(false);
        state = State.MENU;
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
        coinsCollectedThisLevel = 0;
        gv.core.mainUI.coinCountUI.SetCount(coinCount);
        state = State.READY;
    }

    public void Pause(bool pause)
    {
        if ((state == State.PAUSED && pause) || (state != State.PAUSED && !pause)){ return; }
        if (pause)
        {
            state = State.PAUSED;
            LeanTween.pauseAll();
            Time.timeScale = 0;
        }
        else 
        {
            state = State.GAMEPLAY;
            LeanTween.resumeAll();
            Time.timeScale = 1;
        }

        GetCurrentLevel().OnPause(pause);
        gv.core.mainUI.OnPause(pause);
        gv.core.cameraController.OnPause(pause);
    }

    public Level GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetCurrentLevelNum()
    {
        return currentLevelIndex + 1;
    }

    public static State GetState()
    {
        return gv.core.gameManager.state;
    }
}
