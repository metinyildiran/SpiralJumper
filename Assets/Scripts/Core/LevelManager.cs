using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            GameManager.Instance.ResetData();
            SceneManager.LoadScene(GameManager.Instance.LastFinishedLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadLastRemainingLevel()
    {
        if (GameManager.Instance.LastFinishedLevel + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            GameManager.Instance.ResetData();
            SceneManager.LoadScene(GameManager.Instance.LastFinishedLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(GameManager.Instance.LastFinishedLevel + 1);
        }
    }
}
