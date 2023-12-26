using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;
public class AnimalGenerator : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public int onOpenButtons;
    int ControlIndex = -1;
    public Button acceptButton;
    public Button cancelButton;
    private void Start()
    {
        onOpenButtons = Random.Range(1, buttons.Count);
        Generate();
        Invoke("animalIndexControl", 0);
    }
    public void Generate()
    {
       
        foreach (var allbuttons in buttons)
        {
            allbuttons.GetComponent<AnimalSpecials>().animalStatus();
            allbuttons.SetActive(false);
        }
        
    }
    
    public void AcceptAnimal()
    {
        buttons[ControlIndex].GetComponent<AnimalSpecials>().JsonSave();
        buttons[ControlIndex].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(0, 1);
        buttons[ControlIndex].gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>
        {
            buttons[ControlIndex].gameObject.SetActive(false);
            animalIndexControl();
        });
    }
    public void CancelAnimal()
    {
        buttons[ControlIndex].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(0, 1);
        buttons[ControlIndex].gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>
        {
            buttons[ControlIndex].gameObject.SetActive(false);
            animalIndexControl();
        });
        
    }
    void animalIndexControl()
    {
        ControlIndex = ControlIndex + 1;
        
        if (ControlIndex < onOpenButtons)
        {
            buttons[ControlIndex].gameObject.SetActive(true);
            buttons[ControlIndex].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1, 1);
            buttons[ControlIndex].gameObject.GetComponent<SpriteRenderer>().DOFade(1, 1);
            
        }
        if(ControlIndex == onOpenButtons)
        {
            Debug.Log("a");
            acceptButton.gameObject.GetComponent<Button>().interactable = false;
            cancelButton.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}