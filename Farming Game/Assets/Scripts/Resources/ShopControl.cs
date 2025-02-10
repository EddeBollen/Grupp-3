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
    public Text axePrice;

    public Button buyButton;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    void Update()
    {
           moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";  

        isAxeSold = PlayerPrefs.GetInt("isAxeSold");

        if (moneyAmount > 50 && isAxeSold == 0)
        {
            buyButton.interactable = true;
        }

    }
    public void buyAxe()
    {
        moneyAmount -= 50;
        PlayerPrefs.SetInt("IsAxeSold", 1);
        axePrice.text = "Sold";
        buyButton.gameObject.SetActive(false);
    }

    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("SampleScene");
    }
   
}
