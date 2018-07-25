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
            hiScore.text = ScoreManager.instance.HiScore.ToString();
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