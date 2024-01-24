using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnimalHungryAndThirstyValues : MonoBehaviour
{
    public int HungryValue;
    public int ThirstyValue;
    [SerializeField] TextMeshProUGUI hungrytext;
    [SerializeField] TextMeshProUGUI thirstytext;
    
    [SerializeField] FoodFill foodData;
    [SerializeField] WaterFill waterData;

    int foodchecktrue = 0;
    void Start()
    {
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
    }
    

    public void HungryControl()
    {
        if (HungryValue >= 0 && foodData.foodLevel >= 20)
        {
            HungryValue -= 20;
            foodData.foodLevel = foodData.foodLevel - 20;

            if (foodData.foodLevel < 0)
                foodData.foodLevel = 0;
            if (HungryValue < 0)
                HungryValue = 0;

            foodchecktrue = 1;
            PlayerPrefs.SetInt("foodchecktrue", foodchecktrue);
            PlayerPrefs.SetInt("HungryValue" + this.gameObject.name, HungryValue);
        }
        
    }
    public void ThirstyControl()
    {
        if (ThirstyValue >= 0 && waterData.waterLevel>=20)
        {
            
            ThirstyValue -= 20;
            waterData.waterLevel = waterData.waterLevel - 20;

            if (waterData.waterLevel < 0)
                waterData.waterLevel = 0;

            if (ThirstyValue < 0)
                ThirstyValue = 0;
            foodchecktrue = 1;
            PlayerPrefs.SetInt("foodchecktrue", foodchecktrue);
            PlayerPrefs.SetInt("ThirstyValue" + this.gameObject.name, ThirstyValue);
        }

        
    }
    // Update is called once per frame

    void TextControl()
    {
        hungrytext.text = "Açlýk: %" + HungryValue;
        thirstytext.text = "Susuzluk: %" + ThirstyValue;
    }
    private void Update()
    {
        TextControl();
    }

}
