using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class AnimalDataCheck : MonoBehaviour
{
    public AnimalData animalData;
    [SerializeField] RandomManager RandomManager;
    [SerializeField] TextMeshProUGUI kisilik;
    [SerializeField] TextMeshProUGUI evcillik;
    [SerializeField] GameObject body;
    [SerializeField] GameObject eyes;
    [SerializeField] GameObject nose;
    private void Start()
    {
        if (animalData.personality == 1)
            kisilik.text = "Enerjik";
        else if (animalData.personality == 2)
            kisilik.text = "Ilýmlý";
        else if (animalData.personality == 3)
            kisilik.text = "Tembel";

        if (animalData.hobbies == 1)
            evcillik.text = "Ev hayvaný";
        else if (animalData.hobbies == 2)
            evcillik.text = "Dýþarý hayvaný";

        DataChecker();
        
    }
    private void Update()
    {
        
    }
    void DataChecker()
    {
        
        body.GetComponent<SpriteRenderer>().sprite = RandomManager.animalData[animalData.AnimalHighType].animaltype[animalData.AnimalLowType].body[animalData.body];
        eyes.GetComponent<SpriteRenderer>().sprite = RandomManager.animalData[animalData.AnimalHighType].animaltype[animalData.AnimalLowType].eyes[animalData.eyes];
        nose.GetComponent<SpriteRenderer>().sprite = RandomManager.animalData[animalData.AnimalHighType].animaltype[animalData.AnimalLowType].nose[animalData.nose];
        
    }
}
