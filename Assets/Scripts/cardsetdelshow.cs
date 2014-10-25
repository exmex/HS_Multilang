using UnityEngine;
using System.Collections;

public class cardsetdelshow : MonoBehaviour
{
    bool isindel = false;
    void OnMouseEnter()
    {
        Debug.Log("enter");
        isindel = true;
    }
    //放弃显示控制
    void OnMouseExit()
    {
        isindel = false;
    }
    IEnumerator hide()
    {
        Debug.Log("hide");
        yield return new WaitForSeconds(0.1f);
        if (!isindel)
        {
            gameObject.SetActive(false);
        }
       
    }
}
