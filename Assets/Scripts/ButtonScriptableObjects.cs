using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="new Marketing Button", menuName ="Marketing Button")]
public class ButtonScriptableObjects : ScriptableObject
{
    public string marketname;
    public int price;
    public Sprite sprite;
}
