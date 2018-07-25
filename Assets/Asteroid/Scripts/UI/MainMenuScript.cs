using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AsteroidGame.UI
{
    public class MainMenuScript : MonoBehaviour
    {
        public Text hiScore;

        void Start()
        {
            //TODO change that to file saving with settings
            hiScore.text = PlayerPrefs.GetInt("hiScore", 0).ToString();
        }

        public void Play()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Settings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}