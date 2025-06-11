using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]

public class UserData
{
    public string UserName;
    public float cash;
    public float Balance;

    public UserData(string userName, float cash, float Balance)
    {
        this.UserName = userName;
        this.cash = cash;
        this.Balance = Balance;
    }

    public override string ToString()
    {
        return $"이름: {UserName} , 현금: {cash}원 , 통장잔액: {Balance}원";
    }

    

}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public void Refresh() 
    {
        if (userData != null)
        {
            userNameText.text = userData.UserName;
            cashText.text = userData.cash.ToString("N0") + "원";
            balanceText.text = userData.Balance.ToString("N0") + "원";
        }      
    }


    public void SaveUserData()
    {
        PlayerPrefs.SetString("UserName", userData.UserName);
        PlayerPrefs.SetFloat("Cash", userData.cash);
        PlayerPrefs.SetFloat("Balance", userData.Balance);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        string name = PlayerPrefs.GetString("UserName", "김주원");
        float cash = PlayerPrefs.GetFloat("Cash", 100000f);
        float balance = PlayerPrefs.GetFloat("Balance", 50000f);

        userData = new UserData(name, cash, balance);
    }


    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
 
    }


    public void Start()
    {   
        LoadUserData();     
        Refresh();
    }

    public void Update()
    {
        Refresh();
    }

}
