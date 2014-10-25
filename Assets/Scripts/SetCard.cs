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
        animation["shownum"].speed = 1;
        animation.Play("shownum");
        
        info = i;
    }
    void subone()
    {
        animation["shownum"].speed = -1;
        animation["shownum"].time = animation["shownum"].length;
        animation.Play("shownum");
        
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

        transform.FindChild("pic").transform.FindChild("pic").renderer.material = info.image;
        transform.FindChild("cost").GetComponent<UILabel>().text = info.cost;
        
        if (info.cnname=="")
        {
            transform.FindChild("name").GetComponent<UILabel>().text = info.name;
        }
        else
        {
            transform.FindChild("name").GetComponent<UILabel>().text = info.cnname;
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
