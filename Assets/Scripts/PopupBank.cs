using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPopup;
    public GameObject withdrawPopup;
    public GameObject Button;

    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;


    public void OpenDepositPopup()
    {
        depositPopup.SetActive(true);
        withdrawPopup.SetActive(false);
        Button.SetActive(false);
    }

    
    public void OpenWithdrawPopup()
    {
        withdrawPopup.SetActive(true);
        depositPopup.SetActive(false);
        Button.SetActive(false);
    } 
    
    public void privateBtn() 
    {
        withdrawPopup.SetActive(false);
        depositPopup.SetActive(false);
        Button.SetActive(true);

    }

    public void Deposit(float amount)
    {
        var user = GameManager.Instance.userData;

        if (user.cash >= amount)
        {
            user.cash -= amount;
            user.Balance += amount;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }
        else
        {
            Debug.Log("현금이 부족합니다.");
        }
    }

    public void DepositByInput()
    {
        if (!float.TryParse(depositInputField.text, out float amount) || amount <= 0)
        {
            Debug.Log("입력값이 유효하지 않습니다.");
            return;
        }
        Deposit(amount);
        depositInputField.text = "";
    }

    public void WithdrawByInput()
    {
        if (!float.TryParse(withdrawInputField.text, out float amount) || amount <= 0)
        {
            Debug.Log("입력값이 유효하지 않습니다.");
            return;
        }

        var user = GameManager.Instance.userData;

        if (user.Balance >= amount)
        {
            user.cash += amount;
            user.Balance -= amount;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }
        else
        {
            Debug.Log("통장 잔액이 부족합니다.");
        }

        withdrawInputField.text = "";
    }

    public void DepositBtn(int money) 
    {
        var user = GameManager.Instance.userData;

        if (GameManager.Instance.userData.cash >= money)
        {
            GameManager.Instance.userData.cash -= money;
            GameManager.Instance.userData.Balance += money;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }
    }

    public void WithDrawBtn(int money) 
    {
        var user = GameManager.Instance.userData;

        if (GameManager.Instance.userData.Balance >= money)
        {
            GameManager.Instance.userData.cash += money;
            GameManager.Instance.userData.Balance -= money;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }  
        
    }
}
