using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderSystem : MonoBehaviour
{
    public CurrencyData currency;
    private HumanLister human;//b
    public Slider slider;
    public float maxSliderValue = 200f;//b
    public float minSliderValue = 0f;//b
    public float sliderChangeRate = 20f;//b
    public float startingValue = 100f;//b
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Slider>().value = currency.Amount;
    }
}
