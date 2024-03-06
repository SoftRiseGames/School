using UnityEngine;
using DG.Tweening;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private static int lastClickedOrder;

    private void Start()
    {
        lastClickedOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.DOScale(.2f, 0.1f);
        SetSortingOrder(lastClickedOrder + 100);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
   
    private void OnMouseUp()
    {
        transform.DOScale(.3213328f, 0.1f);
        SetSortingOrder(lastClickedOrder + 3);
        lastClickedOrder = GetComponent<SpriteRenderer>().sortingOrder;
        
    }

    private void SetSortingOrder(int order)
    {
        GetComponent<SpriteRenderer>().sortingOrder = order;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = order - 2;
        transform.GetChild(1).GetComponent<Canvas>().sortingOrder = order - 1;
    }
}