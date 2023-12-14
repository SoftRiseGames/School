using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimalGenerator : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public int onOpenButtons;
    public void Generate()
    {
        foreach (var allbuttons in buttons)
        {
            allbuttons.SetActive(false);
            allbuttons.GetComponent<AnimalSpecials>().animalStatus();
        }
            
        onOpenButtons = Random.Range(1, buttons.Count);
       
        for (int i = 0; i < onOpenButtons; i++)
            buttons[i].SetActive(true);
    }
}
