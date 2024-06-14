using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGameDatas : MonoBehaviour
{
    public CurrencyData moneyCurrency;
    [SerializeField] Toggle Gider;
    [SerializeField] Toggle Vergi;
    [SerializeField] Toggle Aile;
    
    private void Update()
    {
        if (moneyCurrency.Amount >= 100)
            Gider.interactable = true;
        else if(moneyCurrency.Amount < 100 && !Gider.isOn)
            Gider.interactable = false;

        if (moneyCurrency.Amount >= 50)
            Vergi.interactable = true;
        else if(moneyCurrency.Amount < 50 && !Vergi.isOn)
            Vergi.interactable = false;
        
        if (moneyCurrency.Amount >= 200)
            Aile.interactable = true;
        else if(moneyCurrency.Amount < 200 && !Aile.isOn)
            Aile.interactable = false;

    }
    public void GiderData()
    {
        if (Gider.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount- 100;
        else if (!Gider.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount + 100;
    }
    public void VergiData()
    {
        if (Vergi.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount - 50;
        else if (!Vergi.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount + 50;
    }
    public void AileData()
    {
        if (Aile.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount - 200;
        else if (!Aile.isOn)
            moneyCurrency.Amount = moneyCurrency.Amount + 200;
    }
}
