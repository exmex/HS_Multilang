using UnityEngine;
using System.Collections;
/// <summary>
/// 用来显示卡的皮肤
/// </summary>
public class cardskin : MonoBehaviour
{
    public Material hero, azs, ams, adly, asq, afs, alr, asm, ass, adz;
    public Material mzs, mms, mzl, mdly, msq, mfs, mlr, msm, mss, mdz;
    public Material common, rare, epic, legendary;
    Renderer front, frontkuan, quality;
    card skininfo;


    void setinfo(card i)
    {
        front = transform.FindChild("front").renderer;
        frontkuan = transform.FindChild("frontkuan").renderer;
        quality = transform.FindChild("quality").renderer;


        skininfo = i;
        name = skininfo.cardid;
        transform.FindChild("pic").renderer.material = skininfo.image;
        if (skininfo.cnname=="")
        {
            transform.FindChild("name").GetComponent<UILabel>().text = skininfo.name;
        } 
        else
        {
            transform.FindChild("name").GetComponent<UILabel>().text = skininfo.cnname;
        }
        transform.FindChild("cost").GetComponent<UILabel>().text = skininfo.cost;
        

        if (skininfo.cndescription=="")
        {
            transform.FindChild("description").FindChild("description").GetComponent<UILabel>().text = skininfo.description;
        } 
        else
        {
            transform.FindChild("description").FindChild("description").GetComponent<UILabel>().text = skininfo.cndescription;
        }
        if (skininfo.type != CardType.kability)//如果不是技能卡
        {
            transform.FindChild("attack").GetComponent<UILabel>().text = skininfo.attack;
            transform.FindChild("health").GetComponent<UILabel>().text = skininfo.health;
        }
        classskin();
        qualityskin();
        raceskin();
    }
    /// <summary>
    /// 职业皮肤
    /// </summary>
    void classskin()
    {
        //如果是英雄
        if (skininfo.type == CardType.khero)
        {
            front.material = hero;
            return;
        }
        //只有技能  仆人卡有皮肤
        if (skininfo.type != CardType.kability && skininfo.type != CardType.kminion)
        {
            return;
        }

         Material zs, ms, zl, dly, sq, fs, lr, sm, ss, dz;

        if (skininfo.type==CardType.kminion)
        {
            zs=mzs;
            ms= mms;
            zl= mzl;
            dly= mdly;
            sq=msq;
            fs= mfs;
            lr=mlr;
            sm=msm;
            ss = mss;
            dz=mdz ;
        }
        else
        {
            zl = adz;
            zs = azs;
            ms = ams;
            dly = adly;
            sq = asq;
            fs = afs;
            lr = alr;
            sm = asm;
            ss = ass;
            dz = adz;
        }

        switch(skininfo.classs)
        {
            case CardClass.kany:
                front.material = zl;
                break;

            case CardClass.kdruid:
                front.material = dly;
                break;

            case CardClass.khunter:
                front.material = lr;
                break;

            case CardClass.kmage:
                front.material = fs;
                break;

            case CardClass.kpaladin:
                front.material = sq;
                break;

            case CardClass.kpriest:
                front.material = ms;
                break;

            case CardClass.krogue:
                front.material = dz;
                break;

            case CardClass.kshama:
                front.material = sm;
                break;

            case CardClass.kwarlock:
                front.material = ss;
                break;

            case CardClass.kwarrior:
                front.material = zs;
                break;
        }

        frontkuan = front;
    }
    /// <summary>
    /// 品质皮肤
    /// </summary>
    void qualityskin()
    {
       
		if(skininfo.set==CardSet.kbasic)//基本牌是没有品质模型的
		{
			quality.gameObject.SetActive(false);
		}
        switch(skininfo.quality)
        {
            case CardQuality.kfree:
                transform.FindChild("quality").gameObject.SetActive(false);
                break;

            case CardQuality.kcommon:
                quality.material = common;
                break;

            case CardQuality.kepic:
                quality.material = epic;
                break;

            case CardQuality.klegendary:
                quality.material = legendary;
                break;

            case CardQuality.krare:
                quality.material = rare;
                break;
        }
    }
    /// <summary>
    /// 种族皮肤
    /// </summary>
    void raceskin()
    {
        //英雄
        if (skininfo.type != CardType.kminion && skininfo.type != CardType.khero)//不是仆从没race
        {
            return;
        }
        UILabel racetext = transform. FindChild("race").GetComponent<UILabel>();

        switch(skininfo.race)
        {
            case CardRace.knone:
                racetext.text = "";
                transform.FindChild("racedi").gameObject.SetActive(false);
                break;

            case CardRace.kbeast:
                racetext.text = "野兽";
                break;

            case CardRace.kdemon:
                racetext.text = "恶魔";
                break;

            case CardRace.kdragon:
                racetext.text = "龙类";
                break;

            case CardRace.kmurloc:
                racetext.text = "鱼人";
                break;

            case CardRace.kpirate:
                racetext.text = "海盗";
                break;

            case CardRace.ktotem:
                racetext.text = "图腾";
                break;
        }
    }
   
}
