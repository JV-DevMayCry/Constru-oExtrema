using UnityEngine;
using Unity.Services.Core;
using System;
using Unity.VisualScripting;
using TMPro;

public class LoginManager : MonoBehaviour
{

    [SerializeField] private CloudServices cloudServices;
    [SerializeField] private TMP_Text usernameText;


    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await cloudServices.SignUpAnonymouslyAsync();

            usernameUiUpdate();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void usernameUiUpdate()
    {
        usernameText.text = cloudServices.GetUserName();
    }
}
