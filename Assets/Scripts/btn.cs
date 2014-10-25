using UnityEngine;
using System.Collections;
/// <summary>
/// 所有界面按钮的行为
/// </summary>
public class btn : MonoBehaviour {
    //这个按钮的事件发送到什么地方
    public GameObject EventReceiver=null;
    //事件名
    public string EventName="OnClick";

    public bool Disable = false;
    GameObject mlight;
    // Use this for initialization
    void Start()
    {
        Transform t=transform.FindChild("light");
        if (t!=null)
        {
            mlight = t.gameObject;
        }
        
        if (Disable)
        {
            return;
        }
    }
    void OnMouseEnter()
    {
        if (Disable)
        {
            return;
        }
        if (mlight!=null)
        {
            mlight.SetActive(true);
        }
        

        if (animation!=null)
        {
            animation.Play("btnanim");
        }
    }
    void OnMouseExit()
    {
        if (Disable)
        {
            return;
        }
        if (mlight != null)
        {
            mlight.SetActive(false);
        }
    }
    //向上一级发送
    public bool sendtoparent = false;
    void OnMouseUpAsButton()
    {
        if (Disable)
        {
            return;
        }
        if (sendtoparent)
        {
            gameObject.transform.parent.SendMessage(EventName);
        }
        else if(EventReceiver==null)
        {
            gameObject.SendMessage(EventName);
        }
        else
        {
            EventReceiver.SendMessage(EventName);
        }
    }
    void OnClick() 
    {
        Debug.Log("空按钮函数");
    }
}
