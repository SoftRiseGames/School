using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class moneyUI : MonoBehaviour
{
    public CurrencyData currency;


    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Money: " + currency.Amount.ToString();
    }
}
