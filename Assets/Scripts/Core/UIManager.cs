using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject failedGameUI;
    private GameObject finishedGameUI;
    private TMP_Text scoreText;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        uiCanvas = GameObject.Find("UI");
        failedGameUI = uiCanvas.GetChild("FailedGameUI");
        finishedGameUI = uiCanvas.GetChild("FinishedLevelUI");
        scoreText = uiCanvas.GetChild("ScoreText").GetComponent<TMP_Text>();

        scoreText.color = Resources.Load<Material>("Materials/M_Text").color;
    }

    private void Start()
    {
        GameManager.Instance.OnGameFailed += ShowFailedGameUI;
        GameManager.Instance.OnGameFinished += ShowFinishedGameUI;
        GameManager.Instance.OnScoreChanged += SetScoreText;
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
        scoreText.transform.DOKill();
        scoreText.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.1f);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameFailed -= ShowFailedGameUI;
        GameManager.Instance.OnGameFinished -= ShowFinishedGameUI;
        GameManager.Instance.OnScoreChanged -= SetScoreText;
    }
}
