using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Points;
    public Text ScoreText;
    public GameObject GameOverLayer;
    public Text GameOverScoreText;

    void Start()
    {
        Points = 0;
    }

    public void GetPoints(int amount)
    {
        Points += amount;
        ScoreText.text = Points.ToString();
    }

    public void GameOver()
    {
        GameOverLayer.SetActive(true);
        GameOverScoreText.text = Points.ToString();
        Time.timeScale = 0f;
    }
}
