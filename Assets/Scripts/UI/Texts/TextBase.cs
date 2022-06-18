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

    protected virtual void SetTextColor()
    {
        ColorLibrary colorLibrary = ColorManager.Instance.ColorLibrary;

        text.fontSharedMaterial.SetColor(ShaderID.FaceColor, colorLibrary.currentColor.primaryColor);
        text.fontSharedMaterial.SetColor(ShaderID.OutlineColor, colorLibrary.currentColor.secondaryColor);
        text.fontSharedMaterial.SetColor(ShaderID.UnderlayColor, colorLibrary.currentColor.ballColor);
    }

    protected virtual void SetText(TMP_Text tmp_text) { }
}
