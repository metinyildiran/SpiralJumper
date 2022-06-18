using TMPro;
using UnityEngine;

public class TextBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        SetText(GetComponent<TMP_Text>());
    }

    protected virtual void SetText(TMP_Text tmp_text) { }
}
