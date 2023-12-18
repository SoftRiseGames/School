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
    public string[] textStr;
    public HumanRandomManager randomManager;
    private void Start()
    {
#if UNITY_EDITOR
        LoadJsonFiles(Application.dataPath + "/JsonHumanFolder");
#else
        LoadJsonFiles(Application.persistentDataPath + "/JsonHumanFolder");
#endif

        Invoke("Generate",0f);
    }
    public void Generate()
    {
        if (ControlInteger < textStr.Length-1)
        {
            ControlInteger = ControlInteger + 1;
            Humans data = JsonUtility.FromJson<Humans>(textStr[ControlInteger].ToString());
            body.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].body[data.bodyIndex];
            Clothes.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].clothes[data.clotheIndex];
            eyes.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].eyes[data.eyesIndex];
            hair.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].hair[data.hairIndex];
            mouth.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].mouth[data.mouthIndex];
            nose.GetComponent<SpriteRenderer>().sprite = randomManager.humanData[data.HumanType].nose[data.noseIndex];
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Generate();

        //


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
