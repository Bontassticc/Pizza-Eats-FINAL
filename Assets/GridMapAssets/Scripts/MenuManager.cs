using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    //RandomNumberGenerator ndScript;
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
    public GameObject panel;

    PlayerMovement movementScript;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        movementScript = FindAnyObjectByType<PlayerMovement>();
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
        panel.SetActive(false);

        /*if (movementScript.player1Turn)
        {
            pizzaStation1.SetActive(true);
            pizzaStation2.SetActive(false);
        }
        else
        {
            pizzaStation2.SetActive(true);
            pizzaStation1.SetActive(false);
        }*/
        
    }

    public void GenerateMovement()
    {
        movementDiceRoll = Random.Range(2, 7);
    }

    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
