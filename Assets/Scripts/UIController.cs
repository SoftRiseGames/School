using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using System.Threading.Tasks;

public class UIController : MonoBehaviour
{

    public TMP_Text respectText;
    public float moveSpeed;
    public int lifetime = 1;
    private RectTransform myRect;

    public HumanLister humanLister;


    void Start()
    {
        textClose();
        myRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRect.anchoredPosition += new Vector2(0f, -moveSpeed * Time.deltaTime);
    }

    public async void textClose()
    {
        await Task.Delay(lifetime);
        this.gameObject.SetActive(false);
    }
}
