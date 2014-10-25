using UnityEngine;
using System.Collections;

public class closebuy : MonoBehaviour {


    void OnMouseUpAsButton()
    {
        transform.parent.SendMessage("close");
    }
}
