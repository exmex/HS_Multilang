using UnityEngine;
using System.Collections;

public class yxclick : MonoBehaviour {
    CardClass myclass;
    Material classpic;
	// Use this for initialization
	void Start () {
        classpic = transform.FindChild("pic").renderer.material;
        switch (name)
        {
            case "圣骑士": myclass= CardClass.kpaladin;
                break;
            case "德鲁伊": myclass= CardClass.kdruid;
                break;
            case "战士": myclass= CardClass.kwarrior;
                break;
            case "术士": myclass= CardClass.kwarlock;
                break;

            case "法师": myclass= CardClass.kmage;
                break;
            case "潜行者": myclass= CardClass.krogue;
                break;
            case "牧师": myclass= CardClass.kpriest;
                break;
            case "猎人": myclass= CardClass.khunter;
                break;

            case "萨满祭司": myclass= CardClass.kshama;
                break;

        }
	}
	

    void OnMouseUpAsButton()
    {
        transform.root.SendMessage("setclass",myclass);
        transform.root.SendMessage("setclasspic",classpic);
        transform.root.SendMessage("setClassname", name);
    }
}
