using UnityEngine;
using System.Collections;
/// <summary>
/// 模式里用的卡组
/// </summary>
public class moshicardset : MonoBehaviour {
    //职业图片
    public Material zs, sm, dz, sq, lr, dly, ss, fs, ms;
    //职业logo
    public Material lzs, lsm, ldz, lsq, llr, ldly, lss, lfs, lms;

    set info;

    void setinfo(set i)
    {
        Transform clogo = transform.FindChild("classlogo");
        Transform cpic = transform.FindChild("cardsetdaiqi").FindChild("pic");
        UILabel namelabel = cpic.transform.parent.FindChild("name").GetComponent<UILabel>();
        namelabel.text = i.name;

        info = i;
        switch (info.classs)
        {
           

            case CardClass.kdruid:
                cpic.GetComponent<Renderer>().material = dly;
                clogo.GetComponent<Renderer>().material = ldly;
                break;

            case CardClass.khunter:
                cpic.GetComponent<Renderer>().material = lr;
                clogo.GetComponent<Renderer>().material = llr;
                break;

            case CardClass.kmage:
                cpic.GetComponent<Renderer>().material = fs;
                clogo.GetComponent<Renderer>().material = lfs;
                break;

            case CardClass.kpaladin:
                cpic.GetComponent<Renderer>().material = sq;
                clogo.GetComponent<Renderer>().material = lsq;
                break;

            case CardClass.kpriest:
                cpic.GetComponent<Renderer>().material = ms;
                clogo.GetComponent<Renderer>().material = lms;
                break;

            case CardClass.krogue:
                cpic.GetComponent<Renderer>().material = dz;
                clogo.GetComponent<Renderer>().material = ldz;
                break;

            case CardClass.kshama:
                cpic.GetComponent<Renderer>().material = sm;
                clogo.GetComponent<Renderer>().material = lsm;
                break;

            case CardClass.kwarlock:
                cpic.GetComponent<Renderer>().material = zs;
                clogo.GetComponent<Renderer>().material = lzs;
                break;

            case CardClass.kwarrior:
                cpic.GetComponent<Renderer>().material = ss;
                clogo.GetComponent<Renderer>().material = lss;
                break;
        }
    }
    public static set nowchoose;
    void OnMouseUpAsButton()
    {
        Material classpic = transform.FindChild("cardsetdaiqi").FindChild("pic").GetComponent<Renderer>().material;
        transform.root.SendMessage("setclass", info.classs);
        transform.root.SendMessage("setclasspic", classpic);
        transform.root.SendMessage("setClassname", info.name);
        nowchoose = info;
    }

}
