using System;
using System.Collections;
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
    private bool isSpecialActive = false;

    public int LastFinishedLevel { get; private set; }
    private int _score;
    private int specialCount;

    public delegate void OnGameStart();
    public delegate void OnGameFailed();
    public delegate void OnGameFinished();
    public delegate void OnScoreChanged(int score);
    public delegate void OnSpecialChanged(bool isActive);

    public event OnGameStart onGameStart;
    public event OnGameFailed onGameFailed;
    public event OnGameFinished onGameFinished;
    public event OnScoreChanged onScoreChanged;
    public event OnSpecialChanged onSpecialChanged;

    protected override void Awake()
    {
        base.Awake();

        LoadData();

        instance = this;

        Application.targetFrameRate = 60;
    }

    protected override void Start()
    {
        base.Start();

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

    public void AddScore(int score = 10)
    {
        _score += score;

        onScoreChanged?.Invoke(_score);
    }

    public void OnCirclePassed()
    {
        AddScore();

        CheckSpecial();
    }

    private void CheckSpecial()
    {
        specialCount++;

        if (specialCount >= 3)
        {
            StartCoroutine(SetIsSpecialActive(true));
        }
    }

    public bool CanPlayGame()
    {
        return isGameFailed || isGameFinished;
    }

    #region Getters and Setters

    public bool GetIsSpecialActive()
    {
        return isSpecialActive;
    }

    public IEnumerator SetIsSpecialActive(bool value, float waitSeconds = 0.0f)
    {
        onSpecialChanged?.Invoke(value);

        yield return new WaitForSeconds(waitSeconds);

        if (!value)
        {
            specialCount = 0;
        }

        isSpecialActive = value;
    }

    public bool GetIsGameFailed()
    {
        return isGameFailed;
    }

    public bool GetIsGameFinished()
    {
        return isGameFinished;
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

    #endregion

    #region Saving and Loading

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
    #endregion
}
