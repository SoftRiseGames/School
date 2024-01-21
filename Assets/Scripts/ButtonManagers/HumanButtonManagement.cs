using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanButtonManagement : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public int onOpenButtons;

    public void Generate()
    {
        foreach (var allbuttons in buttons)
        {
            allbuttons.SetActive(false);
            allbuttons.transform.GetComponent<HumanSpecials>().wave();
        }

        onOpenButtons = Random.Range(1, buttons.Count);

        for (int i = 0; i < onOpenButtons; i++)
            buttons[i].SetActive(true);
    }
}
