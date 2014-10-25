#pragma strict

var myCursor : Texture2D;
var myClickCursor : Texture2D;
var nextpagecur: Texture2D;
var lastpagecur: Texture2D;
var cursorWidth : float;
var cursorHeight : float;



var now:Texture2D;

function Start () {
    Screen.showCursor = false;
    now=myCursor;
}

function Update () {
    /*
    if (Input.GetMouseButton(0)&&now==myCursor) 
    {
        now = myClickCursor;
    }
    else if (Input.GetMouseButton(0)&&now==myClickCursor) 
    {
        now = myCursor;
    }*/
}
function np()
{
    if(now==nextpagecur)
    {
        now=myCursor;
    }
        else
    {
        now=nextpagecur;
    }
   
}
function lp()
{
    if(now==lastpagecur)
    {
        now=myCursor;
    }
    else
    {
        now=lastpagecur;
    }
   
}
function OnGUI () {
    var mousePos = Input.mousePosition;
    GUI.DrawTexture(Rect(mousePos.x -10, Screen.height - mousePos.y  , cursorWidth, cursorHeight), now);
}