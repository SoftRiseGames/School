using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class HumanConversationSettings : MonoBehaviour
{
    public HumanLister humans;
    private void Awake()
    {
       
    }
    private void Start()
    {
        humanConversation();
    }
    public void humanConversation()
    {
        Debug.Log(humans.personality);
        if (humans.personality == 1)
            ConversationEnergeticHuman();
        else if (humans.personality == 2)
            ConversationNeutralHuman();
        else if (humans.personality == 3)
            ConversationCalmHuman();
    }
    public void ConversationEnergeticHuman()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Energetic" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
    public void ConversationNeutralHuman()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Neutral" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
    public void ConversationCalmHuman()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Calm" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
    public void IndoorHuman()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Indoor" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
    public void OutdoorHuman()
    {
        int randomintscan = Random.Range(1, 3);
        this.gameObject.GetComponent<DialogueSystemTrigger>().conversation = "Outdoor" + " " + randomintscan.ToString();
        Debug.Log(randomintscan);
    }
}
