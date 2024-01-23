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
    public GameObject dedectedGameobject;
    bool isPass;
    public CurrencyData currency; //b
    public Slider slider;//b

    int totalCounter;
    
    private void Start()
    {
#if UNITY_EDITOR
        LoadJsonFiles(Application.dataPath + "/JsonHumanFolder");
#else
        LoadJsonFiles(Application.persistentDataPath + "/JsonHumanFolder");
#endif

        Invoke("Generate", 0f);
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
           
            humanConversationTexts.Conversation();
        }
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isPass)
        {
            dedectedGameobject.gameObject.SetActive(false);
            PlayerPrefs.DeleteKey("HungryValue" + dedectedGameobject.name);
            PlayerPrefs.DeleteKey("ThirstyValue" + dedectedGameobject.name);
            Generate();
            Respect(totalCounter);
            dedectedGameobject = null;
            isPass = false;
        }
        Debug.Log(totalCounter);
        slider.value = currency.Amount;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPass = true;
        totalCounter = 0;
        if (collision.CompareTag("Animal"))
        {
            dedectedGameobject = collision.gameObject;

            if (collision.GetComponent<AnimalDataCheck>().animalData.hobbies == human.hobbies )
            {
                Debug.Log("uyumlu");
                totalCounter += 20;
                    
            }
            else if(collision.GetComponent<AnimalDataCheck>().animalData.hobbies != human.hobbies )
            {
                Debug.Log("uyumsuz");
                totalCounter -= 20;
            }

            ///////
            ///eslesme icin
            ///
            if(collision.GetComponent<AnimalDataCheck>().animalData.personality == human.personality )
            {
                Debug.Log("harika eslesme");
                totalCounter += 20;
            }
            else if(collision.GetComponent<AnimalDataCheck>().animalData.personality - human.personality == Math.Abs(1) )
            {
                Debug.Log("ilimli eslesme");
                totalCounter += 10;
            }
            else if (collision.GetComponent<AnimalDataCheck>().animalData.personality - human.personality == Math.Abs(2) )
            {
                Debug.Log("kotu eslesme");
                totalCounter -= 20;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPass = false;
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

    public int Respect(int respecttotal)
    {
        currency.Amount += respecttotal;
        PlayerPrefs.SetInt("RespectAmount", currency.Amount);
        return currency.Amount;
    }
}
