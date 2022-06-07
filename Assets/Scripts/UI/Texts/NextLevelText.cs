using TMPro;
using UnityEngine.SceneManagement;

public class NextLevelText : TextBase
{
    protected override void SetText(TMP_Text tmp_text)
    {
        tmp_text.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}
