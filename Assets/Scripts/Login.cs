using System.Collections;
using UnityEngine;


public class Login : MonoBehaviour
{
    public UILabel username, password,gg;
    

    public GameObject msgbox;

    void Start()
    {
        //得到公告
       
        gg.text = web.getNotice();
    }

    void OnClick()
    {
        if(username.text == "")
        {
            showMsg("用户名不能为空!");
            return;
        }

        if(password.text == "")
        {
            showMsg("密码不能为空!");
            return;
        }

        //可以进行登录
        string res = web.login(username.text, password.text);
        if (res.IndexOf("ok") != -1)
        {
            //登录成功
            //载入
            Application.LoadLevel("game");
        }
        else
        {
            showMsg(res);
        }
    }
  
    void OnSubmit()
    {
        UICamera.selectedObject = gameObject;
        OnClick();
    }

     void showMsg(string t)
    {
        msgbox.SendMessage("showMsg", t);
    }

    void LoginExit()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
    void openweb()
    {
        Application.OpenURL("http://mylushi.net");
    }
    public GameObject zhucekuan;
    void showZc()
    {
        zhucekuan.SetActive(!zhucekuan.activeSelf);
    }

}
