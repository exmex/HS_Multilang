using UnityEngine;
using System.Collections;

/// <summary>
/// 主控制
/// </summary>
public class boxcam : MonoBehaviour
{
    public UILabel goldtext, expacktext;
    public static GameObject msgbox;
    public static GameObject ynmsgbox;
    public GameObject box;
    // Use this for initialization
    void Start()
    {
        //测试用
        web.debug();

        //得到用户的信息
        UpdateGandEx();
        msgbox = transform.FindChild("yesmsgbox").gameObject;
        ynmsgbox = transform.FindChild("yesnomsgbox").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void UpdateGandEx()
    {
        goldtext.text = web.player.gold.ToString();
        
        expacktext.text = web.player.expack.ToString();
    }

    
    void showMsgbox(string bt,string text)
    {
        
        msgbox.SendMessage("show", bt + "/" + text);
    }
    void push()
    {
        animation["boxcampush"].speed = 1;
        animation.Play("boxcampush");
        box.animation["boxopendoor"].speed = 1;
        box.animation.Play("boxopendoor");


    }
    void back()
    {
        UpdateGandEx();
        animation["boxcampush"].speed = -1;
        animation["boxcampush"].time = animation["boxcampush"].length;
        animation.Play("boxcampush");

        box.animation["boxopendoor"].speed = -1;
        box.animation["boxopendoor"].time = box.animation["boxopendoor"].length;
        box.animation.Play("boxopendoor");
    }
    void noopen()
    {
        showMsgbox("提示","没有开放!现在只开放'打开扩展包'");
    }
}
