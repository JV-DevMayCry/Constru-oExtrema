using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] private TMP_Text gameOverScoreText;
   [SerializeField] private CloudServices cloudServices;
   private int score;

   public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        gameOverScoreText.text = "Score" + score;
    }

    public async void ScoreRegistry()
    {
        await cloudServices.ScoreSave(score);
    }
}
