using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject failedGameUI;
    private GameObject finishedGameUI;
    private TMP_Text rewardText;

    private void OnGUI()
    {
        ((int)(1.0f / Time.smoothDeltaTime)).PrintScreen("FPS");
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        uiCanvas = GameObject.Find("UI");

        failedGameUI = uiCanvas.GetChild("FailedGameUI");
        finishedGameUI = uiCanvas.GetChild("FinishedLevelUI");
        rewardText = uiCanvas.GetChild("RewardText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameFailed += ShowFailedGameUI;
        GameManager.Instance.OnGameFinished += ShowFinishedGameUI;
        GameManager.Instance.OnSpecialChanged += ShowRewardText;
    }

    private void ShowFailedGameUI()
    {
        failedGameUI.SetActive(true);

        rewardText.enabled = false;
    }

    private void ShowFinishedGameUI()
    {
        finishedGameUI.SetActive(true);
    }

    private void ShowRewardText(bool value)
    {
        if (value)
        {
            rewardText.gameObject.SetActive(false);
            rewardText.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameFailed -= ShowFailedGameUI;
        GameManager.Instance.OnGameFinished -= ShowFinishedGameUI;
    }
}
