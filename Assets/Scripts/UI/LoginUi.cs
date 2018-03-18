using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUi : MonoBehaviour
{
    public GameObject AnnouncementGameObject;
    public GameObject RegisterPanel;

    public GameObject UsernameGameObject;
    private TMP_InputField _usernameInput;
    public GameObject PasswordGameObject;
    private TMP_InputField _passwordInput;

    public MessageBox MsgBox;
    
    public TextMeshProUGUI _versionText;

    private TextMeshProUGUI _announcementText;

    private void Start()
    {
        _usernameInput = UsernameGameObject.GetComponent<TMP_InputField>();
        _passwordInput = PasswordGameObject.GetComponent<TMP_InputField>();
        
        _announcementText = AnnouncementGameObject.GetComponent<TextMeshProUGUI>();
        if (_announcementText == null)
            throw new Exception("Announcement GameObject missing component TextMeshProUGUI");

        StartCoroutine(API.GetAnnouncements(delegate(string text)
        {
            if (text == "") return;
            AnnouncementGameObject.transform.parent.gameObject.SetActive(true);
            _announcementText.text = text;
        }));

        _versionText.text = string.Format("Version {0} ({1})\n{2:MM/dd/yyyy}", Version.GetVersionString(),
            Version.BUILD_TYPE, Version.GetVersionTime());
    }

    public void OnLoginClick()
    {
        var username = _usernameInput.text;
        var password = _passwordInput.text;
        StartCoroutine(API.Login(username, password, response =>
        {
            var jsonResult = JsonConvert.DeserializeObject<API_LoginResult>(response);
            if (jsonResult.result == 0)
            {
                API.player.id = jsonResult.id;
                API.player.nickname = jsonResult.username;
                API.player.expack = jsonResult.expack;
                API.player.gold = jsonResult.gold;
                API.player.rmb = jsonResult.rmb;
                API.player.cards = string.Join("/", jsonResult.cards.ToArray());
                web.player = API.player;
                
                /*
                string[] s = res.Split('/');
                player.id = s[1];
                player.nickname = s[2];
                player.expack = int.Parse(s[3]);
                player.gold = int.Parse(s[4]);
                player.rmb = 2000;
                for(int x=5;x<s.Length;x++)
                {
                    player.cards += s[x] + "/";
                }
                 */
                SceneManager.LoadScene("game");
            }else
                MsgBox.ShowMessage(response);
        }));
        // TODO
    }

    public void OnRegisterClick()
    {
        RegisterPanel.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnSettingsClick()
    {
        // TODO
    }

    public void OnOpenWebClick()
    {
        Application.OpenURL("https://github.com/exmex/HS_Multilang");
    }
}