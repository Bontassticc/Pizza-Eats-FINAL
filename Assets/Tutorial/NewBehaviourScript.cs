using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Rand1, Rand2, Rand3, Shop;

    // Start is called before the first frame update
    void Start()
    {
        Rand1.SetActive(false);
        Rand2.SetActive(false);
        Rand3.SetActive(false);
        Shop.SetActive(false);
    }

    public void GenerateText()
    {
        Rand1.SetActive (true);
        Rand2.SetActive (true);
        Rand3.SetActive (true);
        Shop.SetActive (true);
    }
}
