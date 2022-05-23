using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public GameObject MouseOverObject;
    ClickManager clickManager;
    public bool isDragged = false; //CardImage.cs 드래그가 끝났냐
    public bool isDragging = false; //드래깅중인가

    void Start()
    {
        clickManager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = DefaultPos;
        MouseOverObject = clickManager.GetMouseOverObject();
        isDragged = true;
    }
}