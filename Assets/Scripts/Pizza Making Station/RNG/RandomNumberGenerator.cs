using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGenerator : MonoBehaviour
{
    public GameObject Bowl1;
    public GameObject Bowl2;
    public GameObject Bowl3;
    public GameObject Bowl4;
    public GameObject Bowl5;
    public GameObject Bowl6;
    public GameObject Bowl7;
    public GameObject Bowl8;

    public Text randomNumberText1;
    public Text randomNumberText2;
    public Text randomNumberText3;

    public int randomNumber1;
    public int randomNumber2;
    public int randomNumber3;

    public void Start()
    {
       Bowl1.SetActive(true);
    }
    public void GenerateRandomNumber()
    {
        randomNumber1 = Random.Range(1, 9);
        randomNumber2 = Random.Range(1, 9);
        randomNumber3 = Random.Range(1, 9);

        randomNumberText1.text = randomNumber1.ToString();
        randomNumberText2.text = randomNumber2.ToString();
        randomNumberText3.text = randomNumber3.ToString();
       
    }
    
    public void Update()
    { 
        //randomNumber1
       if(randomNumber1 == 1)
        {
            Bowl1.SetActive(false);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if(randomNumber1 == 2)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(false);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }

        else if (randomNumber1 == 3)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(false);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber1 == 4)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(false);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else  if (randomNumber1 == 5)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(false);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
       else if (randomNumber1 == 6)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(false);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber1 == 7)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(false);
            Bowl8.SetActive(true);
        }
        else if (randomNumber1 == 8)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(false);
        }

        //randomNumber2
        if (randomNumber2 == 1)
        {
            Bowl1.SetActive(false);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 2)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(false);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }

        else if (randomNumber2 == 3)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(false);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 4)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(false);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 5)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(false);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 6)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(false);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 7)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(false);
            Bowl8.SetActive(true);
        }
        else if (randomNumber2 == 8)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(false);
        }

        //randomNUmber3
        if (randomNumber3 == 1)
        {
            Bowl1.SetActive(false);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 2)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(false);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }

        else if (randomNumber3 == 3)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(false);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 4)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(false);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 5)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(false);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 6)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(false);
            Bowl7.SetActive(true);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 7)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(false);
            Bowl8.SetActive(true);
        }
        else if (randomNumber3 == 8)
        {
            Bowl1.SetActive(true);
            Bowl2.SetActive(true);
            Bowl3.SetActive(true);
            Bowl4.SetActive(true);
            Bowl5.SetActive(true);
            Bowl6.SetActive(true);
            Bowl7.SetActive(true);
            Bowl8.SetActive(false);
        }




    }
    
  
}
