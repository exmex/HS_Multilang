using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

/// <summary>
/// 卡牌的结构体
/// </summary>
public struct card
{
    public Material image;
    public string cardid;
    public string cnname ;
    public string name;
    public string cndescription;
    public string description;
    public CardQuality quality;
    public CardSet set;
    public CardType type;
    public CardRace race;
    public CardClass classs;
    public string attack;
    public string health;
    public string cost;
    /// <summary>
    /// 有几张
    /// </summary>
    public int count;
    public int insetcount;
}

//职业
public enum CardClass
{
    kany,
    kwarrior = 1, //ZZ
    kpaladin = 2,//SQ
    khunter = 3, //LR
    krogue = 4,//SQ
    kpriest = 5,//MS
    kshama = 7,//SM
    kmage = 8,//DZ
    kwarlock = 9,//SS
    kdruid = 11,//DLY
};

public enum CardType
{
    kability = 5,//法术卡
    khero = 3,//英雄卡
    kheroPower = 10,//英雄技能卡
    kminion = 4,//仆从卡
    kweapon = 7//武器卡
};

public enum CardRace
{
    knone,
    kbeast = 20,//野兽
    kdemon = 15,//妖
    kdragon = 24,//龙
    kmurloc = 14,//鱼人
    kpirate = 23,//海盗
    ktotem = 21//图腾

};

public enum CardQuality
{
    kfree,//免费
    kcommon,//常见
    krare = 3,//罕见
    kepic,//史诗
    klegendary//传说
};
public enum CardSet
{
    kbasic = 2,//基本
    kexpert,//专家
    kreward,//奖励
    kmissions//任务
};

/// <summary>
/// 我的收藏行为
/// </summary>
public class wdscjm : MonoBehaviour
{
    public static wdscmMod nowMod;

    Vector3 showpostion = new Vector3(-1.532529f, 1.805149f, 0.860475f);
    void Start()
    {

    }
    void editset()
    {
        //让返回变完成

       
        
        

        //可加入卡牌
        nowMod = wdscmMod.editset;

       
 
    }
    void endeditset()
    {
		cardset.nowEditingSet.transform.parent.BroadcastMessage("goback");
        //职业标签 回来
        transform.root.FindChild("classfilter").BroadcastMessage("gotoback");

        //不可加入卡牌
        nowMod = wdscmMod.look;

        

    }
    void back()
    {
        switch (nowMod)
        {
            case wdscmMod.editset: endeditset();
                break;
            case wdscmMod.look: 
                Camera.main.SendMessage("back");
                iTween.MoveBy(gameObject, iTween.Hash(iT.MoveBy.amount,Vector3.down*10,iT.MoveBy.time,0.1f,iT.MoveBy.delay,1));
                break;
        }
    }
   void show()
    {
        
        transform.position = showpostion;
        Camera.main.SendMessage("push");
    }
   
   


    /*
   void updataeditinginfo(set n)
   {
       addon = true;

       if( n.id == "-1")//如果是新建立的卡组
       {
           editinginfo = n;
           return;
       }

       foreach(set s in zdysets)//在已有的卡组中寻找
           {
               if(s.id == n.id)
               {
                   editinginfo = s;
               }
           }

       //加入这组卡中的所有的卡;
       //分解卡
       string[] idandnum = editinginfo.cards.Split('/');

       foreach(string t in idandnum)
       {
           if(t != "")
           {
               string[] ian = t.Split('*');
               string id = ian[0];
               string num = ian[1];
               card a = getcardwithid(id);

               for(int x = 0; x < int.Parse(num); x++)
               {
                   addcard(a);
                   a.count--;
               }

               updatacards(a);
           }
       }
   }

   set editinginfo;

   void writeset()
   {
       transform.FindChild("classfilter").BroadcastMessage("gotoback",editinginfo.classs);
       addon = false;
        
       string str = getsetstr(); //得到卡组
       //清掉
       setcardcls();
       //让字清掉
       transform.FindChild("cardcount").GetComponent<UILabel>().text = "";
       if(editinginfo.classs == CardClass.kany)
       {
           Debug.LogError("写时出现any职业!");
       }

       if(str != editinginfo.cards) //有改变才写
       {

       }

       //更新
       editinginfo.cards = str;

       for(int x = 0; x < zdysets.Count; x++)
       {
           if(zdysets[x].id == editinginfo.id)
           {
               zdysets[x] = editinginfo;
           }
       }
       if (zdysets.Count == 0)
       {
           zdysets.Add(editinginfo);
       }
       //让字变加返回
       GameObject.Find("wdscfh").transform.FindChild("fhlabel").GetComponent<UILabel>().text = "返回";
        
       //让别的卡组都回来按钮回来
       transform.FindChild("setbutton").BroadcastMessage("goback");
   }
   void setcardcls()
   {
       for (int x = 0; x < setcards.Count; x++)
       {
           Transform t =setcards[x];

           Transform jzscard = transform.FindChild("jz").FindChild(t.name);
            
           if (jzscard != null)//调用卡的加
           {
               jzscard.SendMessage("add");
           }
           else//在总数中让这张卡加1
           {
               card ctemp = getcardwithid(t.name);
               ctemp.count++;
               updatacards(ctemp);
           }
           if (t.GetComponent<newsetcard>().count == 2)
           {
               if (jzscard != null)//调用卡的加
               {
                   jzscard.SendMessage("add");
               }
               else//在总数中让这张卡加1
               {
                   card ctemp = getcardwithid(t.name);
                   ctemp.count++;
                   updatacards(ctemp);
               }
           }
           Destroy(t.gameObject);

       }
       setcards.Clear();
   }
   string getsetstr()
   {
       string a = "";

       foreach(Transform t in setcards)
       {
           a += t.name;
           a = a + "*" + t.GetComponent<newsetcard>().count.ToString() + "/";
       }

       return a;
   }
   */
}
