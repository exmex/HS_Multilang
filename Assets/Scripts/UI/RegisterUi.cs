using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class RegisterUi : MonoBehaviour
{
    public GameObject Step1;
    public GameObject Step2;

    public MessageBox MsgBox;

    public GameObject UsernameGameObject;
    private TMP_InputField _usernameInput;
    public GameObject PasswordGameObject;
    private TMP_InputField _passwordInput;
    public GameObject PasswordRepeatGameObject;
    private TMP_InputField _passwordRepeatInput;
    public GameObject EMailGameObject;
    private TMP_InputField _eMailInput;

    private void Start()
    {
        _usernameInput = UsernameGameObject.GetComponent<TMP_InputField>();
        _passwordInput = PasswordGameObject.GetComponent<TMP_InputField>();
        _passwordRepeatInput = PasswordRepeatGameObject.GetComponent<TMP_InputField>();
        _eMailInput = EMailGameObject.GetComponent<TMP_InputField>();
    }

    public void OnAcceptTermsClick()
    {
        Step1.SetActive(false);
        Step2.SetActive(true);
    }

    public void OnDenyTermsClick()
    {
        gameObject.SetActive(false);
    }

    public void OnRegisterClick()
    {
        var username = _usernameInput.text;
        var password = _passwordInput.text;
        var email = _eMailInput.text;

        if (username == "")
        {
            MsgBox.ShowMessage("Username cannot be empty!");
            return;
        }
        if (password == "")
        {
            MsgBox.ShowMessage("Password cannot be empty!");
            return;
        }
        if (_passwordRepeatInput.text != password)
        {
            MsgBox.ShowMessage("Password doesn't match!");
            return;
        }

        if (email == "")
        {
            MsgBox.ShowMessage("E-Mail cannot be empty!");
            return;
        }

        if (!isValidEmail(email))
        {
            MsgBox.ShowMessage("E-Mail is invalid!");
            return;
        }

        StartCoroutine(API.Register(username, password, email, response =>
        {
            if (response != "")
            {
                MsgBox.ShowMessage(response);
            }
            else
            {
                ClearInput();
                gameObject.SetActive(false);
                Step1.SetActive(true);
                Step2.SetActive(false);

                MsgBox.ShowMessage("You are now registered!");
            }
        }));
    }

    private bool isValidEmail(string email)
    {
        if (email.IndexOf("@", StringComparison.Ordinal) == -1)
            return false;
        if (email.IndexOf(".", StringComparison.Ordinal) == -1)
            return false;
        try
        {
            var m = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public void ClearInput()
    {
        _usernameInput.text = "";
        _passwordInput.text = "";
        _passwordRepeatInput.text = "";
        _eMailInput.text = "";
    }

    public void OnCancelClick()
    {
        ClearInput();

        gameObject.SetActive(false);
        Step1.SetActive(true);
        Step2.SetActive(false);
    }
}