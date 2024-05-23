using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class TutorialNextStepScripts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI humanaccept;
    [SerializeField] TextMeshProUGUI animalaccept;
    [SerializeField] TextMeshProUGUI animalFeed;

    [SerializeField] GameObject Car;
    [SerializeField] GameObject AnimalAcceptButton;
    [SerializeField] GameObject AdoptationButton;

    // Update is called once per frame

    void Update()
    {
        
        /*
        
        if (PlayerPrefs.HasKey("humanchecktrue"))
        {
            humanaccept.color = Color.green;
            if(!PlayerPrefs.HasKey("isCarSkipped"))
                Car.transform.DOMoveX(0.9928551f, .5f).OnComplete(() => { AnimalAcceptButton.gameObject.SetActive(true); });


        }
        else
            humanaccept.color = Color.white;

        if (PlayerPrefs.HasKey("foodchecktrue"))
        {
            animalFeed.color = Color.green;
            AdoptationButton.gameObject.SetActive(true);
        }
            
        else
            animalFeed.color = Color.white;

        if (PlayerPrefs.HasKey("animalchecktrue"))
            animalaccept.color = Color.green;
        else
            animalaccept.color = Color.white;

     */
    }
        
    
}
