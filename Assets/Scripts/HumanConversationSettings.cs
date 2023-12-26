using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Threading.Tasks;

public class HumanConversationSettings : MonoBehaviour
{
    public HumanLister humans;
    
  
    public async void Conversation()
    {
        await Task.Delay(100);  
        this.gameObject.GetComponent<DialogueSystemTrigger>().enabled = true;
        Debug.Log(humans.personality);
        if (humans.personality == 1)
            ConversationEnergeticHuman();
        else if (humans.personality == 2)
            ConversationNeutralHuman();
        else if (humans.personality == 3)
            ConversationCalmHuman();
        await Task.Delay(100);
        this.gameObject.GetComponent<DialogueSystemTrigger>().enabled = false;
        LifeStyle();
    }

    public async void LifeStyle()
    {
        await Task.Delay(100);
        this.gameObject.GetComponent<DialogueSystemTrigger>().enabled = true;
        if (humans.hobby == 1)
            IndoorHuman();
        else if (humans.hobby == 2)
            OutdoorHuman();
        await Task.Delay(100);
        this.gameObject.GetComponent<DialogueSystemTrigger>().enabled = false;
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
