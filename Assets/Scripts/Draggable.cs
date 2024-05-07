using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Draggable : MonoBehaviour

  {
 public delegate void DragEndDelegate(Draggable draggableObject);

public DragEndDelegate dragEndedCallBack;

private bool isDragged = false;
private Vector3 mouseDragStartPosition;
private Vector3 spriteDragStartPosition;
public bool isSnapped;

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        if ( isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
    private void OnMouseUp() 
    {
        isDragged = false;
        dragEndedCallBack(this);
    }
}
