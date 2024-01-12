using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class sliderSystem : MonoBehaviour
{
    public CurrencyData currency;
    private HumanLister human;//b
    public UnityEngine.UI.Slider slider;
    public float maxSliderValue = 200f;//b
    public float minSliderValue = 0f;//b
    public float sliderChangeRate = 20f;//b
    public float startingValue = 100f;//b
    void Start()
    {
        currency.value = startingValue;//b
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Slider>().value = currency.Amount;
    }
}
