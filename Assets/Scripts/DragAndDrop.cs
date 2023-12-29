using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private AnimalAdoptationSettings animalAdoptSettings;
    private void Start()
    {
        animalAdoptSettings = GameObject.Find("AdopList").GetComponent<AnimalAdoptationSettings>();
    }
    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
        
    private void OnMouseDown()
    {
        if(animalAdoptSettings.isControlCheck)
            mousePosition = gameObject.transform.position - GetMousePosition(); 
    }
    private void OnMouseDrag()
    {
        if (animalAdoptSettings.isControlCheck)
            transform.position = GetMousePosition() + mousePosition;
    }
}
