using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] private TMP_Text gameOverScoreText;
   private int score;

   public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        gameOverScoreText.text = "Score" + score;
    }
}
