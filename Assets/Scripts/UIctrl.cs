using UnityEngine;
using System.Collections;

public class UIctrl : MonoBehaviour {
    Resolution nowResolution;

    public UIPopupList ResolutionPoplist;
    public GameObject setting;
    public UICheckbox fullscreen;
    int count;
    void showSetting()
     {
         count = 0;
         setting.SetActive(!setting.activeSelf);
        if (setting.activeSelf)
        {
            getResolution();
            getFullScreen();
            getQuality();
        }
     }
    void getResolution()
    {
        nowResolution = Screen.currentResolution;
        ResolutionPoplist.items.Clear();
        foreach (Resolution res in Screen.resolutions)
        {
            ResolutionPoplist.items.Add(res.width + "*" + res.height);
        }
        ResolutionPoplist.selection = nowResolution.width + "*" + nowResolution.height;
    }
    void getFullScreen()
    {
        fullscreen.isChecked = Screen.fullScreen;
    }
    void setFullScreen()
    {
        Screen.fullScreen = fullscreen.isChecked;
    }
    public UIPopupList QualityPoplist;
    void getQuality()
    {
		QualityLevel nowQuality =(QualityLevel)QualitySettings.GetQualityLevel();
        QualityPoplist.items.Clear();
        for (int x = 0; x < 6;x++ )
        {
            QualityLevel q = (QualityLevel)x;
            QualityPoplist.items.Add(q.ToString());
        }
        QualityPoplist.selection = nowQuality.ToString();
    }
    void setQuality()
    {
        int cur=QualityPoplist.items.IndexOf(QualityPoplist.selection);

        QualitySettings.SetQualityLevel(cur);
    }
    void setResolution()//开始会被调用2次
    {
    if (count<2)//用来解决分辨一打开就会被调用
    {
        count++;
        return;
    }
        Debug.Log("出现");
        string[] sz = ResolutionPoplist.selection.Split('*');
        Screen.SetResolution(int.Parse(sz[0]), int.Parse(sz[1]), fullscreen.isChecked);
           
       
        
    }
    void exitGame()
    {
        Application.Quit();
    }
}
