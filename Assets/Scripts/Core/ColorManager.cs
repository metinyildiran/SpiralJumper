using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ColorManager : MonoBehaviour
{
    private ColorLibrary colorLibrary;

    readonly int Color = Shader.PropertyToID("_Color");
    readonly int FaceColor = Shader.PropertyToID("_FaceColor");
    readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    readonly int TopColor = Shader.PropertyToID("_TopColor");
    readonly int BottomColor = Shader.PropertyToID("_BottomColor");

    private void Awake()
    {
        ChangeColors();
    }

    //private void OnValidate()
    //{
    //    ChangeColors();
    //}

    //private void Update()
    //{
    //    ChangeColors();
    //}

    public void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        colorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % colorLibrary.colors.Length;

        SetMaterialColor("M_Primary", BaseColor, colorLibrary.colors[index].primaryColor);
        SetMaterialColor("M_Text", FaceColor, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Secondary", BaseColor, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_Sprite", Color, colorLibrary.colors[index].secondaryColor);
        SetMaterialColor("M_GradientSkyBackground", TopColor, colorLibrary.colors[index].gradient.colorKeys[0].color);
        SetMaterialColor("M_GradientSkyBackground", BottomColor, colorLibrary.colors[index].gradient.colorKeys[1].color);
        SetMaterialColor("M_Cylinder", BaseColor, colorLibrary.colors[index].cylinderColor);
        SetMaterialColor("M_Ball", BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Splash", BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Special", BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Particle", BaseColor, colorLibrary.colors[index].ballColor);
        SetMaterialColor("M_Trail", BaseColor, colorLibrary.colors[index].ballColor);

        Resources.UnloadUnusedAssets();
    }

    private void SetMaterialColor(string matName, int nameID, Color color)
    {
        Resources.Load<Material>($"Materials/{matName}").SetColor(nameID, color);
    }
}
