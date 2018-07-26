using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AsteroidGame
{
    public class LogoSceneScript : MonoBehaviour
    {

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("MenuScene");
        }

    }
}