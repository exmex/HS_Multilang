using UnityEngine;
using System.Collections;

public class dzturn : MonoBehaviour
{
    bool ismyturn = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnMouseUpAsButton()
    {
        if (dzcam.ismyturn)
        {
            animation["dzturn"].speed = 1;
            dzcam.ismyturn = false;
            animation.Play("dzturn");
            //endturn
            Camera.main.SendMessage("endturn");
        }
    }
    void myturn()
    {
        animation["dzturn"].speed = -1;
        animation["dzturn"].time = 1;
        animation.Play("dzturn");
        dzcam.ismyturn = true;
    }
}
