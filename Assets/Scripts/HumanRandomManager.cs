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
[System.Serializable]


public class HumanRandomManager : MonoBehaviour   
{
    public List<Data> humanData;
    
    public Sprite face;
    public Sprite clothes;
    public Sprite pants;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            Wave();
    }
    void Wave()
    {
        
    }
   
}
