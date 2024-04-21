using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    int Time = 10;
    public TextMeshProUGUI TimeText;

    public HumanButtonManagement humangenerator;
    void Start()
    {
       
        humangenerator.Generate();
        InvokeRepeating("DecreaseTimer", 1, 1);
    }

    private void Update()
    {
        TimeText.text = Time.ToString();
        if (Time <= 0)
            generating();
    }
    void generating()
    {
        foreach(GameObject button in humangenerator.buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        humangenerator.Generate();
        Time = 10;
    }

   
    public void DecreaseTimer()
    {
        Time--;
    }
}
