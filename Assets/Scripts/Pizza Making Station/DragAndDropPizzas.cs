using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropPizzas : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public string snapTag;
    private bool pizzaSnapped = false;
    int pointsToAdd = 0;
    GameObject parent = null;

    public PlayerMovement playerMove;
    //DragAndDrop dragDrop;
    public Text player1Score;
    //public Text player2Score;

    public bool house1 = false;
    public bool house2 = false;
    public bool house3 = false;
    public bool house4 = false;
    public bool house5 = false;
    public bool house6 = false;
    public bool house7 = false;
    public bool house8 = false;
    public bool house9 = false;
    public bool house10 = false;
    public bool house11 = false;

    Vector3 targetRotation = new Vector3(65f, 10f, 0f);
    Vector3 targetScale = new Vector3(2300f, 3500f, 1800f);


    private void OnMouseDown()
    {
        if (!pizzaSnapped)
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToInventory();
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }

        if (playerMove.house1Delivered && !house1)
        {
            
            if (playerMove.player1Turn)
            {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
            }
            DestroyChildObjects(parent);
            house1 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house2Delivered && !house2)
        {
            
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house2 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house3Delivered && !house3)
        {
            
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house3 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house4Delivered && !house4)
        {
            
                if(playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house4 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house5Delivered && !house5)
        {
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house5 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house6Delivered && !house6)
        {
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house6 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house7Delivered && !house7)
        {
            
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house7 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house8Delivered && !house8)
        {
            
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house8 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house9Delivered && !house9)
        {
            
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house9 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house10Delivered && !house10)
        {
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house10 = true;
            pointsToAdd = 0;
            
        }

        if (playerMove.house11Delivered && !house11)
        {
                if (playerMove.player1Turn)
                {
                    playerMove.player1Score += pointsToAdd;
                    player1Score.text = "Player 1 Score: " + playerMove.player1Score;
                }
            DestroyChildObjects(parent);
            house11 = true;
            pointsToAdd = 0;
            
        }
    }

    private void SnapToInventory()
    {
        // If already snapped, return
        if (pizzaSnapped)
            return;

        GameObject[] snapObjects = GameObject.FindGameObjectsWithTag("HotBar1");
        float shortestDistance = Mathf.Infinity;
        GameObject closestObject = null;

        foreach (GameObject obj in snapObjects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestObject = obj;
            }
        }

        if (closestObject != null)
        {
            transform.position = closestObject.transform.position;
            //parent the current topping to the pizza base so that it stays there
            transform.SetParent(closestObject.transform);
            transform.rotation = Quaternion.Euler(targetRotation);
            transform.localScale = targetScale;
            pizzaSnapped = true;
            parent = closestObject;
            pointsToAdd = DragAndDrop.GetPoints();
            DragAndDrop.ResetPoints();

        }
    }

    void DestroyChildObjects(GameObject parentObject)
    {
        // Find all child GameObjects of parentObject and destroy them
        foreach (Transform child in parentObject.transform)
        {
            GameObject childObject = child.gameObject;
            Destroy(childObject);
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}
