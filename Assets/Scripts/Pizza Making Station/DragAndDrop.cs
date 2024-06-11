using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector2 initialPosition;

    //  inventory slot size
    public float slotSize = 1.0f;
    private Vector2 Slot = new Vector2(0.0f, 0.0f); // Offset of the inventory grid

    public void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Calculate the offset between the object's position and the mouse position
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
                initialPosition = transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                SnapToInventorySlot();
                isDragging = false;
            }
        }

        if (isDragging)
        {
            // Convert the mouse position to world position and add the offset
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            // Update the object's position
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    public void SnapToInventorySlot()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PizzaSlot"))
            {
                // Snap the item to the center of the collided chest slot
                transform.position = collider.bounds.center;
                return;
            }

            if (collider.CompareTag("BowlSlot"))
            {
                // Snap the item to the center of the collided chest slot
                transform.position = collider.bounds.center;
                return;
            }
        }

        // Snap back to the initial position if no collision with chest slots
        transform.position = initialPosition;
    }
}