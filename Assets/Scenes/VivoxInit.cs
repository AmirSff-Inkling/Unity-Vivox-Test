using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Vivox;
using Unity.VisualScripting;
using UnityEngine;

public class VivoxInit : MonoBehaviour
{

    private void Start()
    {
        Process();
    }

    async void Process()
    {
        await InitializeAsync();

        await LoginToVivoxAsync();

        await JoinEchoChannelAsync();
    }


    async Task InitializeAsync()
    {

        Debug.Log("InitializeAsync...");
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        await VivoxService.Instance.InitializeAsync();
    }


    public async Task LoginToVivoxAsync()
    {
        Debug.Log("LoginToVivoxAsync...");
        LoginOptions options = new LoginOptions();
        options.DisplayName = "Amir";
        options.EnableTTS = true;
        await VivoxService.Instance.LoginAsync(options);
    }

    public async Task JoinEchoChannelAsync()
    {
        Debug.Log("JoinEchoChannelAsync...");
        string channelToJoin = "Lobby";
        await VivoxService.Instance.JoinEchoChannelAsync(channelToJoin, ChatCapability.TextAndAudio);
    }
}
