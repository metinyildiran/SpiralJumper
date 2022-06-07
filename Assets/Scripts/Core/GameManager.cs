using System;
using System.Collections;
using System.IO;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : TouchMove
{
    public static GameManager Instance { get; private set; }

    private bool canFollow = true;
    private bool canRotateCylinder = true;
    private bool isGameStarted = false;
    private bool isGameFinished = false;
    private bool isGameFailed = false;
    private bool isSpecialActive = false;

    public int LastFinishedLevel { get; private set; }
    private int _score;
    private int specialCount;

    public event Action OnGameStart;
    public event Action OnGameFailed;
    public event Action OnGameFinished;
    public event Action<int> OnScoreChanged;
    public event Action<bool> OnSpecialChanged;

    protected override void Awake()
    {
        base.Awake();

        LoadData();

        Instance = this;

        Application.targetFrameRate = 60;
    }

    //private void Update()
    //{
    //    Utils.PrintScreen(((int)(1.0f / Time.deltaTime)).ToString(), "FPS");
    //}

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

        OnGameStart?.Invoke();
    }

    public void SetGameFailed()
    {
        canRotateCylinder = false;
        canFollow = false;
        isGameFailed = true;

        OnGameFailed?.Invoke();
    }

    public void GameFinished()
    {
        canRotateCylinder = false;
        isGameFinished = true;
        canFollow = false;

        SaveData();

        OnGameFinished?.Invoke();
    }

    public void AddScore(int score = 10)
    {
        if (isGameFailed) return;

        if (isSpecialActive)
        {
            _score += score * 3;
        }
        else
        {
            _score += score;
        }

        OnScoreChanged?.Invoke(_score);
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
        if (!CanPlayGame()) yield return null;

        OnSpecialChanged?.Invoke(value);

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

        LoadData();
    }
    #endregion
}
