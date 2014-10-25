using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;


public struct set
    {
        public int id;
        public string name;
        public CardClass classs;
        public string cards;
    }

public struct playerInfo
{
    public string id;
    public string nickname;
    public int expack;
    public int gold;
    public float rmb;
    public string cards;
}
public enum shopType
{
    Pay,
    buy
}
public enum moneyType
{
    gold,
    rmb
}

/// <summary>
/// 和网站进行通信的类
/// </summary>
public class web : MonoBehaviour
{
    public static playerInfo player = new playerInfo();
    /// <summary>
    /// 购买卡包
    /// </summary>
    /// <param name="packnum"></param>
    /// <param name="moneynum"></param>
    /// <returns></returns>
    public static string buy(int packnum, float Money)
    {
        //对比金钱数量
        if(Money > player.gold)
        {
            return "失败:余额不足";
        }
        else
        {
            return webget("shop.php?id=" + player.id + "&type=buy&packnum=" + (player.expack + packnum) + "&moneytype=gold&moneynum=" + (player.gold - Money));
        }
    }
    public static void getPlayerInfo()
    {
        string str = webget("user.php?id=" + player.id);
        string[] s = str.Split('/');
        player.id = s[0];
        player.nickname = s[1];
        player.expack = int.Parse(s[2]);
        player.gold = int.Parse(s[3]);
        player.cards = s[4];
        player.rmb = 2000;

    }
    public static void delset(set i)
    {
        string r = webget("delset.php?id=" + i.id);
        if (r.IndexOf("失败")!=-1)
        {
            Debug.LogError(r);
        }
    }
    /// <summary>
    /// 拉取用户所有的卡组
    /// </summary>
    /// <returns></returns>
    public static List<set> getSets()
    {
        List<set> ret = new List<set>();
        string str = webget("getsets.php?playid=" + player.id);
        string[] sets = str.Replace("<br />", "@").Split('@');

        for (int x = 0; x < sets.Length;x++ )
        {
            if (sets[x]=="")
            {
                continue;
            }
            string[] setstr = sets[x].Split('&');
            set a = new set();
            a.id = int.Parse(setstr[0]);
            a.name = setstr[1];
            a.classs = (CardClass)Enum.Parse(typeof(CardClass),setstr[2]);
            a.cards = setstr[3];
            ret.Add(a);
        }
       
        return ret;
    }
    /// <summary>
    /// 得到用户的卡
    /// </summary>
    /// <returns></returns>
    public static List<card> getPlayCards()
    {
       
        
        string[] cardidtext= player.cards.Split('/');
        List<card> ret = new List<card>();
        foreach (string id in cardidtext)
        {
            
            if (id!="")
            {
                bool isin = false;
                for (int x = 0; x < ret.Count; x++)//是不是已经存在,如果存在就加1张
                {
                    if (ret[x].cardid == id)
                    {
                        card t = ret[x];
                        t.count++;
                        ret[x] = t;
                        isin = true;
                    }
                }
                if (!isin)
                {
                    ret.Add(getCardWithID(id));
                }
            }
        }
        
        return ret;
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="un"></param>
    /// <param name="pw"></param>
    /// <returns></returns>
    public static string login(string un, string pw)
    {
        string res = webget("login.php?name=" + un + "&password=" + pw);
        
        if (res.IndexOf("ok")!=-1)
        {
            string[] s = res.Split('/');
            player.id = s[1];
            player.nickname = s[2];
            player.expack = int.Parse(s[3]);
            player.gold = int.Parse(s[4]);
            player.rmb = 2000;
            for(int x=5;x<s.Length;x++)
            {
                player.cards += s[x] + "/";
            }
           
            
        }
       
        return res;
    }

	public static string ann()
	{
		string r = webget("announcements.php");

		return r;
	}

    public static string reg(string name, string pw, string mail, string nname)
    {
        //开始注册
       string r= webget("reg.php?name=" + name + "&password=" + pw + "&nickname=" + nname + "&email=" + mail);

       if (r.IndexOf("成功") != -1)
        {
            //重构返回信息,加上用户名密码
            r += ("\n用户名:" + name + "\n密码:" + pw);
        }
       return r;
    }
    static WWW www;
    const string webhost = "http://127.0.0.1/";
    
    public static void debug()
    {
      if (Application.isEditor)//如果是编辑器里!
      {
          login("ningxiaoxiao", "1q2w3e");
          loadxml();
      }
    }

    /// <summary>
    /// http  get 不用带上http://mylushi.net/
    /// </summary>
    /// <param name="t"></param>
    static string webget(string url)
    {
        //Debug.Log(webhost + url);
        long c = 0;
        WWW www = new WWW(webhost + url);
        
        while(!www.isDone)
        {
            c++;
            if (c==long.MaxValue)//防死锁
            {
                Debug.Log("失败!");
                return "失败:与服务器通信失败!";
            }
        }
        return www.text;
    }
    /// <summary>
    /// 得到系统公告
    /// </summary>
    public static string getNotice()
    {
        loadxml();
        return webget("gg.php");
    }
    
    /// <summary>
    /// 开包
    /// </summary>
    /// <returns></returns>
    public static List<card> openPack()
    {
        //基本卡
        List<card> excards = new List<card>();
        //传奇
        List<card> legendarycard = new List<card>();
        //史诗
        List<card> epiccard = new List<card>();
        //稀有
        List<card> rarecard = new List<card>();
        //用来返回的
        List<card> ret = new List<card>();

        foreach(card c in AllCards)
        {
            //过滤set不为3的牌
            if(c.set != CardSet.kexpert)
            {
                continue;
            }

            if(c.quality == CardQuality.klegendary)
            {
                legendarycard.Add(c);
            }
            else if(c.quality == CardQuality.kepic)
            {
                epiccard.Add(c);
            }
            else if(c.quality == CardQuality.krare)
            {
                rarecard.Add(c);
            }
            else
            {
                excards.Add(c);
            }
        }
       
        //前四张进程
        int r;
        for(int x = 0; x < 4; x++)
        {
            r = UnityEngine.Random.Range(0, 100);//0-99 共100个

            if(r == 88) //1%
            {
                //传奇
                int p = UnityEngine.Random.Range(0, legendarycard.Count);
                ret.Add(legendarycard[p]);
                legendarycard.RemoveAt(p);
            }
            else if(r==0 && r==1) //2%
            {
                //史诗
                int p = UnityEngine.Random.Range(0, epiccard.Count);
                ret.Add(epiccard[p]);
                epiccard.RemoveAt(p);
            }
            else if(11 <= r && r <= 20) //10%  //11-20 10个
            {
                //稀有
                int p = UnityEngine.Random.Range(0, rarecard.Count);
                ret.Add(rarecard[p]);
                rarecard.RemoveAt(p);
            }
            else //87%
            {
                //普通
                int p = UnityEngine.Random.Range(0, excards.Count);
                ret.Add(excards[p]);
                excards.RemoveAt(p);
            }
        }

        //最后一张卡的进程 必出稀有
        r = UnityEngine.Random.Range(1, 100);

        if(r == 88)//1%
        {
            //传奇
            int p = UnityEngine.Random.Range(0, legendarycard.Count);
            ret.Add(legendarycard[p]);
            legendarycard.RemoveAt(p);
        }
        else if(0 <= r && r <= 9) //10%
        {
            //史诗
            int p = UnityEngine.Random.Range(0, epiccard.Count);
            ret.Add(epiccard[p]);
            epiccard.RemoveAt(p);
        }
        else
        {
            //稀有
            int p = UnityEngine.Random.Range(0, rarecard.Count);
            ret.Add(rarecard[p]);
            rarecard.RemoveAt(p);
        }
        //向用户数据中写入这些卡 并减去1个包数
        string s="";
        foreach (card cc in ret)
        {
            s += cc.cardid + "/";
        }
        UpdatePlayerCard(s);
        return ret;
    }
    public static void UpdatePlayerCard(string s)
    {
       string ss= webget("updatacard.php?id=" + player.id + "&cards=" + s);
        if (ss.IndexOf("失败")!=-1)
        {
            Debug.LogError(ss);
            return;
        }
        player.expack--;
    }
    static List<card> AllCards;
    /// <summary>
    /// 载入xml
    /// </summary>
    static void loadxml()
    {
        AllCards = new List<card>();
        XmlDocument xml = new XmlDocument();
        //xml.Load(Application.dataPath + "\\card.xml");
		TextAsset cardsXml=(TextAsset)Resources.Load("card");
		xml.LoadXml (cardsXml.text);
        #region 读取卡数据

        foreach(XmlElement tcard in xml.DocumentElement.ChildNodes)
        {
           
            card a = new card();
            string imagename = tcard.SelectSingleNode("image").InnerText;
            Texture image = (Texture)Resources.Load("card/" + imagename);
            //建立卡图片的材质
            a.image = new Material(Shader.Find("Diffuse"));
            a.image.mainTexture = image;
            a.image.SetTextureScale("_MainTex", new Vector2(0.6f, 0.4f));
            a.image.SetTextureOffset("_MainTex", new Vector2(0.2f, 0.43f));

            a.cardid = tcard.Name;
            a.cnname = tcard.SelectSingleNode("cnname").InnerText;
            a.name = tcard.SelectSingleNode("name").InnerText;
            a.cndescription = tcard.SelectSingleNode("cndescription").InnerText;
            a.description = tcard.SelectSingleNode("description").InnerText;
            a.quality = (CardQuality)int.Parse(tcard.SelectSingleNode("quality").InnerText);
            a.set = (CardSet)int.Parse(tcard.SelectSingleNode("set").InnerText);
            a.type = (CardType)int.Parse(tcard.SelectSingleNode("type").InnerText);
            a.attack = tcard.SelectSingleNode("attack").InnerText;
            a.health = tcard.SelectSingleNode("health").InnerText;
            if (a.type == CardType.kweapon)//如果是武器卡,
            {
                a.health = tcard.SelectSingleNode("durability").InnerText;
            }
            a.cost = tcard.SelectSingleNode("cost").InnerText;
            a.count =1;
            string temp = tcard.SelectSingleNode("race").InnerText;

            if(temp == "")
            {
                temp = "0";
            }

            a.race = (CardRace)int.Parse(temp);
            temp = tcard.SelectSingleNode("classs").InnerText;

            if(temp == "")
            {
                temp = "0";
            }

            a.classs = (CardClass)int.Parse(temp);

            //跳过英雄与英雄技能卡
            if(a.type == CardType.kheroPower||a.type==CardType.khero)
            {
                continue;
            }

            AllCards.Add(a);
        }

        #endregion
    }
    /// <summary>
    /// 更新卡组信息,如果卡组id=-1 会插入新记录,并返回一个id.如果成功返回一个空文本
    /// </summary>
    /// <param name="s"></param>
    public static int updatSet(set s)
    {
        string ret= webget("updataset.php?id=" + s.id +
            "&playid=" + player.id +
            "&name="+s.name+
            "&classs="+s.classs+
            "&cards="+s.cards);
        
        if (ret=="")
        {
            return 0;
        } 
        else
        {
            return int.Parse(ret);
        }
       
    }
    public static card getCardWithID(string id)
    {
        foreach (card c in AllCards)
        {
            if (c.cardid==id)
            {
                return c;
            }
        }
        return new card();
    }


}
