using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderSystem : MonoBehaviour
{
    public CurrencyData currency;
    
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Slider>().value = currency.Amount;
    }
}
