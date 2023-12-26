using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;

public class HumanLister : MonoBehaviour
{
    public Humans human;
    
    [SerializeField] GameObject body;
    [SerializeField] GameObject Clothes;
    [SerializeField] GameObject eyes;
    [SerializeField] GameObject hair;
    [SerializeField] GameObject mouth;
    [SerializeField] GameObject nose;
    [SerializeField] int ControlInteger;
    public int personality;
    public int hobby;
    public string[] textStr;
    public HumanConversationSettings humanConversationTexts;
    public HumanRandomManager randomManager;
    private void Awake()
    {
        Invoke("Generate", 0f);
    }
    private void Start()
    {
#if UNITY_EDITOR
        LoadJsonFiles(Application.dataPath + "/JsonHumanFolder");
#else
        LoadJsonFiles(Application.persistentDataPath + "/JsonHumanFolder");
#endif
       

    }
    
    public void Generate()
    {
        if (ControlInteger < textStr.Length-1)
        {
            ControlInteger = ControlInteger + 1;
            human = JsonUtility.FromJson<Humans>(textStr[ControlInteger].ToString());
            body.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].body[human.bodyIndex];
            Clothes.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].clothes[human.clotheIndex];
            eyes.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].eyes[human.eyesIndex];
            hair.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].hair[human.hairIndex];
            mouth.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].mouth[human.mouthIndex];
            nose.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[human.HumanType].nose[human.noseIndex];

            personality = human.personality;
            hobby = human.hobbies;
            if (personality == 1)
                humanConversationTexts.ConversationEnergeticHuman();
            else if (personality == 2)
                humanConversationTexts.ConversationNeutralHuman();
            else if (personality == 3)
                humanConversationTexts.ConversationCalmHuman();

            humanConversationTexts.Conversation();
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Generate();
    }
  
    public void LoadJsonFiles(string folderPath)
    {
        try
        {
           
            if (Directory.Exists(folderPath))
            {
                // Search for JSON files within the directory and its subdirectories
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json", SearchOption.AllDirectories);
                textStr = new string[jsonFiles.Length];
                // Loop through each JSON file found
                for (int i = 0; i < jsonFiles.Length; i++)
                {
                    string jsonFilePath = jsonFiles[i];
                    // Read the contents of the JSON file
                    textStr[i] = File.ReadAllText(jsonFilePath);

                    // Process the JSON content as needed
                }
            }
            else
            {

                Debug.Log(("Directory not found!"));
            }
        }
        catch (Exception ex)
        {
            Debug.Log($"Error: {ex.Message}");

        }
    }
}
