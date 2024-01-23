using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class AnimalDataCheck : MonoBehaviour
{
    public AnimalData animalData;
    [SerializeField] TextMeshProUGUI kisilik;
    [SerializeField] TextMeshProUGUI evcillik;

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
        
            
    }
}
