using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Data
{
    public List<Sprite> body;
    public List<Sprite> clothes;
    public List<Sprite> eyes;
    public List<Sprite> hair;
    public List<Sprite> mouth;
    public List<Sprite> nose;
    
}
[System.Serializable]
public class NameSurname
{
    public List<string> name;
    public List<string> surname;
}
public class HumanRandomManager : MonoBehaviour   
{
    public List<Data> humanData;
    public List<NameSurname> nameAndSurname;
}
