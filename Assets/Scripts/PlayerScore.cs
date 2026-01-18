using System;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        IncreaseScore();
    }

    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = "Score: " + currentScore;
    }
}
