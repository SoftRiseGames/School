using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName ="AnimalTypes", fileName ="AnimalTypes")]
public class AnimalScriptable : ScriptableObject
{
    public Image AnimalImage;
    public bool isHappy;
    public bool isSick;

}
