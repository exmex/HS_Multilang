using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 开包时 拉包
/// </summary>
public class packdrag : MonoBehaviour {
    Vector3 lastpostion;
    bool candrag = true;
    Vector3 screenSpace,offset;
    void Start()
    {
        lastpostion = transform.localPosition;
    }
      void OnMouseDown()  
    {
        if (web.player.expack<=0)
        {
            return;
        }
     //translate the cubes position from the world to Screen Point
//轉換對象位置，從世界點到屏幕座標
screenSpace = Camera.main.WorldToScreenPoint(transform.position);
//calculate any difference between the cubes world position and the mouses Screen position converted to a worldpoint
//在對象世界座標與鼠標屏幕座標計算任何不同，轉換到世界點上
offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));
}

    void OnMouseDrag ()
      {
          if (web.player.expack <= 0)
          {
              return;
          }
        if (!candrag)
        {
            return;
        }
          //keep track of the mouse position
          //保持鼠標位置追蹤
          var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
          //convert the screen mouse position to world point and adjust with offset
          //轉換屏幕鼠標位置到世界點，以及通過偏移調整
          var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
          //update the position of the object in the world
          //更新物體在世界的位置
          transform.position = curPosition;
      }
    void OnMouseUp()
      {
          if (web.player.expack <= 0)
          {
              return;
          }

          candrag = false;
        //加上刚体
          gameObject.AddComponent<Rigidbody>();
          
      }
    void OnCollisionEnter() 
    {
        transform.root.SendMessage("openpack");
    }
    void gotoback()
    {
        candrag = true;
        Destroy(gameObject.rigidbody);
        transform.localPosition = lastpostion;
    }
}  


