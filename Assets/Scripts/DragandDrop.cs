using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragandDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private GameObject[] slices = new GameObject[8];
    private int[] toppingCount = new int[8];
    private bool[] canPlaceTopping = new bool[8];

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToPosition();
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    private void SnapToPosition()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (colliders[i].CompareTag("Slice" + (j + 1)) && canPlaceTopping[j] && toppingCount[j] < 3)
                {
                    transform.position = colliders[i].transform.position;
                    canPlaceTopping[j] = false; // Prevent placing another topping on this slice
                    toppingCount[j]++;
                    return; // Exit the loop after placing the topping on the slice
                }
            }
        }
        // If no valid slice is found, reset the topping to its original position
        transform.position = transform.position - offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; // Ensure the z position is 0
        return mouseWorldPosition;
    }
}





