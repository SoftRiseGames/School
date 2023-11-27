using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    int Time = 10;
    public TextMeshProUGUI TimeText;
    public AnimalGenerator animalGenerator;
    
    void Start()
    {
        animalGenerator.Generate();
        InvokeRepeating("DecreaseTimer", 1, 1);
    }

    public void DecreaseTimer()
    {
        Time--;
    }


    private void Update()
    {
        TimeText.text = Time.ToString();

        if (Time <= 0)
            generating();
    }
    void generating()
    {
        animalGenerator.Generate();
        Time = 10;
    }
}
