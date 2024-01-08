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

    [SerializeField] GameObject face;
    [SerializeField] GameObject clothes;
    [SerializeField] GameObject pants;
  

    public List<Data> humanData;
    
   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            Wave();
    }
    void Wave()
    {
        int selectedRandomIndex = Random.Range(0, humanData.Count);
        WaveSystem(humanData[selectedRandomIndex]);
        
    }
    void WaveSystem(Data data)
    {
        int faceRandom = Random.Range(0, data.face.Count);
        face.GetComponent<SpriteRenderer>().sprite = data.face[faceRandom];
        int clothesrandom = Random.Range(0, data.clothes.Count);
        clothes.GetComponent<SpriteRenderer>().sprite = data.clothes[clothesrandom];
        int pantsrandom = Random.Range(0, data.pants.Count);
        pants.GetComponent<SpriteRenderer>().sprite = data.pants[pantsrandom];
    }
}
