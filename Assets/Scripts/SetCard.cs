using UnityEngine;
using System.Collections;
/// <summary>
/// 卡组中的牌的模型
/// </summary>
public class SetCard : MonoBehaviour {
  	
    void OnMouseUpAsButton()
    {
        subone();
    }
    void addone(card i)
    {
        GetComponent<Animation>()["shownum"].speed = 1;
        GetComponent<Animation>().Play("shownum");
        
        info = i;
    }
    void subone()
    {
        GetComponent<Animation>()["shownum"].speed = -1;
        GetComponent<Animation>()["shownum"].time = GetComponent<Animation>()["shownum"].length;
        GetComponent<Animation>().Play("shownum");
        
        //更新info的信息
        info.insetcount--;
        info.count++;

        //向父发送
        transform.parent.SendMessage("subcard",info);
    }
    public card info;
    void setinfo( card i)//只有1次
    {
        info = i;

        transform.Find("pic").transform.Find("pic").GetComponent<Renderer>().material = info.image;
        transform.Find("cost").GetComponent<UILabel>().text = info.cost;
        
        if (info.cnname=="")
        {
            transform.Find("name").GetComponent<UILabel>().text = info.name;
        }
        else
        {
            transform.Find("name").GetComponent<UILabel>().text = info.cnname;
        }
        name = i.cardid;
        
    }
	void setcardcls()
	{
		int p=info.insetcount;
		for(int x=0;x<p;x++)
		{
			subone();
		}
	}

}
