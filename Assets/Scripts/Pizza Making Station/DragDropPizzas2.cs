using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDropPizzas2 : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public string snapTag;
    private bool pizzaSnapped = false;
    int pointsToAdd = 0;
    private GameObject parent = null;

    public PlayerMovement playerMove;
    //DragAndDrop dragDrop;
    //public Text player1Score;
    public Text player2Score;

    Vector3 targetRotation = new Vector3(65f, 10f, 0f);
    Vector3 targetScale = new Vector3(2300f, 3500f, 1800f);

    public DragAndDropPizzas firstScript;

    private void Start()
    {
        //dragDrop = FindObjectOfType<DragAndDrop>();
        //firstScript = FindObjectOfType<DragAndDropPizzas>();
    }

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


            if (playerMove.house1Delivered && !firstScript.house1)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house1 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                    ClearParentReference();
                }
            }

            if (playerMove.house2Delivered && !firstScript.house2)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house2 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                    ClearParentReference();
                }
            }

            if (playerMove.house3Delivered && !firstScript.house3)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house3 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                    ClearParentReference();
                }
            }

            if (playerMove.house4Delivered && !firstScript.house4)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house4 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house5Delivered && !firstScript.house5)
            {
                Debug.Log("script is there");
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house5 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house6Delivered && !firstScript.house6)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house6 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house7Delivered && !firstScript.house7)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house7 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house8Delivered && !firstScript.house8)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house8 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house9Delivered && !firstScript.house9)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house9 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house10Delivered && !firstScript.house10)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house10 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

            if (playerMove.house11Delivered && !firstScript.house11)
            {
                if (!playerMove.player1Turn)
                {
                    playerMove.player2Score += pointsToAdd;
                    player2Score.text = "Player 2 Score: " + playerMove.player2Score;
                    firstScript.house11 = true;
                    if (parent != null)
                        DestroyChildObjects(parent);
                    pointsToAdd = 0;
                ClearParentReference();
            }
            }

    }

    private void SnapToInventory()
    {
        // If already snapped, return
        if (pizzaSnapped)
        return;

        GameObject[] snapObjects = GameObject.FindGameObjectsWithTag("HotBar2");
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
            //parent the current pizza to the hot bar so that it stays there
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

    void ClearParentReference()
    {
        parent = null;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}

