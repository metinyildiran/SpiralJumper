using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }
    public ColorLibrary ColorLibrary { get; private set; }

    private void Awake()
    {
        Instance = this;

        ChangeColors();
    }

    private void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        ColorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % ColorLibrary.colors.Length;

        ColorLibrary.currentColor = ColorLibrary.colors[index];

        SetMaterialColor("M_Primary", ShaderID.BaseColor, ColorLibrary.colors[index].primaryColor);
        SetMaterialColor("M_Text", ShaderID.FaceColor, ColorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Secondary", ShaderID.BaseColor, ColorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Sprite", ShaderID.Color, ColorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.TopColor, ColorLibrary.colors[index].gradient.colorKeys[0].color);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.BottomColor, ColorLibrary.colors[index].gradient.colorKeys[1].color);
        SetMaterialColor("M_Cylinder", ShaderID.BaseColor, ColorLibrary.colors[index].cylinderColor);
        SetMaterialColor("M_Ball", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Splash", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Special", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Particle", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Trail", ShaderID.BaseColor, ColorLibrary.colors[index].ballColor);

        Resources.UnloadUnusedAssets();
    }

    private void SetMaterialColor(string matName, int nameID, Color color)
    {
        Resources.Load<Material>($"Materials/{matName}").SetColor(nameID, color);
    }
}
