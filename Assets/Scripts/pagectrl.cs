using UnityEngine;
using System.Collections;

public class pagectrl : MonoBehaviour {
    public GameObject page;
	// Use this for initialization
	void Start () {

	}
	
	void OnMouseEnter()
    {
        if (name == "nextpage")
        {
            Camera.main.SendMessage("np");
        }
        else
        {
            Camera.main.SendMessage("lp");
        }
    }
    void OnMouseExit()
    {
        if (name == "nextpage")
        {
            Camera.main.SendMessage("np");
        }
        else
        {
            Camera.main.SendMessage("lp");
        }
    }
    void OnMouseUpAsButton() 
    {
        if (name == "nextpage")
        {
            page.SendMessage("nextpage", 1);
        }
        else
        {
            page.SendMessage("nextpage", -1);
        }
    }
}
