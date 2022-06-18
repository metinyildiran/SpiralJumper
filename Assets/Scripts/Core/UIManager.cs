using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject uiCanvas;
    private GameObject InGameUI;
    private GameObject failedGameUI;
    private GameObject finishedGameUI;
    private TMP_Text scoreText;
    private TMP_Text rewardText;
    private TMP_Text dragToPlayText;

    private void OnGUI()
    {
        ((int)(1.0f / Time.smoothDeltaTime)).PrintScreen("FPS");
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        uiCanvas = GameObject.Find("UI");

        InGameUI = uiCanvas.GetChild("InGameUI");
        failedGameUI = uiCanvas.GetChild("FailedGameUI");
        finishedGameUI = uiCanvas.GetChild("FinishedLevelUI");
        scoreText = uiCanvas.GetChild("ScoreText").GetComponent<TMP_Text>();
        rewardText = uiCanvas.GetChild("RewardText").GetComponent<TMP_Text>();

        dragToPlayText = InGameUI.GetChild("DragToPlayText").GetComponent<TMP_Text>();

        SetTextColors();
    }

    private void SetTextColors()
    {
        ColorLibrary colorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        scoreText.fontSharedMaterial.SetColor(ShaderID.FaceColor, colorLibrary.currentColor.secondaryColor);

        rewardText.fontSharedMaterial.SetColor(ShaderID.FaceColor, colorLibrary.currentColor.primaryColor);
        rewardText.fontSharedMaterial.SetColor(ShaderID.OutlineColor, colorLibrary.currentColor.secondaryColor);
        rewardText.fontSharedMaterial.SetColor(ShaderID.UnderlayColor, colorLibrary.currentColor.ballColor);

        dragToPlayText.fontSharedMaterial.SetColor(ShaderID.FaceColor, colorLibrary.currentColor.primaryColor);
        dragToPlayText.fontSharedMaterial.SetColor(ShaderID.OutlineColor, colorLibrary.currentColor.secondaryColor);

        Resources.UnloadUnusedAssets();
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
