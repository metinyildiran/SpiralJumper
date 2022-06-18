using DG.Tweening;
using UnityEngine;

public class ScoreText : TextBase
{
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
