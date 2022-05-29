using TMPro;
using UnityEngine.SceneManagement;

public class CurrentLevelText : TextBase
{
    protected override void SetText(TMP_Text levelText)
    {
        levelText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}
