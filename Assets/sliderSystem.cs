using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class sliderSystem : MonoBehaviour
{
    public CurrencyData currency;
    public HumanLister human;
    public UnityEngine.UI.Slider slider;
    public float maxSliderValue = 200f;
    public float minSliderValue = 0f;
    public float sliderChangeRate = 20f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Slider>().value = currency.Amount;
    }
}
