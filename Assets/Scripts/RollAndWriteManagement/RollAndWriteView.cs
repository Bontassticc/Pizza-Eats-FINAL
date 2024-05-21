using System.Collections.Generic;
using Assets.Scripts.RollAndWriteManagement;
using UnityEngine;
using UnityEngine.UI;

public class RollAndWriteView : MonoBehaviour
{
    [SerializeField]
    private List<Text> randomNumbersTextBox;
    
    public void UpdateRolledNumbersView(List<RolledNumber> rolledNumbers)
    {
        for (int i = 0; i < rolledNumbers.Count; i++)
        {
            var textBox = randomNumbersTextBox[i];
            var rolledNumber = rolledNumbers[i].Number;
            textBox.text = rolledNumber.ToString();
        }
    }

    public void ClearRolledNumbersTextBox()
    {
        for (int i = 0; i < randomNumbersTextBox.Count; i++)
        {
            var textBox = randomNumbersTextBox[i];
            textBox.text = "";
        }
    }
}