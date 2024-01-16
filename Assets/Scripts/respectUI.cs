using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class respectUI : MonoBehaviour
{
    public CurrencyData currency;


    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Respect: " + currency.Amount.ToString();
    }
}
