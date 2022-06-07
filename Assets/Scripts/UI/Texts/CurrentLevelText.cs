using TMPro;
using UnityEngine.SceneManagement;

public class CurrentLevelText : TextBase
{
    protected override void SetText(TMP_Text tmp_text)
    {
        tmp_text.text = (SceneManager.GetActiveScene().buildIndex).ToString();
    }
}
