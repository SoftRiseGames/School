using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AnimalAdoptationSettings : MonoBehaviour
{
    public List<GameObject> customer;
    public string[] textStr;
    private string jsonfolders;
    public bool isControlCheck;
    void LoopSync()
    {
        for (int indexcontrol = 0; indexcontrol <= customer.Count; indexcontrol++)
        {
            if (indexcontrol < textStr.Length)
            {
                customer[indexcontrol].gameObject.SetActive(true);
                AnimalData data = JsonUtility.FromJson<AnimalData>(textStr[indexcontrol].ToString());
                customer[indexcontrol].GetComponent<AnimalDataCheck>().animalData = data;
            }
            else if(indexcontrol>= textStr.Length)
            {
                int degree = customer.Count;
                customer.RemoveAt(degree-1);
            }
            
        }
    }
    public void isControlCheckFalse()
    {
        isControlCheck = false;
    }
    public void isControlCheckTrue()
    {
        isControlCheck = true;
    }
    private void Awake()
    {
#if UNITY_EDITOR
        LoadJsonFiles(Application.dataPath + "/JsonFolder");
#else
        LoadJsonFiles(Application.persistentDataPath + "/JsonFolder");
#endif
        LoopSync();
    }
    
    public void LoadJsonFiles(string folderPath)
    {
        try
        {
            // Check if the specified directory exists
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