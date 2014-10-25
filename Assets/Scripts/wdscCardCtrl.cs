using UnityEngine;
using System.Collections;
/// <summary>
/// 用来控制我的收藏时,卡牌的行为
/// </summary>
public enum wdscmMod
{
    look,
    editset
}
public class wdscCardCtrl : MonoBehaviour {
   

    card info;
    UILabel num,suotxt;
    Transform suo;

    void Awake()
    {
        suo = transform.FindChild("suo");
        suotxt = suo.FindChild("name").GetComponent<UILabel>();
        num = transform.FindChild("num").GetComponent<UILabel>();
    }
	// Update is called once per frame
	void setinfo (card i) {
        info = i;
        //更新数量
        updateNumtext();
	}
    void OnMouseUpAsButton()
    {
        switch (wdscjm.nowMod)
        {
            case wdscmMod.look:
                //查看模式
                break;
            case wdscmMod.editset:
                //编辑模式
                if (!suo.gameObject.activeSelf)//如果没有锁上
                {
                    //向当前编辑set发送加一张牌
                    cardset.nowEditingSet.SendMessage("addcard", info);
                }
                
                break;
        }
    }
    void updateNumtext()
    {
        num.text = "x" + info.count;
        if (info.count==0)
        {
            suo.gameObject.SetActive(true);
            suotxt.text = "用完了";
            num.gameObject.SetActive(false);
        }
        else
        {
            if (info.insetcount == 2)
            {
                suo.gameObject.SetActive(true);
                suotxt.text = "套牌限制";
                num.gameObject.SetActive(false);
            }
            else
            {
                suo.gameObject.SetActive(false);
                num.gameObject.SetActive(true);
            }
        }
    }
	void upinfo(card c)
	{
		info=c;
		updateNumtext();
	}
}
