using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
public class SceneControl : MonoBehaviour
{
    int isCarSkipped;
    public void animalAccept()
    {
        PlayerPrefs.SetInt("isCarSkipped", isCarSkipped);
        SceneManager.LoadScene(2);
    }
    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }
    public void Adoptation()
    {
        SceneManager.LoadScene(1);
    }

    public void DeleteJsonFiles(string folderPath)
    {
        try
        {
            // Check if the specified directory exists
            if (Directory.Exists(folderPath))
            {
                // Search for JSON files within the directory and its subdirectories
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json", SearchOption.AllDirectories);

                // Loop through each JSON file found and delete it
                foreach (var jsonFilePath in jsonFiles)
                {
                    File.Delete(jsonFilePath);
                    Console.WriteLine($"Deleted: {jsonFilePath}");
                }

                Console.WriteLine("All JSON files have been deleted.");
            }
            else
            {
                Console.WriteLine("Directory not found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ClickDeleter()
    {
#if UNITY_EDITOR
        DeleteJsonFiles(Application.dataPath + "/JsonFolder");
        DeleteJsonFiles(Application.dataPath + "/JsonHumanFolder");

#else
        DeleteJsonFiles(Application.persistentDataPath + "/JsonFolder");
        DeleteJsonFiles(Application.persistentDataPath + "/JsonHumanFolder");
#endif
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }


}
