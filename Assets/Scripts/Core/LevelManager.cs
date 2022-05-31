using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //var isLastLevel = SceneManager.GetActiveScene().name.Equals("Last Level");
            //if (isLastLevel)
            //{
            //    GameManager.instance.ResetData();
            //}
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadLastRemainingLevel()
        {
            SceneManager.LoadScene(GameManager.Instance.LastFinishedLevel + 1);
        }

        //public void StartNewGame()
        //{
        //    if (_gameManager)
        //    {
        //        _gameManager.ResetData();
        //    }

        //    SceneManager.LoadScene(1);
        //}

        public void QuitGame()
        {
            Application.Quit(0);
        }
    }
}