using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Humans
{
    public string face;
    public string Clothe;
    public string Pant;

}
public class HumanSpecials : MonoBehaviour
{
    public Humans human = new Humans();
    public HumanRandomManager randomizerList;
    public int indexcounter;

    [SerializeField] Sprite face;
    [SerializeField] Sprite Clothe;
    [SerializeField] Sprite Pant;
    void Start()
    {
        wave();
    }


    void Update()
    {
        
    }
   
    void WaveSystem(Humans humandata,Data data)
    {
        int faceRandom = Random.Range(0, data.face.Count);
        face = data.face[faceRandom];
        int clothesrandom = Random.Range(0, data.clothes.Count);
        Clothe = data.clothes[clothesrandom];
        int pantsrandom = Random.Range(0, data.pants.Count);
        Pant = data.pants[pantsrandom];
    }
    void wave()
    {
        int selectedRandomIndex = Random.Range(0, randomizerList.humanData.Count);
        WaveSystem(human,randomizerList.humanData[selectedRandomIndex]);
    }
    public void HumanJsonSave()
    {
        string sprite = JsonUtility.ToJson(human);
        indexcounter++;
        File.WriteAllText(Application.dataPath + "/JsonHumanFolder/jsondata" + indexcounter.ToString() + ".json", sprite);
    }
}
