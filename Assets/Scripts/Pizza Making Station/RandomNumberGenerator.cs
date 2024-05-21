using UnityEngine;
using UnityEngine.UI;

public class RandomNumberGenerator : MonoBehaviour
{
    public Text randomNumberText1;
    public Text randomNumberText2;
    public Text randomNumberText3;

  
   public void GenerateRandomNumber()
    {
        int randomNumber1 = Random.Range(1, 9);
        int randomNumber2 = Random.Range(1, 9);
        int randomNumber3 = Random.Range(1, 9);

        randomNumberText1.text = randomNumber1.ToString();
        randomNumberText2.text = randomNumber2.ToString();
        randomNumberText3.text = randomNumber3.ToString();
       
    }  
}
