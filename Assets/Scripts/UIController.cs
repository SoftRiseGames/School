using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//ben
public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private void Awake()
    {
            Instance = this;
    }

    public GameObject MoneyText;//ben

    void Start()
    {
        MoneyText = GameObject.FindObjectOfType<GameObject>();//ben
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
