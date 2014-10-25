using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cardset : MonoBehaviour {
    set info;
    public Material zs, dz, dly, lr, ms, sq, sm, fs, ss;
    bool Editing = false;
    //当前正在编辑的
    public static GameObject nowEditingSet;

   
    //统计信息
    Transform infokuan;
    int[] costcount = new int[7];
    Transform del;

	void Awake () {
        del = transform.FindChild("del");
        
	}
  
	

    void OnMouseUpAsButton()
    {
        if (Editing)
        {
            return;
        }
        goup();
        
        nowEditingSet=gameObject;
        edit();
        transform.root.SendMessage("editset");
        transform.parent.BroadcastMessage("hide");
        transform.root.FindChild("classfilter").BroadcastMessage("classfilterhide", info.classs);
        
        
    }
    void setinfo(set s)
    {
        info = s;
        if (s.id == -1)
        {
            s.name = "新建套牌";
        }
        setname(s.name);
        switch (s.classs)
        {

            case CardClass.kdruid:
                setpic(dly);
                break;

            case CardClass.khunter:
                setpic(lr);
                break;

            case CardClass.kmage:
                setpic(fs);
                break;

            case CardClass.kpaladin:
                setpic(sq);
                break;

            case CardClass.kpriest:
                setpic(ms);
                break;

            case CardClass.krogue:
                setpic(dz);
                break;

            case CardClass.kshama:
                setpic(sm);
                break;

            case CardClass.kwarlock:
                setpic(ss);
                break;

            case CardClass.kwarrior:
                setpic(zs);
                break;
        }

    }
    void setclass(CardClass c)
    {
        info.classs = c;
    }
   
    void Createnew(set s)
    {
        setinfo(s);
        OnMouseUpAsButton();
    }
    void setname(string n)
    {
        info.name = n;
        transform.FindChild("name").FindChild("Label").GetComponent<UILabel>().text=n;
        name = n;
    }
    void setpic(Material m)
    {
        transform.FindChild("pic").renderer.material = m;
    }
    Vector3 lastpostion;
    Vector3 uppostion = new Vector3(2.313244f, 2.465511f, 2.985396f);
    void goup()
    {
        lastpostion = transform.localPosition;
        transform.position = uppostion;
        Editing = true;
        infokuan = transform.root.FindChild("setinfo");
    }
    void hide()
    {
        if (Editing)
        {
            return;
        }
        lastpostion = transform.localPosition;
        transform.Translate(new Vector3(0, 0, -20f));
    }
    void goback()
    {
        transform.localPosition = lastpostion;
        Editing = false;
        if (nowEditingSet==gameObject)
        {
            cls();
        }
    }
     
    void OnMouseEnter()
    {
        if (Editing)
        {
          
            infokuan.gameObject.SetActive(true);
        }
        else
        {

            del.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        /*
        if (!Editing&&!isindel&&isexit)
        {
            
            isexit = false;
        }*/
    }
    void OnMouseExit()
    {
        if (Editing)
        {
            infokuan.gameObject.SetActive(false);
            
        }
        else
        {

            del.SendMessage("hide",SendMessageOptions.DontRequireReceiver);
        }
 
    }
    void edit()
    {
        
        if (info.cards==null)
        {
            return;
        }

        //拆箱
        string[] cs = info.cards.Split('/');
        foreach (string s in cs)
        {
            Debug.Log("将要拆箱的:"+s);
            if (s!="")
            {
              string[] idandnum=  s.Split('*');
              card tc= wdscpage.getcardwithid(idandnum[0]);
                Debug.Log("拆箱后得到的结果:"+tc.cardid+"*"+tc.insetcount+"*"+tc.count);
              	
                for(int x=0;x<int.Parse(idandnum[1]);x++)
                {
                    addcard(tc);
                    tc.insetcount++;
                    tc.count--;
                }
            }
        }
        
    }
    //把卡清掉
    void cls()
    {
        string cardstext = "";
           foreach (Transform t in setcards)
           {
             
               card c = t.GetComponent<SetCard>().info;
               //装箱
               cardstext += c.cardid + "*" + c.insetcount + "/";//进行记录              
           }

           
       
        if (cardstext!=info.cards)
        {
            info.cards = cardstext;
            int retid= web.updatSet(info);
            
            if (info.id==-1)//如果卡组的id=-1,那就是新建立的.把返回过来的id给它
            {
                info.id = retid;
            }
        }
		//广播方法 setcardcls
		gameObject.BroadcastMessage("setcardcls",SendMessageOptions.DontRequireReceiver);
        setcards.Clear();
        updatacardcount("");
    }
    //删除
    
    void ondel()
    {
        //填充数据
        yesnomsgbox.callbackgameobject = gameObject;
        yesnomsgbox.callbackeventname = "delyesorno";
        //显示确认取消框
        boxcam.ynmsgbox.SendMessage("show", "你确认删除嘛?这个操作不可逆!");

    }
    void delyesorno(bool yorn)
    {
        if (yorn)
        {
            //删除
            web.delset(info);
            //把别的向上移动
            int p = newCardSet.playersets.IndexOf(transform);
            Debug.Log(p);
            for (; p < newCardSet.playersets.Count;p++ )
            {
                newCardSet.playersets[p].Translate(new Vector3(0, 0, 0.525f));
            }
            newCardSet.playersets.Remove(transform);
            Destroy(gameObject);

        } 
        else
        {
            //不
        }
    }
    void realdel()
    {

    }
    //卡组中的卡
    List<Transform> setcards = new List<Transform>();
    //卡组中卡的模型
    public Transform setcardmodel;
    Transform page;
    void updatecard(card c)
    {
        if (page==null)
        {
            page = transform.root.FindChild("page");
        }
        page.SendMessage("updatecard", c);
    }

    //减去一张卡
    void subcard(card c)
    {
 
       if (c.insetcount<=0)//删除
       {
           foreach (Transform t in setcards)
           {
               if (t.name==c.cardid)
               {
                   int p = setcards.IndexOf(t);
                    setcardup(p);
                    setcards.Remove(t);
                    Destroy(t.gameObject);
                    break;
               }
           }
       }
       //向page更新这张卡的信息
       updatecard(c);
       updatacardcount();
    }
    Vector3 startpostion = new Vector3(-0.007081032f, -0.1669452f, -0.3663702f);
    //加一张卡
    void addcard(card c)
    {
        //如果已经满了
        if (getcardcount()=="30/30")
        {
            //不加,
            return;
        }
        c.insetcount++;
        c.count--;
        if (isinset(c.cardid)) //有
        {
            transform.FindChild(c.cardid).SendMessage("addone",c);
        }
        else
        {
            //根据消费来定插入位置
           
            int p = indexofset(int.Parse(c.cost));
            //实例化一个
            Transform go;
            
            if (setcards.Count == 0)
            {
                go = (Transform)Instantiate(setcardmodel, startpostion, transform.rotation);
                go.parent = transform;
                go.localPosition = startpostion;
            }
            else if (p == setcards.Count)
            {
                go = (Transform)Instantiate(setcardmodel, setcards[p - 1].position, setcards[p - 1].rotation);
                go.Translate(Vector3.back * 0.15f * 1.290421f);
            }
            else
            {
                go = (Transform)Instantiate(setcardmodel, setcards[p].position, setcards[p].rotation);
            }

            go.parent = transform;
            
            go.SendMessage("setinfo", c);
            setcarddown(p);
            setcards.Insert(p, go);
        }
        updatacardcount();
        //向page更新这张卡的信息
        updatecard(c);
        //更新统计信息

    }
   
    //查找一张卡在不在卡组中
    bool isinset(string n)
    {
        foreach (Transform t in setcards)
        {
            if (t.name == n)
            {
                return true;
            }
        }

        return false;
    }

    UILabel cardcount;
    void updatacardcount(string t)
    {
        if (cardcount==null)
        {
            cardcount = transform.root.FindChild("cardcount").GetComponent<UILabel>();
        }
        cardcount.text = t;
    }
    string getcardcount()
    {
        if (cardcount == null)
        {
            return null;
        }
        else
        {
            return cardcount.text;
        }
    }
    void updatacardcount()
    {
        int count = 0;
        costcount=new int[7]{0,0,0,0,0,0,0};

        foreach (Transform t in setcards)
        {
            card c = t.GetComponent<SetCard>().info;
            count = count + c.insetcount;
            //更新统计信息
            int cost=int.Parse(c.cost);
            if (cost<=7)
            {
                costcount[cost] += c.insetcount;
            } 
            else
            {
                costcount[6] += c.insetcount;
            }
        }

        updatacardcount( count + "/30");
        //更新统计信息
        updateCostCount();

    }
    void updateCostCount()
    {
        float max=0;
        //得到最大值
        foreach ( int k in costcount)
        {
            if (k>max)
            {
                max = k;
            }
        }

        for (int x = 0; x <7;x++ )
        {
            infokuan.FindChild(x.ToString()).GetComponent<UILabel>().text = costcount[x].ToString();
            //得到条形
            Transform t = infokuan.FindChild("c" + x);

            float y = costcount[x] / max;//NaN测试
            if (float.IsNaN(y))
            {
                y = 0;
            }
            t.localScale = new Vector3(1, y, 1);
        }
    }
    int indexofset(int cost)
    {
        int ret = 0;

        foreach (Transform t in setcards)
        {
            int cardcost = int.Parse(t.transform.FindChild("cost").GetComponent<UILabel>().text);

            if (cardcost > cost)
            {
                return ret;
            }

            ret++;
        }
        return ret;
    }

    void setcarddown(int p)
    {
        for (; p < setcards.Count; p++)
        {
            setcards[p].Translate(Vector3.back * 0.15f * 1.290421f);
            //iTween.MoveBy(setcards[p].gameObject, Vector3.back * 0.15f, 0.1f);
        }
    }
    void setcardup(int p)
    {
        for (; p < setcards.Count; p++)
        {
            setcards[p].Translate(Vector3.forward * 0.15f * 1.290421f);
            //iTween.MoveBy(setcards[p].gameObject, Vector3.forward * 0.15f, 0.1f);
        }
    }
}
