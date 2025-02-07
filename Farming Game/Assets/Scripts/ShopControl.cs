using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    int moneyAmount;
    int isAxeSold;

    public Text moneyAmountText;
    public Text AxeSold;

    public Button buyButton;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    void Update()
    {
        moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";


    }
}
