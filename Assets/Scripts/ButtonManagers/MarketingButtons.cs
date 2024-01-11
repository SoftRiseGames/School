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
        Money(buttons.price);
    }

   
    public int Money(int money)
    {
        moneyCurrency.Amount -= money;
        Debug.Log(moneyCurrency.Amount);
        PlayerPrefs.SetInt("MoneyAmount", moneyCurrency.Amount);
        return moneyCurrency.Amount;
    }
   

}
