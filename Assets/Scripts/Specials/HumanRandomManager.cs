using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Data
{
    public List<Sprite> face;
    public List<Sprite> clothes;
    public List<Sprite> pants;
}
public class HumanRandomManager : MonoBehaviour   
{
    public List<Data> humanData;
}
