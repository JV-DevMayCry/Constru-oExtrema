using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class CloudServices : MonoBehaviour
{

    [SerializeField] private GameObject loginErrorPopup;

    
    public async Task SignUpAnonymouslyAsync()
    {

    if(AuthenticationService.Instance.IsSignedIn) return;

    try
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        if(AuthenticationService.Instance.PlayerName == "" || AuthenticationService.Instance.PlayerName == null)
            {
                await UsernameUpdate("Player");
                Debug.Log(AuthenticationService.Instance.PlayerName);
            }

        Debug.Log("Sign in anonymously succeeded!");

        // Shows how to get the playerID
        Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

    }
    catch 
    {
        loginErrorPopup.SetActive(true);
    }
    
    }

    public void TryLoginAgain()
    {
        loginErrorPopup.SetActive(false);
        SignUpAnonymouslyAsync();
    }

    public async Task UsernameUpdate(String userName)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(userName);
    }

    public String GetUserName()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public async Task ScoreSave(int score)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync("Highest_Score_LB", 0);
    }

    public async Task<List<PlayerRanking>> GetScore()
    {
       var scoresResponse = await LeaderboardsService.Instance.GetScoresAsync("Highest_Score_LB");

        List<PlayerRanking> playersRankings = new List<PlayerRanking>();

        foreach(LeaderboardEntry entry in scoresResponse.Results)
        {
            PlayerRanking player = new PlayerRanking();
            player.position = entry.Rank;
            player.userName = entry.PlayerName;
            player.score = (int)entry.Score;

            playersRankings.Add(player);
        }

        return playersRankings;
    }

    public async Task<int> GetPlayerScore()
    {
        var result = await LeaderboardsService.Instance.GetPlayerScoreAsync("scores");
        return (int) result.Score;
    }
}




