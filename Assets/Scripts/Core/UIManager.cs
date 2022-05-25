using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject inGameUI;
    private GameObject failedGameUI;
    private GameObject finishedGameUI;

    private void Awake()
    {
        FindObjectOfType<UIManager>();
        uiCanvas = GameObject.Find("UI");
        inGameUI = uiCanvas.GetChild("InGameUI");
        failedGameUI = uiCanvas.GetChild("FailedGameUI");
        finishedGameUI = uiCanvas.GetChild("FinishedLevelUI");
    }

    private void Start()
    {
        GameManager.instance.onGameStart += HideInGameUI;
        GameManager.instance.onGameFailed += ShowFailedGameUI;
        GameManager.instance.onGameFinished += ShowFinishedGameUI;
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

    private void OnDestroy()
    {
        GameManager.instance.onGameStart -= HideInGameUI;
        GameManager.instance.onGameFailed -= ShowFailedGameUI;
        GameManager.instance.onGameFinished -= ShowFinishedGameUI;
    }
}
