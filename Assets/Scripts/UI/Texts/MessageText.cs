using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MessageText : TextBase
{
    public void SetText(string text)
    {
        this.text.text = text;

        gameObject.transform.DOScale(1, 0);

        StopAllCoroutines();

        transform.DOPunchScale(new Vector3(0.3f, 0.3f), 0.2f, 10, 0);

        StartCoroutine(HideMessageTextRoutine());
    }

    private IEnumerator HideMessageTextRoutine()
    {
        yield return new WaitForSeconds(2.0f);

        gameObject.transform.DOScale(0.0f, 0.2f).onComplete += HideMessageText;
    }

    private void HideMessageText()
    {
        gameObject.SetActive(false);
    }
}
