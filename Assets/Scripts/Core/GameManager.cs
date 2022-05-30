using System;
using System.IO;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : TouchMove
{
    public static GameManager instance;

    private bool canFollow = true;
    private bool canRotateCylinder = true;
    private bool isGameStarted = false;
    private bool isGameFinished = false;
    private bool isGameFailed = false;

    public int LastFinishedLevel { get; private set; }
    private int _score;

    public delegate void OnGameStart();
    public delegate void OnGameStop();
    public delegate void OnGameFinished();
    public delegate void OnScoreChanged(int score);

    public event OnGameStart onGameStart;
    public event OnGameStop onGameFailed;
    public event OnGameFinished onGameFinished;
    public event OnScoreChanged onScoreChanged;


    protected override void Awake()
    {
        base.Awake();

        LoadData();

        instance = this;

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LevelManager.Instance.LoadLastRemainingLevel();
        }
    }

    protected override void OnTouchMoved(CallbackContext context)
    {
        if (isGameStarted) return;

        isGameStarted = true;

        onGameStart?.Invoke();
    }

    public void GameFailed()
    {
        canRotateCylinder = false;
        isGameFailed = true;

        onGameFailed?.Invoke();
    }

    public void GameFinished()
    {
        canRotateCylinder = false;
        isGameFinished = true;

        SaveData();

        onGameFinished?.Invoke();
    }

    public void AddScore()
    {
        _score += 10;

        onScoreChanged?.Invoke(_score);
    }

    public bool IsGameFailed()
    {
        return isGameFailed;
    }

    public bool IsGameFinished()
    {
        return isGameFinished;
    }

    public bool CanPlayGame()
    {
        return isGameFailed || isGameFinished;
    }

    public bool GetCanRotateCylinder()
    {
        return canRotateCylinder;
    }

    public void SetCanRotateCylinder(bool value)
    {
        canRotateCylinder = value;
    }

    public bool GetCanFollow()
    {
        return canFollow;
    }

    public void SetCanFollow(bool value)
    {
        canFollow = value;
    }

    [Serializable]
    public class Data
    {
        public int lastFinishedLevel;
    }

    private void SaveData()
    {
        var data = new Data
        {
            lastFinishedLevel = SceneManager.GetActiveScene().buildIndex
        };

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadData()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<Data>(json);

            LastFinishedLevel = data.lastFinishedLevel;
        }
        else
        {
            LastFinishedLevel = 0;
        }
    }

    public void ResetData()
    {
        var data = new Data
        {
            lastFinishedLevel = 0
        };

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
