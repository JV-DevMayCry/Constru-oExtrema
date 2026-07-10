using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreText;
   private int score;

   public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
