using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ColorManager : MonoBehaviour
{
    private ColorLibrary colorLibrary;

    private void Awake()
    {
        ChangeColors();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        //ChangeColors();    
    }
#endif

    public void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        colorLibrary = Resources.Load<ColorLibrary>("Settings/Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % colorLibrary.colors.Length;

        Resources.Load<Material>("Materials/M_Primary").SetColor("_BaseColor", colorLibrary.colors[index].primaryColor);
        Resources.Load<Material>("Materials/M_Text").color = colorLibrary.colors[index].secondaryColor;

        Resources.Load<Material>("Materials/M_Secondary").SetColor("_BaseColor", colorLibrary.colors[index].secondaryColor);
        Resources.Load<Material>("Materials/M_Sprite").color = colorLibrary.colors[index].secondaryColor;

        Camera.main.backgroundColor = colorLibrary.colors[index].backgroundColor;

        Resources.Load<Material>("Materials/M_GradientSkyBackground")
            .SetColor("_TopColor", colorLibrary.colors[index].gradient.colorKeys[0].color);

        Resources.Load<Material>("Materials/M_GradientSkyBackground")
            .SetColor("_BottomColor", colorLibrary.colors[index].gradient.colorKeys[1].color);

        Resources.Load<Material>("Materials/M_Cylinder").SetColor("_BaseColor", colorLibrary.colors[index].cylinderColor);

        Resources.Load<Material>("Materials/M_Ball").SetColor("_BaseColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Splash").SetColor("_BaseColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Special").SetColor("_BaseColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Particle").SetColor("_BaseColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Trail").SetColor("_BaseColor", colorLibrary.colors[index].ballColor);
    }
}
