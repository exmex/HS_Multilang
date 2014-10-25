using UnityEngine;
using System.Collections;
/// <summary>
/// 用来过滤职业
/// </summary>
public class classfilter : MonoBehaviour {
    bool isup = false;
    
   static CardClass nowclass;
    CardClass myclass;
    Vector3 lastpostion=new Vector3();
   
	// Use this for initialization
	void Start () {
        switch (name)
        {
            case "sq": myclass = CardClass.kpaladin;
                break;
            case "dly": myclass = CardClass.kdruid;
                break;
            case "zs": myclass = CardClass.kwarrior;
                break;
            case "ss": myclass = CardClass.kwarlock;
                break;
            case "fs": myclass = CardClass.kmage; OnMouseUpAsButton();//显示第1个
                break;
            case "dz": myclass = CardClass.krogue;
                break;
            case "ms": myclass = CardClass.kpriest;
                break;
            case "lr": myclass = CardClass.khunter;
                break;
            case "sm": myclass = CardClass.kshama;
                break;
        }

	}
    void Update()
    {
        if (nowclass==myclass&&!isup)
        {
            //up
           
            iTween.MoveBy(gameObject, iTween.Hash("amount", Vector3.forward * 0.1f, 
                                                   "space",Space.World,
                                                   "time",0.1f));
            //变大
           // iTween.ScaleBy(gameObject, Vector3.one * 1.2f, 0.1f);
            isup = true;
        }
        if (nowclass != myclass && isup)
        {
            //down
            iTween.MoveBy(gameObject, iTween.Hash("amount", Vector3.forward * -0.1f,
                                                   "space", Space.World,
                                                   "time", 0.1f));
            //变 小
           // iTween.ScaleTo(gameObject, Vector3.one * 0.0254f, 0.1f);
            isup = false;
        }
    }
	
    void OnMouseUpAsButton()
    {
        
        if (!isup)
        {
            nowclass = myclass;
            transform.root.FindChild("page").SendMessage("onclass", myclass);
        }

     
    }
    void classdown(string sendname)
    {

       // nowup = sendname;
        if (sendname==name)
        {
            return;
        }


            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.05055332f); 
            isup = false;

    }
    void classfilterhide(CardClass c)
    {
       
        lastpostion = transform.localPosition;
        if (lastpostion != transform.localPosition)
        {
            Debug.Log(lastpostion);
        }
        
        if (myclass==CardClass.kany)
        {
            gototwo();
            return;
        }
        if (myclass!=c)
        {
            chide();
        }
        else
        {
            gotoone();
        }
    }
    void chide()
    {
        transform.Translate(Vector3.forward * 10, Space.World);
    }
    void gototwo()
    {
        transform.localPosition=   new Vector3(-1.594784f, transform.localPosition.y, transform.localPosition.z);
            
    }
    void gotoone()
    {
        
        
         transform.localPosition=   new Vector3(-2.006191f, transform.localPosition.y, transform.localPosition.z);
        OnMouseUpAsButton();
    }
    void gotoback()
    {
      
        
        transform.localPosition = new Vector3(lastpostion.x, 0.07995506f, 0.05055332f);
        if (nowclass==myclass)
        {
            isup = false;
            OnMouseUpAsButton();
        }
        
    }
}
