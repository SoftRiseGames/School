using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnimalManager : MonoBehaviour
{
    public AnimalScriptable animalScriptable;
    void Start()
    {

        gameObject.transform.GetComponent<SpriteRenderer>().sprite = animalScriptable.AnimalImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
