using UnityEngine;
using System.Collections;
/// <summary>
/// 用来显示在主菜单时的对话框
/// </summary>
public class boxMsgbox : MonoBehaviour {
    UILabel bt, text;
	// Use this for initialization
	void Start () {
        bt = transform.FindChild("bt").GetComponent<UILabel>();
        text = transform.FindChild("text").GetComponent<UILabel>();
        transform.localScale = Vector3.one * 0.00001f;
	}
	
	void show(string m)
    {
        if (m.IndexOf("/")==-1)
        {
            bt.text = "提示";
            text.text = m;
        } 
        else
        {
            string[] t = m.Split('/');
            bt.text = t[0];
            text.text = t[1];
        }
        

        iTween.ScaleTo(gameObject, Vector3.one * 0.277929f, 0.5f);
    }
    void close()
    {
        iTween.Stop(gameObject);
        iTween.ScaleTo(gameObject, Vector3.one * 0.00001f, 0.5f);
    }
    
}
