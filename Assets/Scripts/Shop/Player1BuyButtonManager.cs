using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1BuyButtonManager : MonoBehaviour
{
    public Transform[] Slots;
    public PLayer1MoneySystem1 moneySystem;
    public GameObject Pineapple;
    public GameObject Mushrooms;
    public GameObject Beef;
    public GameObject Cheese;
    public GameObject Bacon;
    public GameObject Chicken;
    public GameObject Peppers;
    public GameObject Pepperoni;


    public Transform MushroomSlot, PineAppleSlot, BeefSlot, CheeseSlot, BaconSlot, ChickenSlot, PeppersSlot, PepperoniSlot;

    public Vector3 sizes = new Vector3(200f, 200f, 0);


    bool pineappleBought;
    bool mushroomBought;
    bool beefBought;
    bool cheeseBought;
    bool baconBought; 
    bool chickenBought;
    bool peppersBought;
    bool peperoniBought;

    private void Start()
    {
        pineappleBought = false;
        mushroomBought = false;
        beefBought = false;
        cheeseBought = false;
        baconBought = false;
        chickenBought = false;
        peppersBought = false;
        peperoniBought = false;
    }
    private void Update()
    {
        if (pineappleBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Pineapple, PineAppleSlot.position, Quaternion.identity, PineAppleSlot);
                CloneObject.transform.localScale = sizes ;

                CloneObject.transform.localScale = sizes ;

                if(i == 9)
                {
                    pineappleBought = false;
                }

            }

        }

        if (mushroomBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Mushrooms, MushroomSlot.position, Quaternion.identity, MushroomSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;


                if (i == 9)
                {
                    mushroomBought = false;
                }

            }

        }

        if (beefBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Beef, BeefSlot.position, Quaternion.identity, BeefSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;

                if (i == 9)
                {
                    beefBought = false;
                }

            }

        }

        if (cheeseBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Cheese, CheeseSlot.position, Quaternion.identity, CheeseSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;

                if (i == 9)
                {
                    cheeseBought = false;
                }

            }

        }

        if (baconBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Bacon, BaconSlot.position, Quaternion.identity, BaconSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;


                if (i == 9)
                {
                    baconBought = false;
                }

            }

        }

        if (chickenBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Chicken, ChickenSlot.position, Quaternion.identity, ChickenSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;

                if (i == 9)
                {
                   chickenBought = false;
                }

            }

        }

        if (peppersBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Peppers, PeppersSlot.position, Quaternion.identity, PeppersSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;

                if (i == 9)
                {
                    peppersBought = false;
                }

            }

        }


        if (peperoniBought)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject CloneObject = Instantiate(Pepperoni, PepperoniSlot.position, Quaternion.identity, PepperoniSlot);
                CloneObject.transform.localScale = sizes;

                CloneObject.transform.localScale = sizes;

                if (i == 9)
                {
                    peperoniBought = false;
                }

            }

        }
    }

    public void Buy1()
    {

        if (moneySystem.money >= moneySystem.PineapplePrice)
        {
            pineappleBought=true;

            moneySystem.DeductButton1(); 
        }

    }


    public void Buy2()
    {

        if (moneySystem.money >= moneySystem.MushroomPrice)
        {
            mushroomBought = true;
                  
            moneySystem.DeductButton2();
            }
        
    }

    public void Buy3()
    {

        if (moneySystem.money >= moneySystem.BeefPrice)
        {
            beefBought = true;

            moneySystem.DeductButton3();
        }

    }

    public void Buy4()
    {

        if (moneySystem.money >= moneySystem.CheesePrice)
        {
            cheeseBought = true;

            moneySystem.DeductButton4();
        }

    }

    public void Buy5()
    {

        if (moneySystem.money >= moneySystem.BaconPrice)
        {
            baconBought = true;

            moneySystem.DeductButton5();
        }

    }
    public void Buy6()
    {

        if (moneySystem.money >= moneySystem.ChickenPrice)
        {
            chickenBought = true;

            moneySystem.DeductButton6();
        }

    }
         

    public void Buy7()
    {

        if (moneySystem.money >= moneySystem.PeppersPrice)
        {
            peppersBought = true;
           
            moneySystem.DeductButton7();
        }

    }
    public void Buy8()
    {

        if (moneySystem.money >= moneySystem.PepperoniPrice)
        {
            peperoniBought = true;

            moneySystem.DeductButton8();
        }

    }

}

   