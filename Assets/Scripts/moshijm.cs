using UnityEngine;
using System.Collections;
using System.Collections.Generic;
enum moshijmmethod
{
    knewset,
    dz,
    lx,
    jj
}
/// <summary>
/// 模式界面主控制
/// </summary>
public class moshijm : MonoBehaviour {
    moshijmmethod nowMethod;
    UILabel bt, tpm, MosName;
    Vector3 goodp = new Vector3(-0.6957181f, 2.428539f, 0.5254142f);
	// Use this for initialization
	void Start () {
        bt = transform.FindChild("bt").GetComponent<UILabel>();
        tpm=transform.FindChild("tpm").GetComponent<UILabel>();
		MosName=transform.FindChild("name").GetComponent<UILabel>();
	}
#region 从英雄点击发送而来
    CardClass chooseClass;
    void setclass(CardClass c)
    {
        chooseClass = c;
    }
    public UILabel chooseclassname;
    void setClassname(string n)
    {
        chooseclassname.text = n;
    }
    public GameObject classpic;
   void setclasspic(Material pic)
    {
        classpic.transform.parent.gameObject.SetActive(true);
        classpic.renderer.material = pic;
    }
#endregion


   void Onjbtp()
   {
       tpm.GetComponent<UILabel>().text = "基本套牌";

       transform.animation["jbtpshow"].speed = 1;
       transform.animation.Play("jbtpshow");
   }

    void Onzdytp()
    {
        tpm.GetComponent<UILabel>().text = "自定义套牌";
        transform.animation["jbtpshow"].speed = -1;
        transform.animation["jbtpshow"].time = transform.animation["jbtpshow"].length;
        transform.animation.Play("jbtpshow");
    }

    void nochoose()
    {
        chooseclassname.text = "";
        classpic.transform.parent.gameObject.SetActive(false);
    }
    Vector3 jbtppostion = new Vector3(-1.037413f, -0.004264796f, 0.002689363f);
    public GameObject jbtpbtn, zdytpbtn;
    void newset()
    {
        jbtpbtn.transform.Rotate(180,0,0);
        jbtpbtn.transform.Rotate(0,0,0); 
        transform.FindChild("jbtp").localPosition = jbtppostion;
        iTween.MoveTo(gameObject, goodp, 1);
        nowMethod = moshijmmethod.knewset;
        nochoose();
        bt.text = "选择英雄";
        tpm.text = "";
		MosName.text = "新建套牌";
    }
    void dzmoshi()
    {
        jbtpbtn.transform.Rotate(0, 0, 0);
        jbtpbtn.transform.Rotate(0, 0, 0);
        transform.position = goodp;
        nowMethod = moshijmmethod.lx;
        Camera.main.SendMessage("push");

        nochoose();
        bt.text = "选择套牌";
        tpm.text = "自定义套牌";
		MosName.text = "对战模式";
        getPlayerSet();
    }
    void lxmoshi()
    {
        jbtpbtn.transform.Rotate(0, 0, 0);
        jbtpbtn.transform.Rotate(0, 0, 0);
        transform.position = goodp;
        nowMethod = moshijmmethod.lx;
        Camera.main.SendMessage("push");

        nochoose();
        bt.text = "选择套牌";
        tpm.text = "自定义套牌";
		MosName.text = "练习模式";
        getPlayerSet();
    }
    List<set> sets = new List<set>();
    
    void getPlayerSet()
    {
        sets = web.getSets();
       //先让卡组不显示
        for (int x = 1; x < 10;x++ )
        {
            Transform t = transform.FindChild(x.ToString());
            t.gameObject.SetActive(false);
        }

        //让卡组模型显示
        int p = 1;
        foreach (set s in sets)
        {
            Transform t = transform.FindChild(p.ToString());
            t.gameObject.SetActive(true);
            t.SendMessage("setinfo", s);
            p++;
        }
    }
    void jjmoshi()
    {
        nochoose();
        bt.text = "选择套牌";
        tpm.text = "自定义套牌";
		MosName.text = "竞技模式";
    }
    void gotoback()
    {
 
        
        switch (nowMethod)
        {
            case moshijmmethod.knewset:
                {
                    iTween.MoveBy(gameObject, Vector3.left * 15f, 1);
                }
                break;
                default:
                Camera.main.SendMessage("back");
                iTween.MoveBy(gameObject, iTween.Hash(iT.MoveBy.amount, Vector3.down * 10, iT.MoveBy.time, 0.1f, iT.MoveBy.delay, 1));
                break;

        }
    }
    public GameObject newsetbtn;
    void chooseok()
    {
        switch (nowMethod)
        {
            case moshijmmethod.knewset:
                {
                    iTween.MoveBy(gameObject, Vector3.left * 15f, 1);
                    newsetbtn.SendMessage("newcardset", chooseClass);//向newsetbtn发送
                }
                break;
            case moshijmmethod.lx:

                break;
            case moshijmmethod.dz:
                //开始查找
                break;
        }
    }
}
