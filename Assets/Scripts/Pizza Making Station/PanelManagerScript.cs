using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagerScript : MonoBehaviour
{
    public GameObject confirm;
    public GameObject turnOver;
    public GameObject displayMoves;
    public GameObject instructionPanel;
    public GameObject reset;
    public GameObject scores;

    public GameObject grid;
    public GameObject player1;
    public GameObject player2;

    public GameObject stationCanvas;


    public void GridMap()
    {
        if (grid != null)
        {
            bool isActive = grid.activeSelf;

            grid.SetActive(!isActive);
            player1.SetActive(!isActive);
            player2.SetActive(!isActive);
            confirm.SetActive(!isActive);
            turnOver.SetActive(!isActive);
            displayMoves.SetActive(!isActive);
            reset.SetActive(!isActive);
            scores.SetActive(!isActive);

            stationCanvas.SetActive(isActive);
            instructionPanel.SetActive(false);
        }
    }
}
