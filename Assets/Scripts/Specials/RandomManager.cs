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
[System.Serializable]
public class animalData
{
    public List<animalType> animaltype;
}
[System.Serializable]
public class animalType
{
    public List<Sprite> nose;
    public List<Sprite> body;
    public List<Sprite> eyes;
}
public class RandomManager : MonoBehaviour   
{
    public List<Data> humanData;
    public List<animalData> animalData;
    public List<NameSurname> nameAndSurname;
}

