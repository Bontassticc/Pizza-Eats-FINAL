using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPosition;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()

    {
       
        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallBack = OnDragEnded;
        }
    }

    // Update is called once per frame
    private void OnDragEnded(Draggable draggable)
    {
        print("yeet");
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPosition)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            closestDistance = currentDistance;
            closestSnapPoint = snapPoint;
        }
        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}

      


