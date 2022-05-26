using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject inGameUI;
    private GameObject failedGameUI;
    private GameObject finishedGameUI;
    private TMP_Text scoreText;

    private void Awake()
    {
        uiCanvas = GameObject.Find("UI");
        inGameUI = uiCanvas.GetChild("InGameUI");
        failedGameUI = uiCanvas.GetChild("FailedGameUI");
        finishedGameUI = uiCanvas.GetChild("FinishedLevelUI");
        scoreText = inGameUI.GetChild("ScoreText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.instance.onGameStart += HideInGameUI;
        GameManager.instance.onGameFailed += ShowFailedGameUI;
        GameManager.instance.onGameFinished += ShowFinishedGameUI;
        GameManager.instance.onScoreChanged += SetScoreText;
    }

    private void HideInGameUI()
    {
        inGameUI.SetActive(false);
    }

    private void ShowFailedGameUI()
    {
        failedGameUI.SetActive(true);
    }

    private void ShowFinishedGameUI()
    {
        finishedGameUI.SetActive(true);
    }

    private void SetScoreText(int score)
    {
        scoreText.text = score.ToString();

        DOPunch();
    }

    private void DOPunch()
    {
        scoreText.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.1f);
    }

    private void OnDestroy()
    {
        GameManager.instance.onGameStart -= HideInGameUI;
        GameManager.instance.onGameFailed -= ShowFailedGameUI;
        GameManager.instance.onGameFinished -= ShowFinishedGameUI;
        GameManager.instance.onScoreChanged -= SetScoreText;
    }
}
