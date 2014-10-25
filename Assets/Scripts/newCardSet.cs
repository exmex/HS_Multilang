using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newCardSet : MonoBehaviour {
    public Transform cardsetpre;
    public static List<Transform> playersets=new List<Transform>();
	void Start () {
        //得到用户的卡组
        List<set> playset = web.getSets();
        foreach ( set s in playset)
        {
            addset(s);
        }
        playersets.Add(transform);
	}
	
	//选职业
	void OnMouseUpAsButton()
	{

	}
    //拉取用户自定义时用来加入按钮的
    void addset(set s)
    {
        Transform g = (Transform)Instantiate(cardsetpre, transform.position, transform.rotation);
        g.parent = transform.parent;
        g.SendMessage("setinfo", s);
        playersets.Add(g);
        transform.Translate(new Vector3(0, 0, -0.525f));
    }
    Vector3 lastpostion;
    void hide()
    {
        lastpostion = transform.localPosition;
        transform.Translate(new Vector3(0, 0, -20f));
    }
    void goback()
    {
        transform.localPosition = lastpostion;
    }
    void newcardset(CardClass c)
    {
        Transform g = (Transform)Instantiate(cardsetpre, transform.position, transform.rotation);
        g.parent = transform.parent;
        playersets.Insert(playersets.Count-1,g);//插入到最后一位
        transform.Translate(new Vector3(0, 0, -0.525f));
        set s = new set();
        s.id = -1;
        s.classs = c;
        g.SendMessage("Createnew", s);
    }

    
}
