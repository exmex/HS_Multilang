using UnityEngine;
using System.Collections;

public class costfilter : MonoBehaviour
{
    MeshRenderer mlight;
    static string nowlight;
    bool islight;
    // Use this for initialization
    void Start()
    {
        mlight = transform.Find("light").GetComponent<MeshRenderer>();
        nowlight = "all";
    }

    // Update is called once per frame
    void Update()
    {
        if (nowlight == name)
        {
            enableLight();
        }
        else
        {
            disableLight();
        }
    }
    void OnMouseUpAsButton()
    {
        if (nowlight != name)
        {
            nowlight = name;
            transform.root.Find("page").SendMessage("oncost", name);
        }
    }
    void enableLight()
    {
        if (!mlight.enabled)
        {
            mlight.enabled = true;
        }

    }
    void disableLight()
    {
        if (mlight.enabled)
        {
            mlight.enabled = false;
        }

    }

}
