using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimalHungryAndThirsyValuePortal : MonoBehaviour
{
    public int HungryValue;
    public int ThirstyValue;

    [SerializeField] TextMeshProUGUI hungrytext;
    [SerializeField] TextMeshProUGUI thirstytext;

    void Start()
    {
        HungryValue = PlayerPrefs.GetInt("HungryValue" + this.gameObject.name);
        ThirstyValue = PlayerPrefs.GetInt("ThirstyValue" + this.gameObject.name);

        
        if (PlayerPrefs.HasKey("HungryValue"+this.gameObject.name))
            HungryValue = PlayerPrefs.GetInt("HungryValue"+this.gameObject.name);
        else
        {
            HungryValue = Random.Range(50, 100);
            PlayerPrefs.SetInt("HungeryValue" + this.gameObject.name, HungryValue);
        }
            

        if (PlayerPrefs.HasKey("ThirstyValue"+this.gameObject.name))
            ThirstyValue = PlayerPrefs.GetInt("ThirstyValue"+this.gameObject.name);
        else
        {
            ThirstyValue = Random.Range(50, 100);
            PlayerPrefs.SetInt("ThirstyValue" + this.gameObject.name, ThirstyValue);
        }

        void TextControl()
        {
            hungrytext.text = "Açlýk: %" + HungryValue;
            thirstytext.text = "Susuzluk: %" + ThirstyValue;
        }


    }



}
