using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextBase : MonoBehaviour
{
    protected TMP_Text text;

    protected virtual void Awake()
    {
        text = GetComponent<TMP_Text>();

        SetTextColor();

        SetText(text);
    }

    public void SetTextColor(float duration = 0.0f)
    {
        ColorLibrary colorLibrary = ColorManager.Instance.ColorLibrary;

        text.fontSharedMaterial.DOColor(colorLibrary.currentColor.primaryColor, ShaderID.FaceColor, duration);
        text.fontSharedMaterial.DOColor(colorLibrary.currentColor.secondaryColor, ShaderID.OutlineColor, duration);
        text.fontSharedMaterial.DOColor(colorLibrary.currentColor.ballColor, ShaderID.UnderlayColor, duration);
    }

    protected virtual void SetText(TMP_Text tmp_text) { }
}
