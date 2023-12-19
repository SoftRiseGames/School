using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class AnimalMonitorCheck : MonoBehaviour
{
    public string[] textStr;
    public GameObject[] allAnimals;
    void Start()
    {
       
#if UNITY_EDITOR
        LoadJsonFiles(Application.dataPath + "/JsonFolder");
#else
        LoadJsonFiles(Application.persistentDataPath + "/JsonFolder");
#endif
        animalChecking();

    }
    private void Update()
    {
        
    }
    // Update is called once per frame

    void animalChecking()
    {

        foreach(GameObject animals in allAnimals)
        {
            animals.gameObject.SetActive(false);
        }

        for(int i = 0; i<textStr.Length; i++)
        {
            allAnimals[i].gameObject.SetActive(true);
            AnimalData data = JsonUtility.FromJson<AnimalData>(textStr[i].ToString());
            allAnimals[i].GetComponent<AnimalScreenData>().animaldata = data;
        }
        
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
