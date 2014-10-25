using UnityEngine;
using System.Collections;
/// <summary>
/// 开包时 卡牌的控制
/// </summary>
public class opencardctrl : MonoBehaviour
{
    bool isopen = false;
    void  OnMouseUpAsButton()
    {
        if (!isopen)
        {
            transform.parent.SendMessage("openonecard");
            iTween.RotateTo(gameObject, Vector3.zero, 0.5f);
            isopen = true;
        }
        
    }
}
