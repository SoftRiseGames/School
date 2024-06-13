using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum CurrencyType
{
    Money, Respect//b
}


[CreateAssetMenu(menuName ="Scrýptable Objects/Currency Data/Currency")]
public class CurrencyData :ScriptableObject
{
   
    public CurrencyType type;

 
    public int Amount
    {
        get => _amount;
        set
        {
            _amount = Mathf.Max(0, value);
        }
    }
    [SerializeField] int _amount;
}
