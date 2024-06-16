using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static GameManager;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Animator player1Anim;
    public Animator player2Anim;

    public Tilemap tilemap;
    public List<Vector3> clickedGridPoints = new();
    private readonly Dictionary<Vector3Int, Color> originalTileColors = new();

    Vector3 targetPos;

    MenuManager menuManager;
    //PanelManagerScript panelManager;
    public RandomNumberGenerator rndGen;
    int currentIndex = 0;
    public bool isPlayer1Moving;
    public bool isPlayer2Moving;

    [SerializeField]
    Text errorMessage;
    [SerializeField]
    GameObject errorPanel;
    [SerializeField]
    Text winMessage;

    [SerializeField]
    Text instructions;
    [SerializeField]
    GameObject instructionPanel;
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject mapCanvas;
    [SerializeField]
    GameObject stationCanvas;
    [SerializeField]
    GameObject grid;

    bool message2Displayed = false;
    bool message3Displayed = false;
    bool resetClicked = false;
    bool right = true;

    Vector3 housePos1;
    Vector3 housePos2;
    Vector3 housePos3;
    Vector3 housePos4;
    Vector3 housePos5;
    Vector3 housePos6;
    Vector3 housePos7;
    Vector3 housePos8;
    Vector3 housePos9;
    Vector3 housePos10;
    Vector3 housePos11;

    public GameObject cover1;
    public GameObject cover2;
    public GameObject cover3;
    public GameObject cover4;
    public GameObject cover5;
    public GameObject cover6;
    public GameObject cover7;
    public GameObject cover8;
    public GameObject cover9;
    public GameObject cover10;
    public GameObject cover11;

    public bool house1Delivered = false;
    public bool house2Delivered = false;
    public bool house3Delivered = false;
    public bool house4Delivered = false;
    public bool house5Delivered = false;
    public bool house6Delivered = false;
    public bool house7Delivered = false;
    public bool house8Delivered = false;
    public bool house9Delivered = false;
    public bool house10Delivered = false;
    public bool house11Delivered = false;

    public int player1Score = 0;
    public int player2Score = 0;
    public Text score1;
    public Text score2;
    public bool player1Turn = true;
    public GameObject player1Station;
    public GameObject player2Station;
    public GameObject player1Transform;
    public GameObject player2Transform;
    private Color newColor;
    void Start()
    {
        //isConfirmed = false;
        menuManager = FindObjectOfType<MenuManager>();
        rndGen = FindObjectOfType<RandomNumberGenerator>();
        //panelManager = FindAnyObjectByType<PanelManagerScript>();
        isPlayer1Moving = false;
        isPlayer2Moving = false;
        player1Turn = true;

        instructions.text = "To move the player, make a path for the player by clicking certain grid tiles: " +
            "\nThe tiles you click all have to be next to each other, more specifically, the first tile you click has to be next to the player.";
        StartCoroutine(ActivateInstructionMessage(instructionPanel, 12.0f));

        housePos1 = new Vector3(-0.35f, 2.0f, 0f);
        housePos2 = new Vector3(4.4f, 1.2f, 0f);
        housePos3 = new Vector3(-4.4f, 0.4f, 0f);
        housePos4 = new Vector3(-0.4f, 0.4f, 0f);
        housePos5 = new Vector3(-6.8f, -0.4f, 0f);
        housePos6 = new Vector3(-2.8f, -0.4f, 0f);
        housePos7 = new Vector3(2.0f, -0.4f, 0f);
        housePos8 = new Vector3(-2.0f, -2.0f, 0f);
        housePos9 = new Vector3(0.4f, -2.0f, 0f);
        housePos10 = new Vector3(-6.0f, -2.8f, 0f);
        housePos11 = new Vector3(3.6f, -2.8f, 0f);

        StoreOriginalTileColors();
        newColor = Color.grey;
    }

    void StoreOriginalTileColors()
    {
        // Get all the positions of the tiles in the Tilemap
        BoundsInt bounds = tilemap.cellBounds;
        _ = tilemap.GetTilesBlock(bounds);

        foreach (var pos in bounds.allPositionsWithin)
        {
            Vector3Int localPlace = new(pos.x, pos.y, pos.z);
            if (!tilemap.HasTile(localPlace)) continue;

            // Store the original color of each tile if it's not already stored
            if (!originalTileColors.ContainsKey(localPlace))
            {
                originalTileColors.Add(localPlace, tilemap.GetColor(localPlace));
            }
        }
    }
    public void ResetColors()
    {
        foreach (var kvp in originalTileColors)
        {
            tilemap.SetColor(kvp.Key, kvp.Value);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //store the grid cell position of a clicked tile so that we can perform logic to check if it is within rules..
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
            TileBase clickedTile = tilemap.GetTile(cellPos);
            Vector3 tileWorldPos = tilemap.GetCellCenterWorld(cellPos);

            //logic to check if the selected tiles are within game rules
            if (clickedTile != null && !menuManager.isButtonClicked)
            {
                if (clickedGridPoints.Count == 0)
                {
                    //is the first tile clicked close enough to the player?
                    float distanceToPlayer1 = Vector3.Distance(player1.transform.position, tileWorldPos);
                    if (distanceToPlayer1 <= 1.5f && player1Turn)
                    {
                        clickedGridPoints.Add(tileWorldPos);
                        //highlight grid cells
                        tilemap.SetTileFlags(cellPos, TileFlags.None);
                        tilemap.SetColor(cellPos, ConvertToLinearSpace(newColor));

                        if (!message3Displayed)
                        {
                            instructions.text = "The number of tiles you select needs to be within the moves you can make, " +
                                "decided by the random movement value you got. When you are done selecting your path, click on the confirm button.";
                            StartCoroutine(ActivateInstructionMessage(instructionPanel, 12.0f));
                            message3Displayed = true;
                        }
                    }
                    else
                    {
                        if (player1Turn)
                        {
                            //Debug.LogWarning("The clicked tile is not close enough to the player.");
                            errorMessage.text = "The tile you clicked is not close enough to the player!";
                            StartCoroutine(ActivateErrorMessage(errorPanel, 3.0f));
                        }
                    }

                    //is the first tile clicked close enough to the player?
                    float distanceToPlayer2 = Vector3.Distance(player2.transform.position, tileWorldPos);
                    if (distanceToPlayer2 <= 1.5f && !player1Turn)
                    {
                        clickedGridPoints.Add(tileWorldPos);
                        //highlight grid cells
                        tilemap.SetTileFlags(cellPos, TileFlags.None);
                        tilemap.SetColor(cellPos, ConvertToLinearSpace(newColor));
                        if (!message3Displayed)
                        {
                            instructions.text = "The number of tiles you select needs to be within the moves you can make, " +
                                "decided by the random movement value you got. When you are done selecting your path, click on the confirm button.";
                            StartCoroutine(ActivateInstructionMessage(instructionPanel, 10.0f));
                            message3Displayed = true;
                        }
                    }
                    else
                    {
                        if (!player1Turn)
                        {
                            //Debug.LogWarning("The clicked tile is not close enough to the player.");
                            errorMessage.text = "The tile you clicked is not close enough to the player!";
                            StartCoroutine(ActivateErrorMessage(errorPanel, 3.0f));
                        }
                    }
                }
                else
                {
                    //check if tile position exists in list, if yes, do not add it again
                    bool posExists = clickedGridPoints.Contains(tileWorldPos);
                    if (posExists)
                    {
                        //Debug.LogWarning($"Grid position {cellPos} already exists in clickedGridPoints list!");
                        errorMessage.text = "That grid position already exists! If you would like " +
                            "to start your selection of tiles agian, press the reset button.";
                        StartCoroutine(ActivateErrorMessage(errorPanel, 5.0f));
                    }
                    else
                    {
                        //check to see if the tiles are all next to the previous tile the player has selected
                        float distanceToPreviousTile = Vector3.Distance(clickedGridPoints[^1], tileWorldPos);
                        if (distanceToPreviousTile < 1.5f)
                        {
                            clickedGridPoints.Add(tileWorldPos);
                            //highlight grid cells
                            tilemap.SetTileFlags(cellPos, TileFlags.None);
                            tilemap.SetColor(cellPos, ConvertToLinearSpace(newColor));
                        }
                        else
                        {
                            errorMessage.text = "The grid cells you have selected all have to be next to each other!";
                            StartCoroutine(ActivateErrorMessage(errorPanel, 5.0f));
                        }
                    }

                }
            }
        }

        //if confirm is clicked, move player 1 and activate animations accordingly
        if (menuManager.isButtonClicked && player1Turn)
        {
            MovePlayer1ToTile();
            //stop highlighting the path the player took
            ResetColors();
        }
        if (isPlayer1Moving)
        {
            player1Anim.SetBool("notMoving", false);
            player1Anim.SetBool("IsMoving", true);
        }
        else
        {
            player1Anim.SetBool("notMoving", true);
            player1Anim.SetBool("IsMoving", false);
        }

        //if confirm is clicked, move player 2 and activate animations accordingly
        if (menuManager.isButtonClicked && !player1Turn)
        {
            MovePlayer2ToTile();
            //stop highlighting the path the player took
            ResetColors();
            //isPlayer2Moving = true;
        }
        if (isPlayer2Moving)
        {
            player2Anim.SetBool("IsMoving", true);
            player2Anim.SetBool("notMoving", false);
        }
        else
        {
            player2Anim.SetBool("notMoving", true);
            player2Anim.SetBool("IsMoving", false);
        }

        //remind player to click on turn over button when they are done moving 
        if (isPlayer1Moving && !message2Displayed || isPlayer2Moving && !message2Displayed)
        {
            instructions.text = "When your turn is over and your player has moved, click on the 'Turn Over' button";
            StartCoroutine(ActivateInstructionMessage(instructionPanel, 4.0f));
            message2Displayed = true;
        }

        //perform logic when turn over button is clicked to go to the correct station according to which player's turn it is
        if (menuManager.turnOverIsClicked)
        {
            menuManager.isButtonClicked = false;
            //menuManager.turnOverIsClicked = false;
            SwitchTurns();
            if (!player1Turn)
            {
                player1Station.SetActive(true);
                player2Station.SetActive(false);
            }

            if (player1Turn)
            {
                player2Station.SetActive(true);
                player1Station.SetActive(false);
            }
            menuManager.turnOverIsClicked = false;
        }


        //PLAYER 1 DELIVERY
        if (Vector3.Distance(player1.transform.position, housePos1) < 0.4f && !house1Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 1");
            cover1.SetActive(true);
            house1Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house1Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos2) < 0.4f && !house2Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 2");
            cover2.SetActive(true);
            house2Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house2Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos3) < 0.4f && !house3Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 3");
            cover3.SetActive(true);
            house3Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house3Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos4) < 0.4f && !house4Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 4");
            cover4.SetActive(true);
            house4Delivered = true;
            player1Score++;
            score1.text = "Player 1 Score: " + player1Score;
            if (house4Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos5) < 0.4f && !house5Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 5");
            house5Delivered = true;
            cover5.SetActive(true);
            if (house5Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
        }

        if (Vector3.Distance(player1.transform.position, housePos6) < 0.4f && !house6Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 6");
            cover6.SetActive(true);
            house6Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house6Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos7) < 0.4f && !house7Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 7");
            cover7.SetActive(true);
            house7Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house7Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos8) < 0.4f && !house8Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 8");
            cover8.SetActive(true);
            house8Delivered = true;
            //player1Score++;
            //score1.text = "Player 1 Score: " + player1Score;
            if (house8Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos9) < 0.4f && !house9Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 9");
            cover9.SetActive(true);
            house9Delivered = true;
            player1Score++;
            score1.text = "Player 1 Score: " + player1Score;
            if (house9Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos10) < 0.4f && !house10Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 10");
            cover10.SetActive(true);
            house10Delivered = true;
            player1Score++;
            score1.text = "Player 1 Score: " + player1Score;
            if (house10Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player1.transform.position, housePos11) < 0.4f && !house11Delivered)
        {
            Debug.Log("Player 1 has made a delivery to house 11");
            cover11.SetActive(true);
            house11Delivered = true;
            player1Score++;
            score1.text = "Player 1 Score: " + player1Score;
            if (house11Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
                ResetColors();
            }
        }

        //PLAYER 2 DELIVERIES
        if (Vector3.Distance(player2.transform.position, housePos1) < 0.4f && !house1Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 1");
            cover1.SetActive(true);
            house1Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house1Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos2) < 0.4f && !house2Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 2");
            cover2.SetActive(true);
            house2Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house2Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos3) < 0.4f && !house3Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 3");
            cover3.SetActive(true);
            house3Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house3Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos4) < 0.4f && !house4Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 4");
            cover4.SetActive(true);
            house4Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house4Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos5) < 0.4f && !house5Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 5");
            cover5.SetActive(true);
            house5Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house5Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos6) < 0.4f && !house6Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 6");
            cover6.SetActive(true);
            house6Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house6Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos7) < 0.4f && !house7Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 7");
            cover7.SetActive(true);
            house7Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house7Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos8) < 0.4f && !house8Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 8");
            cover8.SetActive(true);
            house8Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house8Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos9) < 0.4f && !house9Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 9");
            cover9.SetActive(true);
            house9Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house9Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos10) < 0.4f && !house10Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 10");
            cover10.SetActive(true);
            house10Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house10Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        if (Vector3.Distance(player2.transform.position, housePos11) < 0.4f && !house11Delivered)
        {
            Debug.Log("Player 2 has made a delivery to house 11");
            cover11.SetActive(true);
            house11Delivered = true;
            //player2Score++;
            //score2.text = "Player 2 Score: " + player2Score;
            if (house11Delivered)
            {
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
                ResetColors();
            }
        }

        //WIN CONDITION
        if (house1Delivered && house2Delivered && house3Delivered && house4Delivered && house5Delivered && house6Delivered && house7Delivered &&
                house8Delivered && house9Delivered && house10Delivered && house11Delivered)
        {
            if (player1Score > player2Score)
            {
                winScreen.SetActive(true);
                player1.SetActive(false);
                player2.SetActive(false);
                mapCanvas.SetActive(false);
                stationCanvas.SetActive(false);
                grid.SetActive(false);
                winMessage.text = "Player 1 Wins!!! \n Maybe Next Time Player 2...";
            }
            else
            {
                if (player2Score > player1Score)
                {
                    winScreen.SetActive(true);
                    player1.SetActive(false);
                    player2.SetActive(false);
                    mapCanvas.SetActive(false);
                    stationCanvas.SetActive(false);
                    grid.SetActive(false);
                    winMessage.text = "Player 2 Wins!!! \n Maybe Next Time Player 1...";
                }
            }
        }
    }


    Color ConvertToLinearSpace(Color color)
    {
        //make the colour lighter by converting it to linear space since the game is not in gamma
        if (QualitySettings.activeColorSpace == ColorSpace.Linear)
        {
            return color.gamma;
        }
        else
        {
            return color;
        }
    }
    private void MovePlayer1ToTile()
    {
        float lerpSpeed = 3.0f;

        if (clickedGridPoints.Count > 0 && clickedGridPoints.Count <= rndGen.randomNumber3)
        {
            //set target position according to the element that matches the current index in the list.
            //this is so that the we can go through all the elements in the list by increasing the current index everytime we lerp to a pos.
            targetPos = clickedGridPoints.ElementAt(currentIndex);
            //Debug.Log(clickedGridPoints[currentIndex]);

            //move player to destination by lerping
            player1.transform.position = Vector3.Lerp(player1.transform.position, targetPos, lerpSpeed * Time.deltaTime);

            //direction rotation
            if (targetPos.x < player1Transform.transform.position.x && right)
            {
                FlipPlayer1();
            }
            if (targetPos.x > player1Transform.transform.position.x && !right)
            {
                FlipPlayer1();
            }
            /*Vector3 direction = targetPos - Camera.main.WorldToScreenPoint(player1.transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/


            //Debug.Log("targetPos: " + targetPos + " world : " + targetPos);
            //Debug.Log("Player Position: " + player1.transform.position);
            isPlayer1Moving = true;

            //if the player arrives at their destination, increase the currentIndex
            if (Vector3.Distance(player1.transform.position, targetPos) < 0.1f)
            {
                currentIndex++;

                //if the current index is equal to the number of elements in the list, set it back to zero and stop the player from moving.
                if (currentIndex >= clickedGridPoints.Count)
                {
                    isPlayer1Moving = false;
                    clickedGridPoints.Clear();
                    currentIndex = 0;
                }
            }
        }
        else
        {
            //if the number of tiles the player has selected exceeds the value in the movement dice roll,
            //display error message and let player select tiles again.
            if (clickedGridPoints.Count > rndGen.randomNumber3)
            {
                errorMessage.text = "The number of tiles you have clicked exceeds the value in the movement dice roll, " +
                    "start selection of tiles over again.";
                menuManager.isButtonClicked = false;
                StartCoroutine(ActivateErrorMessage(errorPanel, 5.0f));
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer1Moving = false;
            }
        }
    }


    private void MovePlayer2ToTile()
    {
        //Perform previous logic to move player 2
        float lerpSpeed = 3.0f;

        if (clickedGridPoints.Count > 0 && clickedGridPoints.Count <= rndGen.randomNumber3)
        {
            targetPos = clickedGridPoints.ElementAt(currentIndex);
            //Debug.Log(clickedGridPoints[currentIndex]);

            //move player to destination by lerping
            player2.transform.position = Vector3.Lerp(player2.transform.position, targetPos, lerpSpeed * Time.deltaTime);

            //direction rotation
            if (targetPos.x < player2Transform.transform.position.x && right)
            {
                FlipPlayer2();
            }
            if (targetPos.x > player2Transform.transform.position.x && !right)
            {
                FlipPlayer2();
            }
            //Debug.Log("targetPos: " + targetPos + " world : " + targetPos);
            //Debug.Log("Player Position: " + player1.transform.position;

            isPlayer2Moving = true;

            if (Vector3.Distance(player2.transform.position, targetPos) < 0.1f)
            {
                currentIndex++;

                if (currentIndex >= clickedGridPoints.Count)
                {
                    clickedGridPoints.Clear();
                    currentIndex = 0;
                    isPlayer2Moving = false;
                }
            }
        }
        else
        {
            if (clickedGridPoints.Count > rndGen.randomNumber3)
            {
                errorMessage.text = "The number of tiles you have clicked exceeds the value in the movement dice roll, " +
                    "start selection of tiles over again.";
                menuManager.isButtonClicked = false;
                StartCoroutine(ActivateErrorMessage(errorPanel, 5.0f));
                clickedGridPoints.Clear();
                currentIndex = 0;
                isPlayer2Moving = false;
            }
        }
    }
    public void Reset()
    {
        //Perfrorm logic to reset the tiles clicked by the player when they click the reset button.
        resetClicked = true;
        if (resetClicked)
        {
            menuManager.isButtonClicked = false;
            resetClicked = true;
            clickedGridPoints.Clear();
            currentIndex = 0;
            isPlayer1Moving = false;
            isPlayer2Moving = false;
            ResetColors();
        }

    }

    private void FlipPlayer1()
    {
        //flip function if the player is not facing the direction that corresponds with the target position
        right = !right;
        player1Transform.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void FlipPlayer2()
    {
        //flip function if the player is not facing the direction that corresponds with the target position
        right = !right;
        player2Transform.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void SwitchTurns()
    {
        //when called, this method switches the player turns
        player1Turn = !player1Turn;
    }

    IEnumerator ActivateErrorMessage(GameObject gameObject, float duration)
    {
        //when called, this method activates a game object for a certain period of time.
        gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

    IEnumerator ActivateInstructionMessage(GameObject gameObject, float duration)
    {
        //when called, this method activates a game object for a certain period of time.
        gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
