using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGenerator : MonoBehaviour
{
    public Text randomNumberText1;
    public Text randomNumberText2;
    public Text randomNumberText3;

    public int randomNumber1;
    public int randomNumber2;
    public int randomNumber3;
  
   public void GenerateRandomNumber()
    {
        randomNumber1 = Random.Range(1, 9);
        randomNumber2 = Random.Range(1, 9);
        randomNumber3 = Random.Range(1, 9);

        randomNumberText1.text = randomNumber1.ToString();
        randomNumberText2.text = randomNumber2.ToString();
        randomNumberText3.text = randomNumber3.ToString();
       
    }

  
}
