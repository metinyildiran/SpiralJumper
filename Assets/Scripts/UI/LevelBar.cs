using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    private Image fillBarImage;
    private float fillAmount = -0.1f;

    private void Awake()
    {
        fillBarImage = GetComponent<Image>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += FillUpBar;
    }

    private void FillUpBar(int score)
    {
        DOTween.To(() => fillAmount, x => fillAmount = x, fillAmount + 0.1f, 0.1f)
            .OnUpdate(() =>
            {
                fillBarImage.fillAmount = fillAmount;
            });
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= FillUpBar;
    }
}
