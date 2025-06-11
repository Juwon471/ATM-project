using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI Cointext;
    private int Coin = 100000;
    // Start is called before the first frame update
    void Start()
    {
        string formet = Coin.ToString("N0");
        Cointext.text = formet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
