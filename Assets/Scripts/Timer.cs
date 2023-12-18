using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    int Time = 10;
    public TextMeshProUGUI TimeText;
    public AnimalGenerator animalGenerator;
    public HumanButtonManagement humangenerator;
    void Start()
    {
        animalGenerator.Generate();
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
        foreach(GameObject button in animalGenerator.buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        foreach(GameObject button in humangenerator.buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        animalGenerator.Generate();
        humangenerator.Generate();
        Time = 10;
    }


    public void DecreaseTimer()
    {
        Time--;
    }
}
