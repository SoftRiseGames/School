using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private AnimalAdoptationSettings animalAdoptSettings;
    public int layer1;
    public int layer2;
    public int layer3;

    public int lastclicked;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("lastclicked"))
            lastclicked = this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder;
        else
            lastclicked = PlayerPrefs.GetInt("lastclicked");
    }
    private void Start()
    {
        animalAdoptSettings = GameObject.Find("AdopList").GetComponent<AnimalAdoptationSettings>();
    }
    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void Update()
    {
        lastclicked = PlayerPrefs.GetInt("lastclicked");
    }

    private void OnMouseDown()
    {
        if (animalAdoptSettings.isControlCheck)
        {
            this.gameObject.transform.DOScale(.2f, 0.1f);
            mousePosition = gameObject.transform.position - GetMousePosition();
        }

        
        
        this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = lastclicked+ 100;
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = lastclicked+ 98;
        this.gameObject.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = lastclicked+ 99;

        

    }
    private void OnMouseDrag()
    {

        if (animalAdoptSettings.isControlCheck)
            transform.position = GetMousePosition() + mousePosition;
    }
    private void OnMouseUp()
    {
        if (animalAdoptSettings.isControlCheck)
            this.gameObject.transform.DOScale(.3213328f, 0.1f);
        if (!PlayerPrefs.HasKey("lastclicked"))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder = 33;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 31;
            this.gameObject.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 32;

        }
        else
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder =lastclicked+ 3;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = lastclicked + 1;
            this.gameObject.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = lastclicked + 2;
        }
        

        lastclicked = this.gameObject.transform.GetComponent<SpriteRenderer>().sortingOrder;
        PlayerPrefs.SetInt("lastclicked", lastclicked);
    }

}
