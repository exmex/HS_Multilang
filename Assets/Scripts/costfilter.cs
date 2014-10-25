using UnityEngine;
using System.Collections;

public class costfilter : MonoBehaviour {
    MeshRenderer mlight;
    static string nowlight;
    bool islight;
	// Use this for initialization
	void Start () {
        mlight = transform.FindChild("light").GetComponent<MeshRenderer>();
        nowlight = "all";
	}
	
	// Update is called once per frame
	void Update () {
	if (nowlight==name)
	{
        light();
	} 
	else
	{
        dark();
	}
	}
    void OnMouseUpAsButton()
    {
        if (nowlight!=name)
        {
            nowlight = name;
            transform.root.FindChild("page").SendMessage("oncost", name);
        } 
    }
    void light()
    {
        if (!mlight.enabled)
        {
            mlight.enabled = true;
        }
        
    }
    void dark()
    {
        if (mlight.enabled)
        {
            mlight.enabled = false;
        }

    }

}
