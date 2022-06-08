using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class RewardText : TextBase
{
    private readonly string[] rewards = { "AWESOME!", "AMAZING!", "BREATHTAKING!",
        "MAGNIFICENT!", "ASTONISHING!", "INSPIRING!" , "STUNNING!", "MIRACULOUS!", "SPECTACULAR!", "SUBLIME!" };

    private int enableCount;

    private void OnEnable()
    {
        if (enableCount % 3 == 0)
        {
            SetText(GetComponent<TMP_Text>());

            StopAllCoroutines();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(gameObject.transform.DOPunchScale(new Vector3(0.3f, 0.3f), 0.2f, 10, 0));
        }

        StartCoroutine(nameof(HideRewardText));

        enableCount++;
    }

    private IEnumerator HideRewardText()
    {
        yield return new WaitForSeconds(1.2f);

        gameObject.transform.DOScale(0.0f, 0.2f).onComplete += _HideRewardText;
    }

    private void _HideRewardText()
    {
        gameObject.SetActive(false);
        gameObject.transform.DOScale(1, 0);

        enableCount = 0;
    }

    protected override void SetText(TMP_Text tmp_text)
    {
        tmp_text.text = rewards[Random.Range(0, rewards.Length)];
    }
}
