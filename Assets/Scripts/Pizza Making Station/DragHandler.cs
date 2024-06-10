using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ShopItem boughtItem;

    public Image image;

    [HideInInspector] public Transform setAsParent;

    public void InitialiseBoughtItem(ShopItem newItem)
    {
        boughtItem = newItem;
        image.sprite = newItem.sprite;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        setAsParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(setAsParent);
        image.raycastTarget = true;

    }
}
