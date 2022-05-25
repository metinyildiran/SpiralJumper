using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Touch _touch;
    public static GameManager instance;

    private bool canFollow = true;
    private bool canRotateCylinder = true;
    private bool isGameStarted = false;
    private bool isGameFailed = false;

    public delegate void OnGameStart();
    public delegate void OnGameStop();
    public delegate void OnGameFinished();

    public event OnGameStart onGameStart;
    public event OnGameStop onGameFailed;
    public event OnGameFinished onGameFinished;


    private void Awake()
    {
        instance = this;

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (isGameStarted) return;

        IsGameStarted();
    }

    private void IsGameStarted()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                isGameStarted = true;

                onGameStart.Invoke();
            }
        }
    }

    public void GameFailed()
    {
        onGameFailed.Invoke();

        StopTime();

        canRotateCylinder = false;
        isGameFailed = true;
    }

    public void GameFinished()
    {
        onGameFinished.Invoke();

        StopTime();
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public bool CanPlayGame()
    {
        return canRotateCylinder && !isGameFailed;
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
