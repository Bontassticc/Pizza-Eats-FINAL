using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGenerator : MonoBehaviour
{
    public Text randomNumberText;
    // Start is called before the first frame update

    private void Start()
    {
        GenerateRandomNumber();
    }
   public void GenerateRandomNumber()
    {
        int randomNumber1 = Random.Range(1, 9);
        int randomNumber2 = Random.Range(1, 9);
        int randomNumber3 = Random.Range(1, 9);

        randomNumberText.text = "Random Number: " + randomNumber1 + "," + randomNumber2 + "," + randomNumber3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
