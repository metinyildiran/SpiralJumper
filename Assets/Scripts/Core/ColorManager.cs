using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    private ColorLibrary colorLibrary;

    private void Awake()
    {
        ChangeColors();
    }

    private void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        colorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % colorLibrary.colors.Length;

        colorLibrary.currentColor = colorLibrary.colors[index];

        SetMaterialColor("M_Primary", ShaderID.BaseColor, colorLibrary.colors[index].primaryColor);
        SetMaterialColor("M_Text", ShaderID.FaceColor, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Secondary", ShaderID.BaseColor, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Sprite", ShaderID.Color, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.TopColor, colorLibrary.colors[index].gradient.colorKeys[0].color);
        SetMaterialColor("M_GradientSkyBackground", ShaderID.BottomColor, colorLibrary.colors[index].gradient.colorKeys[1].color);
        SetMaterialColor("M_Cylinder", ShaderID.BaseColor, colorLibrary.colors[index].cylinderColor);
        SetMaterialColor("M_Ball", ShaderID.BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Splash", ShaderID.BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Special", ShaderID.BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Particle", ShaderID.BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Trail", ShaderID.BaseColor, colorLibrary.colors[index].ballColor);

        Resources.UnloadUnusedAssets();
    }

    private void SetMaterialColor(string matName, int nameID, Color color)
    {
        Resources.Load<Material>($"Materials/{matName}").SetColor(nameID, color);
    }
}
