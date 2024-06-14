
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGenerator : MonoBehaviour
{
    //player 1
    public GameObject Bowl1;
    public GameObject Bowl2;
    public GameObject Bowl3;
    public GameObject Bowl4;
    public GameObject Bowl5;
    public GameObject Bowl6;
    public GameObject Bowl7;
    public GameObject Bowl8;

    //player 1
    public GameObject Pizza1;
    public GameObject Pizza2;
    public GameObject Pizza3;
    public GameObject Pizza4;
    public GameObject Pizza5;
    public GameObject Pizza6;
    public GameObject Pizza7;
    public GameObject Pizza8;

    //player 2
    public GameObject B1, B2, B3, B4, B5, B6, B7, B8;

    //player 2
    public GameObject P1, P2, P3, P4, P5, P6, P7, P8;

    public Text randomNumberText1;
    public Text randomNumberText2;
    public Text randomNumberText3;

    public int randomNumber1;
    public int randomNumber2;
    public int randomNumber3;

    List<GameObject> bowls = new List<GameObject>();
    List<GameObject> pizzas = new List<GameObject>();
    List<GameObject> Bs = new List<GameObject>();
    List<GameObject> Ps = new List<GameObject>();

    private void Start()
    {
        // player 1

        bowls.Add(Bowl1);
        bowls.Add(Bowl2);
        bowls.Add(Bowl3);
        bowls.Add(Bowl4);
        bowls.Add(Bowl5);
        bowls.Add(Bowl6);
        bowls.Add(Bowl7);
        bowls.Add(Bowl8);

        pizzas.Add(Pizza1);
        pizzas.Add(Pizza2);
        pizzas.Add(Pizza3);
        pizzas.Add(Pizza4);
        pizzas.Add(Pizza5);
        pizzas.Add(Pizza6);
        pizzas.Add (Pizza7);
        pizzas.Add(Pizza8);

        //player 2
        Bs.Add(B1);
        Bs.Add(B2);
        Bs.Add(B3);
        Bs.Add(B4);
        Bs.Add(B5);
        Bs.Add(B6);
        Bs.Add(B7);
        Bs.Add(B8);

        Ps.Add(P1);
        Ps.Add(P2);
        Ps.Add(P3);
        Ps.Add(P4);
        Ps.Add(P5);
        Ps.Add(P6);
        Ps.Add(P7);
        Ps.Add(P8);

    }


    public void GenerateRandomNumber()
    {
        randomNumber1 = Random.Range(1, 9);
        randomNumber2 = Random.Range(1, 9);
        randomNumber3 = Random.Range(1, 9);



        randomNumberText1.text = randomNumber1.ToString();
        randomNumberText2.text = randomNumber2.ToString();
        randomNumberText3.text = randomNumber3.ToString();

        //This loop sets all the panels active for the bowls.
        //It loops through the "bowls" list
        for (int i = 0; i < bowls.Count; i++)
        {
            bowls[i].SetActive(true);
            pizzas[i].SetActive(true);
            Bs[i].SetActive(true);
            Ps[i].SetActive(true);
        }


        //This loop only sets the bowls that have the random number in its name to inactive.
        //It also loops through the "bowls" list
        for (int i = 0; i < bowls.Count; i++)
        {
            if (bowls[i].transform.name.Contains(randomNumberText1.text))
            {
                bowls[i].SetActive(false);
                pizzas[i].SetActive(false);
                Bs[i].SetActive(false);
                Ps[i].SetActive(false);
            }

            if (bowls[i].transform.name.Contains(randomNumberText2.text))
            {
                bowls[i].SetActive(false);
                pizzas[i].SetActive(false);
                Bs[i].SetActive(false);
                Ps[i].SetActive(false);
            }

            if (bowls[i].transform.name.Contains(randomNumberText3.text))
            {
                bowls[i].SetActive(false);
                pizzas[i].SetActive(false);
                Bs[i].SetActive(false);
                Ps[i].SetActive(false);
            }
        }
    }
}



