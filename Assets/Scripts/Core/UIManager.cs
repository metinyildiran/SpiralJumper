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

    readonly int FaceColor = Shader.PropertyToID("_FaceColor");
    readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");
    readonly int UnderlayColor = Shader.PropertyToID("_UnderlayColor");

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

        scoreText.fontSharedMaterial.SetColor(FaceColor, Resources.Load<Material>("Materials/M_Text").GetColor(FaceColor));

        rewardText.fontSharedMaterial.SetColor(FaceColor, Resources.Load<Material>("Materials/M_Primary").color);
        rewardText.fontSharedMaterial.SetColor(OutlineColor, Resources.Load<Material>("Materials/M_Secondary").color);
        rewardText.fontSharedMaterial.SetColor(UnderlayColor, Resources.Load<Material>("Materials/M_Ball").color);

        dragToPlayText.fontSharedMaterial.SetColor(FaceColor, Resources.Load<Material>("Materials/M_Primary").color);
        dragToPlayText.fontSharedMaterial.SetColor(OutlineColor, Resources.Load<Material>("Materials/M_Secondary").color);

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
