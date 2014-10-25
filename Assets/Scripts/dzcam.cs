using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dzcam : MonoBehaviour
{
    //卡的预值
    public Transform minion, ability, weapon,costpre;
    dzclient client;
    // Use this for initialization
    void Start()
    {
        client = transform.GetComponent<dzclient>();
        dzban = GameObject.Find("dzban").transform;
        mHand = dzban;
        mycosttext = GameObject.Find("mycosttext").GetComponent<UILabel>();
        enemycosttext = GameObject.Find("enemycosttext").GetComponent<UILabel>();
        mycosttext.text = "0/0";
        enemycosttext.text = "0/0";
    }


    void banpick()
    {
        //
    }
    bool isfirst = false;
    /// <summary>
    /// 如果自己是服务器且是先手,是由dzclient sendmsg过来
    /// 如果自己是客户端且是后手,是由rpc用
    /// </summary>
    [RPC]
    void youfirst()
    {
        isfirst = true;
        client.Log("自己是先手!");
    }

    List<Transform> cs = new List<Transform>();
    AnimationClip moveto(Vector3 s, Vector3 e)
    {
        AnimationClip ret = new AnimationClip();
        ret.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, s.x, 1, e.x));
        ret.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, s.y, 1, e.y));
        ret.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, s.z, 1, e.z));
        return ret;
    }

    //第一次抽,hero发送过来
    IEnumerator firstdarw()
    {
        Vector3[] fpoint = new Vector3[4];
        fpoint[0] = new Vector3(-1.5f, 0.3314696f, 0.1293559f);
        fpoint[1] = new Vector3(-0.3332209f, 0.3314696f , 0.1293559f);
        fpoint[2] = new Vector3(0.8387426f, 0.3314696f , 0.1293559f);
        fpoint[3] = new Vector3(1.98422f, 0.3314696f , 0.1293559f);

        //不管怎么样都抽3张
        for(int x = 0; x < 3; x++)
        {
            Transform c = newcard();
            c.animation.AddClip(moveto(mycarddeap.position, fpoint[x]), "come");
            c.animation.Play("cardxuanzhuan");
            c.animation.Blend("come", 60);
            yield return new WaitForSeconds(0.5f);
            //加入到数组中
            cs.Add(c);
            //向对面发送
            networkView.RPC("enemydraw", RPCMode.Others);
        }

        //把硬币动画做出来
        if(isfirst)
        {
            GameObject.Find("luckycoin").SendMessage("first");
        }
        else
        {
            GameObject.Find("luckycoin").SendMessage("cost");
        }

        yield return new WaitForSeconds(2.5f);//等动画完成

        if(!isfirst)
        {
            //向对面发送
            networkView.RPC("enemydraw", RPCMode.Others);
            //再抽一张
            //实例第4张
            Transform c = newcard();
            c.animation.AddClip(moveto(mycarddeap.position, fpoint[3]), "come");
            c.animation.Play("cardxuanzhuan");
            c.animation.Blend("come", 60);
            yield return new WaitForSeconds(0.5f);

        }
        else
        {
            //应用itween
            //卡牌分开..mininum
            int x = 1;
            foreach ( Transform t in cs)
            {
                iTween.MoveBy(t.gameObject, Vector3.right * 0.3f*x, 1);
                x++;
            }
        }

        //出现标题与替换
        transform.FindChild("btandbtn").gameObject.SetActive(true);
    }
    //实例出一张
    Transform newcard()
    {
        Transform c = (Transform)Instantiate(minion, new Vector3(10, 10, 10), transform.rotation);
        
        c.parent = dzban;
        return c;
    }
    List<Transform> willban = new List<Transform>();
    void addban(Transform t)
    {
        if(!myradey)
        {
            willban.Add(t);
            client.Log("ban了一个牌");
        }
    }
    void subban(Transform t)
    {
        if(!myradey)
        {
            willban.Remove(t);
            client.Log("取消了一个牌");
        }
    }
    public Transform mycarddeap;

    IEnumerator replace()
    {
        
        client.Log("替换");

        for(int x = 0; x < willban.Count; x++)
        {
            Transform t = willban[x];
            Vector3 now = t.localPosition;

            AnimationClip back = moveto(now, mycarddeap.position);
            t.animation.AddClip(back,"back");
           
            //让转倒播
            t.animation["cardxuanzhuan"].speed = -1;
            t.animation["cardxuanzhuan"].time = 1;


            t.animation.Play("cardxuanzhuan");
            //混合播
            t.animation.Blend("back",60);

            yield return new WaitForSeconds(0.5f);


            AnimationClip come = moveto(mycarddeap.position, now);
            //实例一张
            Transform c = newcard();
            c.parent = dzban;
            c.animation.AddClip(come, "come");
            //倒播
            c.animation.Play("cardxuanzhuan");
            c.animation.Blend("come", 60);
            yield return new WaitForSeconds(0.5f);
            Destroy(t.gameObject);
        }

        //向对手发送已经ok
        myradey = true;
        networkView.RPC("banok", RPCMode.Others);

        if(myradey && enemyradey)
        {
            client.Log("双方都已经完成!");
            StartCoroutine(bancardgohand());
        }
    }
    bool myradey = false;
    bool enemyradey = false;
    [RPC]
    void banok()
    {
        enemyradey = true;

        if(myradey && enemyradey)
        {
            client.Log("双方都已经完成!");
            StartCoroutine(bancardgohand());
        }
    }
    /// <summary>
    /// 让替换的卡牌到手牌手牌区
    /// </summary>
    IEnumerator bancardgohand()
    {
        Debug.Log("bancardgohand");
       //不管你是先完成还是先完成replace的,都会到这里
     
        //让手牌到手牌区
        iTween.MoveTo(dzban.gameObject, new Vector3(0, 0, -2.66f), 0.5f);

        mHnadTarget = GameObject.Find("handt").transform;
       
        //一共共2个单位 分给所有人
        int x = 1;
        //间隔值
        float interval = 2.0f / dzban.childCount;
        float start = -1;

        foreach (Transform t in dzban.transform)
        {
            //进行排列
            Vector3 p = t.localPosition;
            p.x = start + x * interval;
            t.localPosition=p;
            //看向target
            t.LookAt(mHnadTarget);
            //修正
            t.Rotate(Vector3.up,180f);
            //旋转x轴,
            t.Rotate(Vector3.forward, -8f);

            t.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            x++;
        }
        //等待动画完成
        yield return new WaitForSeconds(0.5f);
        
        //幸运币消失,
        Transform l = GameObject.Find("luckycoin").transform;

        if (isfirst)
        {
            //先手
            myHero.SendMessage("setGameID", 1);
            enemyHero.SendMessage("setGameID", 2);

            //回合开始
            turnBegin();
        }
        else
        {//后手
            myHero.SendMessage("setGameID", 2);
            enemyHero.SendMessage("setGameID", 1);
            //Todo实例一张幸运币卡
            Transform lucky = (Transform)Instantiate(minion, l.position, Quaternion.identity);
            lucky.parent = mHand;
            lucky.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        
        Destroy(l.gameObject);
        clearUpHand();
        //把ban改为手牌
        dzban.name = "hand";
        //把英雄设为英雄类型
        myHero.SendMessage("setType", CardType.khero);
        
        //把英雄设为英雄类型
        enemyHero.SendMessage("setType", CardType.khero);

    }
    Transform dzban;
    Transform mHand;
    Transform mHnadTarget;
    /// <summary>
    /// 整理手牌,
    /// </summary>
    void clearUpHand()
    {
       // cardskin.isdrag = true;
        //一共共2个单位 分给所有人
        int x = 1;
        //间隔值
        float interval = 2.0f / dzban.childCount;
        float start = -1;
       
        foreach (Transform t in dzban.transform)
        {
            //进行排列
            Vector3 p = new Vector3(start+x * interval,0.3253887f,0.1255994f);
            p = mHand.TransformPoint(p);
            iTween.MoveTo(t.gameObject, p, 0.5f);
            iTween.ScaleTo(t.gameObject, Vector3.one * 0.7f, 0.2f);
            //看向target
            t.LookAt(mHnadTarget);
            //修正
            t.Rotate(Vector3.up, 180f);
            //旋转x轴,
            t.Rotate(Vector3.forward, -8f);
            
            
            x++;
        }
        //cardskin.isdrag = false;
  
    }
    public Transform enemyHero;
    public Transform enemyHeroPower;

    public Transform myHero;
    public Transform myHeroPower;
    void BroadcastCanattack()
    {
        //我方战场
        mybattlefield.BroadcastMessage("CanAttack",SendMessageOptions.DontRequireReceiver);
        //我方英雄
        myHero.SendMessage("CanAttack");
        //我方技能
       // myHeroPower.SendMessage("CanAttack");

        //对方战场
        enemybattlefield.BroadcastMessage("CanAttack", SendMessageOptions.DontRequireReceiver);
        //对方英雄
       // enemybattlefield.SendMessage("CanAttack");
        //对方技能
        // myHeroPower.SendMessage("CanAttack");


    }
    public static bool ismyturn = false;
    public GameObject youturntip;
    [RPC]
    void turnBegin()
    {
 
        //出现你的回合
        iTween.ScaleTo(youturntip, Vector3.one, 0.5f);
        iTween.ScaleTo(youturntip, iTween.Hash(
            "scale",Vector3.one*0.00001f,
            "time",0.5f,
            "delay",1f
            ));

        
        //结束回合向上
        GameObject.Find("dz").transform.FindChild("turn").SendMessage("myturn");

        ismyturn = true;
        draw();
        addCostMax();
        restoreCost();
    }
    public Transform enemycard;
    public Transform enemycarddeap;
    public Transform enemyHand;
    public Transform enemyHandtarget;
    [RPC]
    void enemydraw()
    {
        int x = 1;
        int childcount=enemyHand.childCount+1;
        //间隔值
        float interval = 2.0f / childcount;
        float start = -1;

        foreach (Transform t in enemyHand)
        {
            //进行排列
            Vector3 p = new Vector3(start + x * interval, 0, 0);
            p = enemyHand.TransformPoint(p);
            iTween.MoveTo(t.gameObject, p, 0.5f);


            x++;
        }

        //实例一张敌人卡
        Transform c = (Transform)Instantiate(enemycard, enemycarddeap.position, transform.rotation);
        c.Rotate(-90f, -90f, 0);

        Vector3 pp = new Vector3(start + x * interval, 0, 0);
        pp = enemyHand.TransformPoint(pp);

        iTween.MoveTo(c.gameObject, pp, 1f);
        c.parent = enemyHand;
        
        //看向target
        //c.LookAt(enemyHandtarget);
        iTween.RotateTo(c.gameObject, new Vector3(-45, 0, 0), 1f);
   
      



    }
    /// <summary>
    /// 抽牌
    /// </summary>
    void draw()
    {
        //向对面发送
        networkView.RPC("enemydraw", RPCMode.Others);

       // cardskin.isdrag = true;
       
        Transform c = (Transform)Instantiate(minion, mycarddeap.position, transform.rotation);
        c.parent = mHand;
        c.Rotate(-90f, -90f, 0);
        clearUpHand();
    }
 
    List<Transform> cost=new List<Transform>();
    int costMax;
    void restoreCost()
    {
        restoreCost(costMax - cost.Count);
    }
    void restoreCost(int num)
    {
        client.Log("回复水晶:" + num);
        //让所有向右移动0.182498
        foreach (Transform t in cost)
        {
            iTween.MoveBy(t.gameObject, Vector3.right * 0.182498f, 0.5f);
        }
        //实例水晶
        for (int x = 0; x < num; x++)
        {
            Transform c = (Transform)Instantiate(costpre);
            iTween.ShakeScale(c.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
            cost.Add(c);
        }
        //更新文本
        updataMyCostText();
    }
    void addCostMax()
    {
        if (costMax!=10)
        {
            costMax++;
            updataMyCostText();
        }
     
    }
    UILabel mycosttext,enemycosttext;
    void updataMyCostText()
    {
        mycosttext.text = cost.Count + "/" + costMax;
        //向对面发送
        networkView.RPC("costtext", RPCMode.Others, mycosttext.text);
    }
    [RPC]
    void costtext(string text)
    {
        enemycosttext.text = text;
    }
    public Transform minionmoder;
    public Transform mybattlefield;
    void playCard(Transform t)
    {
        foreach (Transform bc in mybattlefield)
        {
            iTween.MoveBy(bc.gameObject, Vector3.left * 0.4f, 0.1f);
        }

        t.parent = mybattlefield;
        //移动到位置上去
        //0.8   6.4
        //-3.2

        int count=mybattlefield.childCount+1;



        float length =  count* 0.8f;
        float offset = -length / 2;

        

        Vector3 startp=Vector3.zero;
        startp.x = offset + length / count;

        startp.x = -startp.x;
        Debug.Log(-startp.x);
        iTween.MoveTo(t.gameObject, iTween.Hash(
            "position", startp,
            "islocal", true, 
            "time", 0.2f,
            "oncomplete", "create",
            "oncompleteparams", t,
            "oncompletetarget",gameObject)
            );
        //向对方通告,
        networkView.RPC("enemypaly", RPCMode.Others, "id123");
        
    }
    public Transform enemybattlefield;
    [RPC]
    void enemypaly(string id)
    {
        foreach (Transform bc in enemybattlefield)
        {
            iTween.MoveBy(bc.gameObject, Vector3.left * 0.4f, 0.1f);
        }
        Transform t = enemyHand.GetChild(0);

        t.parent = enemybattlefield;
        //移动到位置上去
        //0.8   6.4
        //-3.2

        int count = enemybattlefield.childCount + 1;



        float length = count * 0.8f;
        float offset = -length / 2;



        Vector3 startp = Vector3.zero;
        startp.x = offset + length / count;

        startp.x = -startp.x;
        
        iTween.MoveTo(t.gameObject, iTween.Hash(
            "position", startp,
            "islocal", true,
            "time", 0.2f,
            "oncomplete", "create",
            "oncompleteparams", t,
            "oncompletetarget", gameObject)
            );
    }
    /// <summary>
    /// 新建一个仆从的模型.
    /// </summary>
    /// <param name="t"></param>
    void create(Transform t)
    {
        Transform mt = (Transform)Instantiate(minionmoder, t.position, mybattlefield.rotation); 
        mt.parent = t.parent;
        if (mt.parent==mybattlefield)
        {
            mt.SendMessage("setMine");
        }
        Destroy(t.gameObject);
        clearUpHand();
    }
    void endturn()
    {
        //广播可以行动
        BroadcastCanattack();
        //向对面发送开始
        networkView.RPC("turnBegin", RPCMode.Others);
        ismyturn = false;
    }
    void attack()
    {
        int attackid=getTransformId(dzminion.attacker.transform);
        int underatkid = getTransformId(dzminion.underattacker.transform);
        dzminion.attacker = null;
        networkView.RPC("underattack", RPCMode.Others, attackid, underatkid);
    }
    [RPC]
    void underattack(int attackid,int underatkid)
    {
        //填充2个值
        dzminion.attacker = getIdTransform(attackid).gameObject;
        dzminion.underattacker = getIdTransform(underatkid).gameObject;
        //调用攻击者的showain
        dzminion.attacker.SendMessage("showanim");
    }

    int getTransformId(Transform t)
    {
       return  t.GetComponent<dzminion>().gameID;
    }

    Transform getIdTransform(int id)
    {
        //已方战场

        foreach (Transform t in mybattlefield)
        {
            if (getTransformId(t)==id)
            {
                return t;
            }
        }

        //对方战场
        foreach (Transform t in enemybattlefield)
        {
            if (getTransformId(t) == id)
            {
                return t;
            }
        }
        //已方英雄
        if (getTransformId(myHero) == id)
        {
            return myHero;
        }
        //对方英雄
        if (getTransformId(enemyHero) == id)
        {
            return enemyHero;
        }
        //已方技能
        if (getTransformId(myHeroPower) == id)
        {
            return myHeroPower;
        }
        //对方技能
        if (getTransformId(enemyHeroPower) == id)
        {
            return enemyHeroPower;
        }
        return null;
    }

    public static int GameIdcount=1;

    void victory()
    {
        //出现胜利
    }
    void defeat()
    {
        //服务失败
    }
    void gotomenu()
    {

    }
    
}
