using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
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

    public async Task UsernameUpdate(String username)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
    }

    public String GetUserName()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public async Task ScoreSave(int score)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync("Highest_Scores_LB", score);
    }

    public async Task<List<PlayerRanking>> GetScore()
    {
       var scoresResponse = await LeaderboardsService.Instance.GetScoresAsync("Highest_Scores_LB");

        List<PlayerRanking> playersRankings = new List<PlayerRanking>();

        foreach(LeaderboardEntry entry in scoresResponse.Results)
        {
            PlayerRanking player = new PlayerRanking();
            player.position = entry.Rank;
            player.username = entry.PlayerName;
            player.score = (int)entry.Score;

            playersRankings.Add(player);
        }

        return playersRankings;
    }

    public async Task<int> GetPlayerScore()
    {
        try
        {
        var result = await LeaderboardsService.Instance.GetPlayerScoreAsync("Highest_Scores_LB");
        return (int) result.Score;
        }
        catch
        {
            return 0;
        }
    }
}




