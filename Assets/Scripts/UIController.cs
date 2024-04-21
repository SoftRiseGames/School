using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{

    public TMP_Text respectText;
    public float moveSpeed;
    public float lifetime = 1f;
    private RectTransform myRect;

    public HumanLister humanLister;

    public void UpdateRespectCounter(int newRespectValue)
    {
        
    }


    void Start()
    {
        Destroy(gameObject, lifetime);

        myRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRect.anchoredPosition += new Vector2(0f, -moveSpeed * Time.deltaTime);
    }
}
