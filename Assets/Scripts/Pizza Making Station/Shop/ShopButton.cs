using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject Shop;

    

    public void Start()
    {
        Shop.SetActive(false);
    }

    public void ActivateShop()
    {
        Shop.SetActive(true);
    }

    public void DeactivateShop()
    {
        Shop.SetActive(false);
    }
}
