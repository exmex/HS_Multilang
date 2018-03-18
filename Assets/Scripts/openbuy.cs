using UnityEngine;
using System.Collections;

public class openbuy : MonoBehaviour {

	void OnMouseUpAsButton()
    {
        GameObject.Find("mcam").transform.Find("buy").SendMessage("show");
    }
}
