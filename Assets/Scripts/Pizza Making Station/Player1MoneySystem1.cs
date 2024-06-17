using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1MoneySystem1 : MonoBehaviour
{
    public int money = 300;
    public Text moneyText;
    public Text shopMoneyText;

    public int PineapplePrice = 20;
    public int MushroomPrice = 30;
    public int BeefPrice = 30;
    public int CheesePrice = 40;
    public int BaconPrice = 40;
    public int ChickenPrice = 30;
    public int PeppersPrice = 20;
    public int PepperoniPrice = 45;

    public int InPineapplePrice = 10;
    public int InMushroomPrce = 15;
    public int InBeefPrice = 15;
    public int InCheesePrice = 20;
    public int InBaconPrice = 20;
    public int InChickenPrice = 15;
    public int InPeppersPrice = 10;
    public int InPepperoniPrice = 25;



    private void Start()
    {
        UpdateMoneyText();
        UpdateShopMoneyText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = "R" + money.ToString();
    }

    public void UpdateShopMoneyText()
    {
        shopMoneyText.text = "R" + money.ToString();
    }

   

    
    public void DeductButton1()
    {
        if (money >= PineapplePrice)
        {
            money -= PineapplePrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }


    }

    public void DeductButton2()
    {
        if (money >= MushroomPrice)
        {
            money -= MushroomPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }

    }

    public void DeductButton3()
    {
        if (money >= BeefPrice)
        {
            money -= BeefPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }

    }

    public void DeductButton4()
    {
        if (money >= CheesePrice)
        {
            money -= CheesePrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }
    }

    public void DeductButton5()
    {
        if (money >= BaconPrice)
        {
            money -= BaconPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }
    }

    public void DeductButton6()
    {
        if (money >= ChickenPrice)
        {
            money -= ChickenPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }
    }

    public void DeductButton7()
    {
        if (money >= PeppersPrice)
        {
            money -= PeppersPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }
    }

    public void DeductButton8()
    {
        if (money >= PepperoniPrice)
        {
            money -= PepperoniPrice;
            UpdateMoneyText();
            UpdateShopMoneyText();
        }
    }
}


