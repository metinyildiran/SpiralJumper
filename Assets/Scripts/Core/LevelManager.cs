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
            //    if (_gameManager)
            //    {
            //        _gameManager.ResetData();
            //    }
            //}
        }

        public void RestartLevel()
        {
            GameManager.instance.StartTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //public void LoadLastRemainingLevel()
        //{
        //    SceneManager.LoadScene(_gameManager.LastFinishedLevel + 1);
        //}

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

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}