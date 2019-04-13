using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenDisplay : MonoBehaviour
{
    public Rect buttonRect1;
    public Rect buttonRect2;
    public RectTransform GameOverPanel;

    public int fontSize = 15;
   
    void Update()
    {
        DetectGame();
    }

    void OnGUI()
    {
        if (GameManager.instance.IsGameOver)
        {
            GUIStyle s1 = new GUIStyle(GUI.skin.button);
            GUIStyle s2 = new GUIStyle(GUI.skin.button);

            s1.fontSize = fontSize;
            s2.fontSize = fontSize;

            if (GUI.Button(buttonRect1, "Continue"))
            {
                GameManager.instance.IsGameOver = false;
                GameManager.instance.PlayerLife = 3;
                Time.timeScale = 1;
            }
            if (GUI.Button(buttonRect2, "Restart"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);             
            }
        }
    }

    void DetectGame()
    {
        if (GameManager.instance.IsGameOver)
        {
            GameOverPanel.gameObject.SetActive(true);
        }
        else
        {
            GameOverPanel.gameObject.SetActive(false);
        }
    }
}
