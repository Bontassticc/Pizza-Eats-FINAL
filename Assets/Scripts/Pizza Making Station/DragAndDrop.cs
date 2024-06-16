using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public string snapTag;
    private bool toppingSnapped = false;

    public static int points = 0;

    private void Start()
    {
        points = 0;
    }
    private void OnMouseDown()
    {
        if (!toppingSnapped)
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPosition();
        }

        
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToObject();
        Debug.Log(points);
        
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
        
        //peppers = false; pineapple = false; beef = false; chicken = false; cheese = false; mushrooms = false; sauce = false; bacon = false;
    }

    private void SnapToObject()
    {
        // If already snapped, return
        if (toppingSnapped)
            return;

        GameObject[] snapObjects = GameObject.FindGameObjectsWithTag("Block");
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

            CircleCollider2D ownCollider = GetComponent<CircleCollider2D>();
            // Deactivate the collider
            ownCollider.enabled = false;


            string ownTag = gameObject.tag;
            Debug.Log("Own Tag: " + ownTag);
            // Increment points based on ownTag directly
            if (ownTag == "Peppers")
                points++;
            else if (ownTag == "Pineapple")
                points++;
            else if (ownTag == "Beef" || ownTag == "Chicken" || ownTag == "Cheese" || ownTag == "Mushrooms")
                points += 2;
            else if (ownTag == "Sauce")
                points += 4;
            else if (ownTag == "Bacon")
                points += 3;

            toppingSnapped = true;
        }
       
    }

    public static int GetPoints()
    {
        return points;
    }
    public static void ResetPoints()
    {
        points = 0;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}