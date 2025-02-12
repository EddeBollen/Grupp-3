using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BuyItem : MonoBehaviour
{
    int moneyAmount;
    int isAxeSold;
    int isSeedSold;
    int isPickaxeSold;


    public Text moneyAmountText;
    public Text axePrice;
    public Text seedPrice;
    public Text pickaxePrice;



    public Button buyButtonAxe;
    public Button buyButtonSeed;
    public Button buyButtonPickaxe;

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
            buyButtonAxe.interactable = true;
        }

        isSeedSold = PlayerPrefs.GetInt("isSeedSold");

        if (moneyAmount > 10 && isSeedSold == 0)
        {
            buyButtonSeed.interactable = true;
        }

        isPickaxeSold = PlayerPrefs.GetInt("isPickaxeSold");

        if (moneyAmount > 75 && isPickaxeSold == 0)
        {
            buyButtonPickaxe.interactable = true;
        }
    }
    public void buyAxe()
    {
        moneyAmount -= 50;
        PlayerPrefs.SetInt("IsAxeSold", 1);
        axePrice.text = "Sold";
        buyButtonAxe.gameObject.SetActive(false);
    }
    public void buySeed()
    {
        moneyAmount -= 10;
        PlayerPrefs.SetInt("IsSeedSold", 1);
        seedPrice.text = "Sold";
        buyButtonSeed.gameObject.SetActive(false);
    }
    public void buyPickaxe()
    {
        moneyAmount -= 70;
        PlayerPrefs.SetInt("IsPickaxeSold", 1);
        pickaxePrice.text = "Sold";
        buyButtonPickaxe.gameObject.SetActive(false);
    }


    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("Gameplay");
    }
   
}
