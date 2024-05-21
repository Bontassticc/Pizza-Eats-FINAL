using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    RandomNumberGenerator ndScript;
    public int movementDiceRoll = 0;

    public Text displayMovementRoll;
    public bool isButtonClicked = false;
    public bool turnOverIsClicked = false;

    public GameObject firstScreen;
    public GameObject confirm;
    public GameObject reset;
    public GameObject turnOver;
    public GameObject scores;
    public GameObject movement;
    public GameObject Grid;
    public GameObject pizzaStation1;
    public GameObject pizzaStation2;
    public GameObject player1;
    public GameObject player2;

    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        //ndScript = FindObjectOfType<RandomNumberGenerator
    }

    private void Update()
    {
        displayMovementRoll.text = "Moves: \n" + movementDiceRoll.ToString();
    }

    public void Confirm()
    {
        isButtonClicked = true;
    }


    public void TurnOver()
    {
        firstScreen.SetActive(true);
        turnOverIsClicked = true;
        Grid.SetActive(false);
        confirm.SetActive(false);
        reset.SetActive(false);
        turnOver.SetActive(false);
        scores.SetActive(false);
        movement.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        

    }

    public void GenerateMovement()
    {
        movementDiceRoll = Random.Range(2, 7);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
