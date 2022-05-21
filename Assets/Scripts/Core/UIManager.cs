using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject inGameUI;
    private GameObject endGameUI;

    private void Awake()
    {
        FindObjectOfType<UIManager>();
        uiCanvas = GameObject.Find("UI");
        inGameUI = uiCanvas.GetChild("InGameUI");
        endGameUI = uiCanvas.GetChild("EndGameUI");

        GameManager.instance.onGameStart += HideInGameUI;
        GameManager.instance.onGameStop += ShowEndGameUI;
    }

    private void HideInGameUI()
    {
        inGameUI.SetActive(false);
    }

    private void ShowEndGameUI()
    {
        endGameUI.SetActive(true);
    }
}
