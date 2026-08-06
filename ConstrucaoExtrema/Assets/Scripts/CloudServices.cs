using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class CloudServices : MonoBehaviour
{

    [SerializeField] private GameObject loginErrorPopup;

    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await SignUpAnonymouslyAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
    async Task SignUpAnonymouslyAsync()
    {

    if(AuthenticationService.Instance.IsSignedIn) return;

    try
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
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
}


