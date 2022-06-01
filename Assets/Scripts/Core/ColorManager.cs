using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    private ColorLibrary colorLibrary;

    private void Awake()
    {
        ChangeColors();
    }

    //private void Update()
    //{
    //    ChangeColors();
    //}

    private void ChangeColors()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        colorLibrary = Resources.Load<ColorLibrary>("Color Library");

        // switch colors every 10 levels
        int index = (SceneManager.GetActiveScene().buildIndex / 10) % colorLibrary.colors.Length;

        Resources.Load<Material>("Materials/M_Primary").color = colorLibrary.colors[index].primaryColor;
        Resources.Load<Material>("Materials/M_Text").color = colorLibrary.colors[index].primaryColor;

        Resources.Load<Material>("Materials/M_Secondary").color = colorLibrary.colors[index].secondaryColor;
        Resources.Load<Material>("Materials/M_Sprite").color = colorLibrary.colors[index].secondaryColor;

        Camera.main.backgroundColor = colorLibrary.colors[index].backgroundColor;

        Resources.Load<Material>("Materials/M_Cylinder").color = colorLibrary.colors[index].cylinderColor;

        Resources.Load<Material>("Materials/M_Ball").color = colorLibrary.colors[index].ballColor;
        Resources.Load<Material>("Materials/M_Splash").SetColor("_EmissionColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Special").SetColor("_EmissionColor", colorLibrary.colors[index].ballColor);
        Resources.Load<Material>("Materials/M_Trail").SetColor("_EmissionColor", colorLibrary.colors[index].ballColor);
    }
}
