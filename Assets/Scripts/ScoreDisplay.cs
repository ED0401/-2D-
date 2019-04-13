using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay instance;

    public Text scoreText;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void Add(int s)
    {
        score += s;
    }

    public void Sub(int s)
    {
        score -= s;
        if (score <= 0)
            score = 0;
    }
}
