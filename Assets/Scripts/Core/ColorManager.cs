using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }
    public ColorLibrary ColorLibrary { get; private set; }

    private int endlessCylinderLevel = 1;
    private int passedCylinderCount;

    private TextBase[] textBases;

    private void Awake()
    {
        Instance = this;

        ChangeColors();

        textBases = FindObjectsOfType<TextBase>();
    }

    private void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        ColorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % ColorLibrary.colors.Length;

        ColorLibrary.currentColor = ColorLibrary.colors[index];

        ChangeTheme(index);

        Resources.UnloadUnusedAssets();
    }

    public void SwitchEndlessModeColors()
    {
        if (endlessCylinderLevel == ColorLibrary.colors.Length)
        {
            endlessCylinderLevel = 0;
        }

        if (passedCylinderCount % 3 == 0)
        {
            ColorLibrary.currentColor = ColorLibrary.colors[endlessCylinderLevel];

            foreach (TextBase item in textBases)
            {
                item.SetTextColor(1.0f);
            }

            ChangeTheme(endlessCylinderLevel, 1f);

            endlessCylinderLevel++;
        }

        passedCylinderCount++;
    }

    private void ChangeTheme(int index, float duration = 0.0f)
    {
        SetMaterialColor("M_Primary", ShaderID.BaseColor, ColorLibrary.colors[index].primaryColor, duration);
        SetMaterialColor("M_Text", ShaderID.FaceColor, ColorLibrary.colors[index].secondaryColor, duration);
        SetMaterialColor("M_Secondary", ShaderID.BaseColor, ColorLibrary.colors[index].secondaryColor, duration);
        SetMaterialColor("M_Sprite", ShaderID.Color, ColorLibrary.colors[index].secondaryColor, duration);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.TopColor, ColorLibrary.colors[index].gradient.colorKeys[0].color, duration);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.BottomColor, ColorLibrary.colors[index].gradient.colorKeys[1].color, duration);
        SetMaterialColor("M_Cylinder", ShaderID.BaseColor, ColorLibrary.colors[index].cylinderColor, duration);
        SetMaterialColor("M_Ball", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor, duration);
        SetMaterialColor("M_Splash", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor, duration);
        SetMaterialColor("M_Special", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor, duration);
        SetMaterialColor("M_Particle", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor, duration);
        SetMaterialColor("M_Trail", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor, duration);
    }

    private void SetMaterialColor(string matName, int nameID, Color color, float duration)
    {
        Resources.Load<Material>($"Materials/{matName}").DOColor(color, nameID, duration);
    }
}
