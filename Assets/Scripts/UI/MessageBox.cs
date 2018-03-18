using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    public GameObject TextGameObject;

    private TextMeshProUGUI _textHolder;
    
    // Use this for initialization
    void Start()
    {
        if(_textHolder == null)
            _textHolder = TextGameObject.GetComponent<TextMeshProUGUI>();
    }

    public void ShowMessage(string text)
    {
        if(_textHolder == null)
            _textHolder = TextGameObject.GetComponent<TextMeshProUGUI>();
        
        _textHolder.text = text;
        gameObject.SetActive(true);
    }

    public void OnOkClick()
    {
        _textHolder.text = "";
        gameObject.SetActive(false);
    }
}