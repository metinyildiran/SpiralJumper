using System;
using DG.Tweening;
using UnityEngine;

public class EndlessModeButton : ButtonBase
{
    public bool IsEndlessModeActive;

    private void Start()
    {
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
            GameObject.Find("ScoreText").GetComponent<RectTransform>().DOAnchorPosY(-80, 0.2f, false);
            GameObject.Find("LevelIndicator").GetComponent<RectTransform>().DOAnchorPosY(80, 0.2f, false);
            GameObject.Find("RestartButton").GetComponent<RectTransform>().DOAnchorPosY(130, 0.2f, false);

            FindObjectOfType<UIManager>().ShowMessage("Endless Mode");
        }
        else
        {
            GameObject.Find("ScoreText").GetComponent<RectTransform>().DOAnchorPosY(-200, 0.2f, false);
            GameObject.Find("LevelIndicator").GetComponent<RectTransform>().DOAnchorPosY(-40, 0.2f, false);
            GameObject.Find("RestartButton").GetComponent<RectTransform>().DOAnchorPosY(-30, 0.2f, false);
        }

        IsEndlessModeActive = !IsEndlessModeActive;
    }

    private void SetEndlessMode()
    {
        if (IsEndlessModeActive)
        {
            GameObject.Find("ScoreText").GetComponent<RectTransform>().DOAnchorPosY(-80, 0.2f, false);
            GameObject.Find("LevelIndicator").GetComponent<RectTransform>().DOAnchorPosY(80, 0.2f, false);
            GameObject.Find("RestartButton").GetComponent<RectTransform>().DOAnchorPosY(130, 0.2f, false);

            FindObjectOfType<UIManager>().ShowMessage("Endless Mode");
        }
        else
        {
            GameObject.Find("ScoreText").GetComponent<RectTransform>().DOAnchorPosY(-200, 0.2f, false);
            GameObject.Find("LevelIndicator").GetComponent<RectTransform>().DOAnchorPosY(-40, 0.2f, false);
            GameObject.Find("RestartButton").GetComponent<RectTransform>().DOAnchorPosY(-30, 0.2f, false);
        }
    }
}
