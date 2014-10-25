using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 对我的收藏的页进行控制
/// </summary>
public class wdscpage : MonoBehaviour {


    //8张卡的位置
    public Transform[] card8postion;
    //3种卡预制
    public GameObject abilitypre, minionpre, weaponpre;

    //当前页
    int nowpage = 0;
    //用户的卡
   static List<card> playerscard = new List<card>();
    //当前显示的8张卡
    List<Transform> card8 = new List<Transform>();
    //职业过滤后的卡
    List<card> classcard = new List<card>();
    //花费过滤后的卡
    List<card> costcard = new List<card>();
    //当前的花费过滤
    string nowcost = "all";

    public UILabel pagename;
    void Awake()
    {
        //
        web.debug();
        // 得到用户的所有卡
        playerscard = web.getPlayCards();

    }
    /// <summary>
    /// 翻页
    /// 0初始 -1 上一页 1下一页
    /// </summary>
    /// <param name="pageflag"></param>
    void nextpage(int pageflag)
    {

        switch (pageflag)
        {
            case 0:
                {//初始显示

                }
                break;
            case -1:
                {//上一页
                    if (nowpage == 1)  //第1页,不能向上
                    {
                        return;
                    }
                }
                break;
            case 1:
                {//下一页
                    if (costcard.Count / 8.0 <= nowpage)  //最后1页,不能向下
                    {
                        return;
                    }
                }
                break;
        }


        /*
        if(costcard.Count / 8 == 0 && pageflag != 0)
        {
            return;
        }*/

        nowpage += pageflag;

        int strat = (nowpage - 1) * 8;

        if (strat < 0)
        {
            strat = 0;
        }

        int end = strat + 8;
        transform.FindChild("pagenum").GetComponent<UILabel>().text = "第" + nowpage + "页";

        if (end > costcard.Count) //对end的范围进行确认
        {
            end = costcard.Count;
        }

        DestroyCrad();
       

        for (int x = 0; strat < end; strat++, x++)
        {
            card a = costcard[strat];
          
            //取出点
            Vector3 l = card8postion[x].position;
            //实例化卡
            Transform go = transform;

            switch (a.type)
            {
                case CardType.kability:
                    {
                        go = (Transform)Instantiate(abilitypre.transform, l, abilitypre.transform.rotation);
                    }
                    break;

                case CardType.kminion:
                    {
                        go = (Transform)Instantiate(minionpre.transform, l, minionpre.transform.rotation);
                    }
                    break;

                case CardType.kweapon:
                    {
                        go = (Transform)Instantiate(weaponpre.transform, l, weaponpre.transform.rotation);
                    }
                    break;

            }
            card8.Add(go);
            go.parent = transform;
            //发送信息给它
            go.SendMessage("setinfo", a);
        }
    }
    public static card getcardwithid(string id)
    {
        foreach (card c in playerscard)
        {
            if (c.cardid == id)
            {
                return c;
            }
        }

        return new card();
    }
    /// <summary>
    /// 销毁8张牌
    /// </summary>
    void DestroyCrad()
    {
        foreach (Transform t in card8)
        {
            Destroy(t.gameObject);
        }

        card8.Clear();
    }
    //对职业进行过滤
    void onclass(CardClass c)
    {

        switch (c)
        {
            case CardClass.kwarrior: pagename.text = "战士";
                break;
            case CardClass.khunter: pagename.text = "猎人";
                break;
            case CardClass.kpaladin: pagename.text = "圣骑士";
                break;
            case CardClass.kdruid: pagename.text = "德鲁伊";
                break;
            case CardClass.krogue: pagename.text = "潜行者";
                break;
            case CardClass.kmage: pagename.text = "法师";
                break;
            case CardClass.kpriest: pagename.text = "牧师";
                break;
            case CardClass.kshama: pagename.text = "祭司萨满";
                break;
            case CardClass.kwarlock: pagename.text = "术士";
                break;
            case CardClass.kany: pagename.text = "中立";
                break;
        }
        classcard.Clear();

        foreach (card cin in playerscard)
        {
            if (cin.classs == c)
            {
                classcard.Add(cin);
            }
        }

        oncost(nowcost);
    }
    //对花费进行过滤
    void oncost(string mcost)
    {
        nowcost = mcost;
        costcard.Clear();

        if (mcost == "all")//如果是all 
        {
            foreach (card cin in classcard)
            {
                costcard.Add(cin);
            }
        }
        else
        {
            int intmcost = int.Parse(mcost);

            foreach (card cin in classcard)
            {
                int cardcost = int.Parse(cin.cost);

                if (intmcost == 7)
                {
                    if (cardcost >= intmcost)
                    {
                        costcard.Add(cin);
                    }
                }
                else
                {
                    if (cardcost == intmcost)
                    {
                        costcard.Add(cin);
                    }
                }
            }
        }

        if (costcard.Count == 0)
        {
            transform.FindChild("nojg").GetComponent<UILabel>().text = "没有查找结果";
        }
        else
        {
            transform.FindChild("nojg").GetComponent<UILabel>().text = "";
        }

        nowpage = 1;
        nextpage(0);
    }
    //////////////////////////////////////////////////////////////////////////
   
    
    

    //在更新卡的信息
    void updatecard(card c)
    {
		 //对显示的卡进行数量
        //在page中找到这张卡
		        Transform inpagecard = transform.FindChild(c.cardid);

        if (inpagecard != null)
        {
            inpagecard.SendMessage("upinfo", c);
        }
		
        //对总卡进行更新
        for (int x = 0; x < playerscard.Count; x++)
        {
            if (playerscard[x].cardid == c.cardid)
            {
                playerscard[x] = c;
            }
        }

        //对过滤后的卡进行更新

        for (int x = 0; x < costcard.Count; x++)
        {
            if (costcard[x].cardid == c.cardid)
            {
                costcard[x] = c;
            }
        }
       

    }
}
