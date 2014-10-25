using UnityEngine;
using System.Collections;

public class LoginMsg : MonoBehaviour {
    public GameObject msgyes;
	void showMsg(string t)
    {
        UILabel l = transform.FindChild("msgbox").FindChild("msgtext").GetComponent<UILabel>();
        l.text = t;
        
        transform.FindChild("msgbox").gameObject.SetActive(true);

    }
    void OnClick()
    {
        msgyes.transform.parent.gameObject.SetActive(false);

    }
}
