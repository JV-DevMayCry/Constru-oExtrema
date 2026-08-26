using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CardRanking : MonoBehaviour
{
    [SerializeField] private TMP_Text txtPosition;
    [SerializeField] private TMP_Text txtUsername;
    [SerializeField] private TMP_Text txtScore;

    public void CardInicialize(int Position, string Username, int score)
    {
        txtPosition.text = Position.ToString();
        txtUsername.text = Username;
        txtScore.text = score.ToString();

    }
}
