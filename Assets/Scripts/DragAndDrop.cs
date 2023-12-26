using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
        
    private void OnMouseDown()
    {
        mousePosition = gameObject.transform.position - GetMousePosition();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + mousePosition;
    }
}
