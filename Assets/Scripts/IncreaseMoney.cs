using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMoney : MonoBehaviour
{
    public CurrencyData moneyCurrency;

    
    void Update()
    {
        MoneyIncrease(50);
    }

    public int MoneyIncrease(int money)
    {
        moneyCurrency.Amount += money;
        Debug.Log(moneyCurrency.Amount);
        PlayerPrefs.SetInt("MoneyAmount", moneyCurrency.Amount);
        return moneyCurrency.Amount;
    }
}
