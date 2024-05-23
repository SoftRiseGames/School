using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MarketingButtons : MonoBehaviour
{
    public ButtonScriptableObjects buttons;
    
    public TextMeshProUGUI ObjectName;
    
    public CurrencyData moneyCurrency;

    [SerializeField] FoodFill foodData;
    [SerializeField] WaterFill waterData;
    private void Awake()
    {
        ObjectName = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ObjectName.text = buttons.marketname;
        this.gameObject.GetComponent<Image>().sprite = buttons.sprite;
    }
    private void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = buttons.sprite;
    }

    public void Buy()
    {
        if(moneyCurrency.Amount>buttons.price)
            Money(buttons.price);
    }

    public void WaterDataCheck()
    {
        if(moneyCurrency.Amount > buttons.price)
        {
            if (waterData.waterLevel <= 100)
                waterData.waterLevel += waterData.waterLevel + 50;
            if (waterData.waterLevel > 100)
                waterData.waterLevel = 100;

            PlayerPrefs.SetFloat("waterLevel", waterData.waterLevel);
        }
       
    }
    public void foodDataCheck()
    {
        if (moneyCurrency.Amount > buttons.price)
        {
            if (foodData.foodLevel <= 100)
                foodData.foodLevel += foodData.foodLevel + 50;
            if (foodData.foodLevel > 100)
                foodData.foodLevel = 100;

            PlayerPrefs.SetFloat("foodLevel", foodData.foodLevel);
        }
    }

   
    public int Money(int money)
    {
        moneyCurrency.Amount -= money;
        Debug.Log(moneyCurrency.Amount);
        PlayerPrefs.SetInt("MoneyAmount", moneyCurrency.Amount);
        return moneyCurrency.Amount;
    }
   

}
