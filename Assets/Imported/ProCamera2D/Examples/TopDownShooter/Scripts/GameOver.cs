using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Com.LuisPedroFonseca.ProCamera2D.TopDownShooter
{
    public class GameOver : MonoBehaviourEX<GameOver>
    {
        public Text m_GameOverText;

        public Canvas GameOverScreen;

        public override void Awake()
        {
            GameOverScreen.gameObject.SetActive(false);
            base.Awake();
        }

        public void ShowScreen(string winnerID="")
        {
            GameOverScreen.gameObject.SetActive(true);
            m_GameOverText.text = "Player "+winnerID+" wins.";
            Time.timeScale = 0;
        }

        public void PlayAgain()
        {
            Time.timeScale = 1;

            #if UNITY_5_3_OR_NEWER
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            #else
            Application.LoadLevel(Application.loadedLevel);
            #endif
        }
    }
}