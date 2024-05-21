using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.RollAndWriteManagement;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

public class RollAndWriteController : MonoBehaviour
{
    [SerializeField]
    private RollAndWriteView view;
    
    [SerializeField]
    private List<RolledNumber> rolledNumbers;

    [SerializeField]
    private int maxRollsPerTurn = 3;

    [SerializeField]
    private int minimum = 1;

    [SerializeField]
    private int maximum = 9;

    public void GenerateNumbers()
    {
        rolledNumbers = new List<RolledNumber>();
        rolledNumbers.Clear();

        for (int i = 0; i < maxRollsPerTurn; i++)
        {
            var randomNumber = UnityRandom.Range(minimum, maximum);
            var rolledNumber = new RolledNumber(randomNumber);
            rolledNumbers.Add(rolledNumber);
        }
        view.UpdateRolledNumbersView(rolledNumbers);
    }

}