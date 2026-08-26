using UnityEngine;
using Unity.Services.Core;
using System;
using TMPro;

public class LoginManager : MonoBehaviour
{

    [SerializeField] private CloudServices cloudServices;
    [SerializeField] private TMP_Text usernameText;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_Text recordTxt;


    private async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await cloudServices.SignUpAnonymouslyAsync();

            usernameUiUpdate();
            RecordUiUpdate();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void usernameUiUpdate()
    {
        string username = cloudServices.GetUserName();
        usernameText.text = username;
        usernameInputField.text = username.Substring(0, username.IndexOf("#"));
    }

    public async void SaveNewUsername()
    {
        await cloudServices.UsernameUpdate(usernameInputField.text);
        usernameUiUpdate();
    }

    public async void RecordUiUpdate()
    {
        int record = await cloudServices.GetPlayerScore();
        recordTxt.text = "Meu Recorde: " + record;
    }
}
