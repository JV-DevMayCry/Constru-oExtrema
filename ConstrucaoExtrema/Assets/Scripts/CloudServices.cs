using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
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
}


