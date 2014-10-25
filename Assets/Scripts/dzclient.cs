using UnityEngine;
using System.Collections;

public class dzclient : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Log("--debuginfo--");
        //开发用,随机出一个自己的职业
        int r;
        do 
        {
            r=Random.Range(1, 11);
        } while (r==6||r==10);//6 和10 是没有的.
        myclass = (CardClass)r;
        Log("随机出来的英雄是:"+myclass);
    }

    // Update is called once per frame
    void Update()
    {
    }
    string message;
    void OnGUI()
    {
        GUILayout.BeginScrollView(Vector2.zero, GUILayout.Width(200), GUILayout.Height(500));
        GUILayout.Box(message);
        
        if (GUILayout.Button("连接服务器"))
        {
            NetworkConnectionError err = Network.Connect("127.0.0.1", 9514);
            Log(err.ToString());
        }

        if (GUILayout.Button("开启服务器"))
        {
            Network.InitializeServer(1, 9514, false);
        }
        if (GUILayout.Button("回复水晶"))
        {
            Camera.main.SendMessage("restoreCost",1);
        }
        if (GUILayout.Button("增加水晶上限"))
        {
            Camera.main.SendMessage("addCostMax");
        }
        if (GUILayout.Button("抽牌"))
        {
            Camera.main.SendMessage("draw");
        }
        GUILayout.EndScrollView();
    }
    /************************************************************************/
    /* 公共事件,相互都有的事件,用于游戏相互交互                                                                     */
    /************************************************************************/

    [RPC]
    void OnHero(int c)
    {
        enemyclass = (CardClass)c;
        Log("对手的英雄是" + enemyclass);
        //如果是客户,向主机发送自己的英雄,

        if (Network.isClient)
        {
            networkView.RPC("OnHero", RPCMode.Server, (int)myclass);
        }
       

        //调用敌人英雄模型动画
        GameObject.Find("enemyhero").SendMessage("setclasss", enemyclass);
        //调用自己的英雄动画
        GameObject.Find("hero").SendMessage("setclasss", myclass);

        if (Network.isServer) //如果是服务器,那就计算谁是先手
        {
            whofirst();
        }
    }
    /************************************************************************/
    /*
     * 客户端部分用来处理自己是客户机的事件*/
    /************************************************************************/

    //连到了主机
    void OnConnectedToServer()
    {
        //向服务器发送自己的名字
        //sentMyName();
        Log("连上了主机,游戏开始!");
    }


    //
    void begin(bool frist)
    {
    }
    
    CardClass myclass,enemyclass;

    
   
    /************************************************************************/
    /* 服务器部分,用来处理自己是主机的事件                                  */
    /************************************************************************/
   
    //计算谁是先手,由服务器计算//可能会有bug 服务器先手比较多.
    void whofirst()
    {
        
        if (Random.Range(0f, 1f) > 0.5f)
        {
            //先
            transform.SendMessage("youfirst");
        }
        else
        {
            //后
            //向对方发送先手消息
            networkView.RPC("youfirst", RPCMode.Others);
        }
    }
    /// <summary>
    /// 当有客户连接上时,游戏开始,也是整个游戏的开始处
    /// </summary>
    /// <param name="player"></param>
    void OnPlayerConnected(NetworkPlayer player)
    {
        Log("有玩家接入,游戏开始!");
        //向客户发送自己的英雄
        networkView.RPC("OnHero", RPCMode.Others, (int)myclass);
    }
    /// <summary>
    /// 当服务器准备好时
    /// </summary>
    void OnServerInitialized()
    {
        Log("服务器初始成功!");
    }
   public void Log(string m)
    {
        message += m + "\n";
    }
}
