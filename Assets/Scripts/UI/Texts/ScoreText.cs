using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreText : TextBase
{
    private TMP_Text text;

    protected override void Awake()
    {
        base.Awake();

        text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += SetScoreText;
    }

    private void SetScoreText(int score)
    {
        text.text = score.ToString();

        DOPunch();
    }

    private void DOPunch()
    {
        gameObject.transform.DOKill();
        gameObject.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.1f);
    }
}
