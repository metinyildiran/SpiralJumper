using TMPro;
using UnityEngine;

public class TextBase : MonoBehaviour
{
    private TMP_Text tmp_text;

    protected virtual void Awake()
    {
        tmp_text = GetComponent<TMP_Text>();

        SetText(tmp_text);
    }

    protected virtual void SetText(TMP_Text tmp_text) { }
}
