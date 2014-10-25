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
                cpic.renderer.material = dly;
                clogo.renderer.material = ldly;
                break;

            case CardClass.khunter:
                cpic.renderer.material = lr;
                clogo.renderer.material = llr;
                break;

            case CardClass.kmage:
                cpic.renderer.material = fs;
                clogo.renderer.material = lfs;
                break;

            case CardClass.kpaladin:
                cpic.renderer.material = sq;
                clogo.renderer.material = lsq;
                break;

            case CardClass.kpriest:
                cpic.renderer.material = ms;
                clogo.renderer.material = lms;
                break;

            case CardClass.krogue:
                cpic.renderer.material = dz;
                clogo.renderer.material = ldz;
                break;

            case CardClass.kshama:
                cpic.renderer.material = sm;
                clogo.renderer.material = lsm;
                break;

            case CardClass.kwarlock:
                cpic.renderer.material = zs;
                clogo.renderer.material = lzs;
                break;

            case CardClass.kwarrior:
                cpic.renderer.material = ss;
                clogo.renderer.material = lss;
                break;
        }
    }
    public static set nowchoose;
    void OnMouseUpAsButton()
    {
        Material classpic = transform.FindChild("cardsetdaiqi").FindChild("pic").renderer.material;
        transform.root.SendMessage("setclass", info.classs);
        transform.root.SendMessage("setclasspic", classpic);
        transform.root.SendMessage("setClassname", info.name);
        nowchoose = info;
    }

}
