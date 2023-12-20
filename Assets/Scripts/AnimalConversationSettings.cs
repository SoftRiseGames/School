using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class AnimalConversationSettings : MonoBehaviour
{
    public List<DialogueDatabase> dialogueData; 
    void Start()
    {
        ConversationStart();
    }

    public void ConversationStart()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Mutlu" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
}
