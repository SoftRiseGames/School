using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class AnimalGenerator : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    int buttonsize;
    public int onOpenButtons;
    public void Generate()
    {
        foreach (var allbuttons in buttons)
            allbuttons.SetActive(false);

        buttonsize = Random.Range(0, buttons.Count);
        onOpenButtons = buttonsize;

        for (int i = 0; i < buttonsize; i++)
            buttons[i].SetActive(true);
    }
}
