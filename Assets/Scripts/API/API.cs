using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class API
{
    private const string API_URL = "http://127.0.0.1";
    
    public static playerInfo player = new playerInfo();

    private static void Log(string text)
    {
        Debug.Log("[API] " + text);
    }

    public static IEnumerator GetAnnouncements(Action<string> callbackFunc)
    {
        var www = UnityWebRequest.Get(API_URL + "/announcements.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Log(www.error);
        }
        else
        {
            callbackFunc(www.downloadHandler.text);
        }
    }

    public static IEnumerator Register(string username, string password, string email, Action<string> callbackFunc)
    {
        var www = UnityWebRequest.Post(API_URL + "/register.php", new Dictionary<string, string>()
        {
            {"username", username},
            {"password", password},
            {"email", email},
        });
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Log(www.error);
            callbackFunc(www.error);
        }

        Log(www.downloadHandler.text);
        callbackFunc(www.downloadHandler.text);
    }

    public static IEnumerator Login(string username, string password, Action<string> callbackFunc)
    {
        var www = UnityWebRequest.Post(API_URL + "/login.php", new Dictionary<string, string>()
        {
            {"username", username},
            {"password", password},
        });
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Log(www.error);
            callbackFunc(www.error);
        }

        Log(www.downloadHandler.text);
        callbackFunc(www.downloadHandler.text);
    }
}