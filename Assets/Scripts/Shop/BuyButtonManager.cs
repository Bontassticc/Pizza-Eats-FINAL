using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonManager : MonoBehaviour
{
    public Transform[] Slots;
    public MoneySystem moneySystem;
    public GameObject Pineapple;
    public GameObject Mushrooms;
    public GameObject Beef;
    public GameObject Cheese;
    public GameObject Bacon;
    public GameObject Chicken;
    public GameObject Peppers;
    public GameObject Pepperoni;


    public Transform StorageSlot;

    public Vector3 sizes = new Vector3(70f, 70f, 0);

    private int Lastpoint = -1;

    public void Buy1()
    {

        if (moneySystem.money >= moneySystem.PineapplePrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Pineapple, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.3f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton1();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Pineapple, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.3f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;

                    moneySystem.DeductButton1();

                    return;
                }


            }
        }
    }

    public void Buy2()
    {

        if (moneySystem.money >= moneySystem.MushroomPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Mushrooms, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.3f, 0);


                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton2();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Mushrooms, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.3f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton2();


                    return;
                }


            }
        }
    }

    public void Buy3()
    {

        if (moneySystem.money >= moneySystem.BeefPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Beef, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.1f, 0);


                    CloneObject.transform.localScale = new Vector3(50, 50, 0);

                    Lastpoint = i;
                    moneySystem.DeductButton3();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Beef, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.1f, 0);

                    CloneObject.transform.localScale = new Vector3(50, 50, 0);

                    Lastpoint = i;
                    moneySystem.DeductButton3();


                    return;
                }


            }
        }
    }

    public void Buy4()
    {

        if (moneySystem.money >= moneySystem.CheesePrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Cheese, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);


                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton4();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Cheese, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton4();


                    return;
                }


            }
        }
    }

    public void Buy5()
    {

        if (moneySystem.money >= moneySystem.BaconPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Bacon, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);


                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton5();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Bacon, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton5();


                    return;
                }


            }
        }
    }

    public void Buy6()
    {

        if (moneySystem.money >= moneySystem.ChickenPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Chicken, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.2f, 0);


                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton6();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Chicken, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.2f, 0);

                    CloneObject.transform.localScale = new Vector3(200, 200, 0);

                    Lastpoint = i;
                    moneySystem.DeductButton6();


                    return;
                }


            }
        }
    }

    public void Buy7()
    {

        if (moneySystem.money >= moneySystem.PeppersPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Peppers, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);


                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton7();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Peppers, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.5f, 0);

                    CloneObject.transform.localScale = sizes;

                    Lastpoint = i;
                    moneySystem.DeductButton7();


                    return;
                }


            }
        }
    }
    public void Buy8()
    {

        if (moneySystem.money >= moneySystem.PepperoniPrice)
        {
            int startIndex = Lastpoint + 1;

            if (startIndex >= Slots.Length)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < Slots.Length; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Pepperoni, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.4f, 0);


                    CloneObject.transform.localScale = new Vector3(40, 40, 0);

                    Lastpoint = i;
                    moneySystem.DeductButton8();

                    return;

                }
            }
            for (int i = 0; i < startIndex; i++)
            {
                Transform space = Slots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject CloneObject = Instantiate(Pepperoni, space.position, Quaternion.identity, StorageSlot);
                    CloneObject.transform.position = new Vector3(space.position.x, space.position.y - 0.4f, 0);

                    CloneObject.transform.localScale = new Vector3(40, 40, 0);

                    Lastpoint = i;
                    moneySystem.DeductButton8();


                    return;
                }


            }
        }
    }

}

   