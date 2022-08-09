using System;
using DG.Tweening;
using UnityEngine;

public class EndlessModeButton : ButtonBase
{
    public bool IsEndlessModeActive;

    private GameObject bottomCircle;

    private EndlessCylinderSpawner endlessCylinderSpawner;

    private RectTransform scoreText;
    private RectTransform levelIndicator;
    private RectTransform restartButton;

    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<RectTransform>();
        levelIndicator = GameObject.Find("LevelIndicator").GetComponent<RectTransform>();
        restartButton = GameObject.Find("RestartButton").GetComponent<RectTransform>();

        endlessCylinderSpawner = FindObjectOfType<EndlessCylinderSpawner>();
    }

    private void Start()
    {
        bottomCircle = GameObject.FindGameObjectWithTag("BottomCircle");

        LoadSettings();
    }

    private void LoadSettings()
    {
        IsEndlessModeActive = PlayerPrefs.GetInt(nameof(IsEndlessModeActive), 0) != 0;

        SetEndlessMode();
    }

    protected override void OnPressed()
    {
        ToggleEndlessMode();

        PlayerPrefs.SetInt(nameof(IsEndlessModeActive), Convert.ToInt32(IsEndlessModeActive));
    }

    private void ToggleEndlessMode()
    {
        if (!IsEndlessModeActive)
        {
            EndlessModeActive();
        }
        else
        {
            NormalModeActive();
        }

        IsEndlessModeActive = !IsEndlessModeActive;
    }

    private void SetEndlessMode()
    {
        if (IsEndlessModeActive)
        {
            EndlessModeActive();
        }
        else
        {
            NormalModeActive();
        }
    }

    private void EndlessModeActive()
    {
        scoreText.DOAnchorPosY(-80, 0.2f, false);
        levelIndicator.DOAnchorPosY(80, 0.2f, false);
        restartButton.DOAnchorPosY(130, 0.2f, false);

        FindObjectOfType<UIManager>().ShowMessage("Endless Mode");

        StartCoroutine(endlessCylinderSpawner.SpawnSingleCylinderRoutine());

        bottomCircle.SetActive(false);
    }

    private void NormalModeActive()
    {
        scoreText.DOAnchorPosY(-200, 0.2f, false);
        levelIndicator.DOAnchorPosY(-40, 0.2f, false);
        restartButton.DOAnchorPosY(-30, 0.2f, false);

        bottomCircle.SetActive(true);

        endlessCylinderSpawner.ResetEndlessMode();
    }
}
