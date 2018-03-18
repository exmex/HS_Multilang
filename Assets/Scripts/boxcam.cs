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
        msgbox = transform.Find("yesmsgbox").gameObject;
        ynmsgbox = transform.Find("yesnomsgbox").gameObject;
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
        GetComponent<Animation>()["boxcampush"].speed = 1;
        GetComponent<Animation>().Play("boxcampush");
        box.GetComponent<Animation>()["boxopendoor"].speed = 1;
        box.GetComponent<Animation>().Play("boxopendoor");


    }
    void back()
    {
        UpdateGandEx();
        GetComponent<Animation>()["boxcampush"].speed = -1;
        GetComponent<Animation>()["boxcampush"].time = GetComponent<Animation>()["boxcampush"].length;
        GetComponent<Animation>().Play("boxcampush");

        box.GetComponent<Animation>()["boxopendoor"].speed = -1;
        box.GetComponent<Animation>()["boxopendoor"].time = box.GetComponent<Animation>()["boxopendoor"].length;
        box.GetComponent<Animation>().Play("boxopendoor");
    }
    void noopen()
    {
        showMsgbox("提示","没有开放!现在只开放'打开扩展包'");
    }
}
