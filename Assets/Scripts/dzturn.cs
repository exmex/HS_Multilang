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
            GetComponent<Animation>()["dzturn"].speed = 1;
            dzcam.ismyturn = false;
            GetComponent<Animation>().Play("dzturn");
            //endturn
            Camera.main.SendMessage("endturn");
        }
    }
    void myturn()
    {
        GetComponent<Animation>()["dzturn"].speed = -1;
        GetComponent<Animation>()["dzturn"].time = 1;
        GetComponent<Animation>().Play("dzturn");
        dzcam.ismyturn = true;
    }
}
