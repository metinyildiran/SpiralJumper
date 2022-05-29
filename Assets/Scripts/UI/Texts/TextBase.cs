using TMPro;
using UnityEngine;

public abstract class TextBase : MonoBehaviour
{
    private TMP_Text levelText;

    private void Awake()
    {
        levelText = GetComponent<TMP_Text>();

        SetText(levelText);
    }

    protected abstract void SetText(TMP_Text levelText);
}
