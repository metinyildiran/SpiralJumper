using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : TouchMove
{
    public static GameManager instance;

    private bool canFollow = true;
    private bool canRotateCylinder = true;
    private bool isGameStarted = false;
    private bool isGameFinished = false;
    private bool isGameFailed = false;

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

        instance = this;

        Application.targetFrameRate = 60;
    }

    protected override void OnTouchMoved(CallbackContext context)
    {
        if (isGameStarted) return;

        isGameStarted = true;

        onGameStart?.Invoke();
    }

    public void GameFailed()
    {
        onGameFailed?.Invoke();

        canRotateCylinder = false;
        isGameFailed = true;
    }

    public void GameFinished()
    {
        onGameFinished?.Invoke();

        canRotateCylinder = false;
        isGameFinished = true;
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
}
