using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yah : MonoBehaviour
{
    public GameObject Toppings, Slices, Map;
    // Start is called before the first frame update
    void Start()
    {
        Toppings.SetActive(false);
        Slices.SetActive(false);
        Map.SetActive(false);
    }

    // Update is called once per frame
    public void ShopText()
    {
        Toppings.SetActive(true);
        Slices.SetActive(true);
        Map.SetActive(true);
    }
}
