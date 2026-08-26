using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
   [SerializeField] private CloudServices cloudServices;
   [SerializeField] private CardRanking cardRankingPrefab;
   [SerializeField] private Transform rankingContent;

    public async void RankLoad()
    {

        foreach (Transform child in rankingContent)
        {
            Destroy(child.gameObject);
        }

        List<PlayerRanking> players = await cloudServices.GetScore();

        foreach(PlayerRanking playerRanking in players)
        {
            CardRanking card = Instantiate(cardRankingPrefab, rankingContent);
            card.CardInicialize(playerRanking.position + 1, playerRanking.username, playerRanking.score);
        }
        
    }



}
