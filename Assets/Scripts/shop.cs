using UnityEngine;
using System.Collections;
/// <summary>
/// 商店控制
/// </summary>
public class shop : MonoBehaviour {
    Transform pack1, pack2, pack7, pack15, pack40,buykuan;
    UILabel rmb;
	// Use this for initialization
	void Awake () {
        transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
	}

    void close()
    {
        animation["showbuy"].speed = -1;
        animation["showbuy"].time = animation["showbuy"].length;
        animation.Play("showbuy");
    }
    void show()
    {
        animation["showbuy"].speed = 1;
        animation.Play("showbuy");
    }
    int nowpacknum;
    float nowmoney;
    void showpack(int num)
    {
        if (pack1==null)
        {
            pack1 = transform.FindChild("1pack");
            pack2 = transform.FindChild("2pack");
            pack7 = transform.FindChild("7pack");
            pack15 = transform.FindChild("15pack");
            pack40 = transform.FindChild("40pack");
            rmb = transform.FindChild("buykuan").FindChild("text").FindChild("rmb").GetComponent<UILabel>();
        }
    
        switch (num)
        {
            case 1:
                nowpacknum = 1;
                pack1.gameObject.SetActive(true);
                pack2.gameObject.SetActive(false);
                pack7.gameObject.SetActive(false);
                pack15.gameObject.SetActive(false);
                pack40.gameObject.SetActive(false);
                nowmoney = 100;
                break;
            case 2:
                nowpacknum = 2;
                pack2.gameObject.SetActive(true);
                pack7.gameObject.SetActive(false);
                pack15.gameObject.SetActive(false);
                pack40.gameObject.SetActive(false);
                rmb.text = "￥2.99";
                nowmoney = 2.99f;
                break;
            case 7:
                nowpacknum = 7;
                pack7.gameObject.SetActive(true);
                pack15.gameObject.SetActive(false);
                pack40.gameObject.SetActive(false);
                rmb.text = "￥9.99";
                nowmoney = 9.99f;
                break;
            case 15:
                nowpacknum = 15;
                pack15.gameObject.SetActive(true);
                pack40.gameObject.SetActive(false);
                rmb.text = "￥19.99";
                nowmoney = 19.99f;
                break;
            case 40: pack40.gameObject.SetActive(true);
                nowpacknum = 40;
                rmb.text = "￥49.99";
                nowmoney = 49.99f;
                break;
        }
        Rotationbuykuan();
    }
    bool isrmb = false;
    void Rotationbuykuan()
    {
        if (buykuan==null)
        {
            buykuan = transform.FindChild("buykuan");
        }
        
        if (nowpacknum!=1&&!isrmb)
        {
            //转到钱
            buykuan.Rotate(new Vector3(0,0,180));
            isrmb = true;
        }
         if(nowpacknum==1&&isrmb)
        {
            //转到金子
            buykuan.Rotate(new Vector3(0, 0, 180));
            isrmb = false;
        }
    }
    /// <summary>
    /// 金币购买
    /// </summary>
    void goldbuy()
    {
        string res=web.buy(nowpacknum, nowmoney);
        if (res.IndexOf("成功")!=-1)//成功
        {
            web.getPlayerInfo();
            Camera.main.SendMessage("UpdateGandEx");
        }
        boxcam.msgbox.SendMessage("show",res);
    }
}
