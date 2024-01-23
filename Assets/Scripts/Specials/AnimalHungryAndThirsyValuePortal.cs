using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHungryAndThirsyValuePortal : MonoBehaviour
{
    public int HungryValue;
    public int ThirstyValue;
    void Start()
    {
        HungryValue = PlayerPrefs.GetInt("HungryValue" + this.gameObject.name);
        ThirstyValue = PlayerPrefs.GetInt("ThirstyValue" + this.gameObject.name);
    }

    
}
