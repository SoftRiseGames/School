using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Humans
{
    public int HumanType;
    public int faceIndex;
    public int ClotheIndex;
    public int PantIndex;

}
public class HumanSpecials : MonoBehaviour
{
    public Humans human = new Humans();
    public HumanRandomManager randomizerList;
    public int indexcounter;

    [SerializeField] Sprite face;
    
    void Start()
    {
        wave();
    }
    void WaveSystem(Data data)
    {
        int faceRandom = Random.Range(0, data.face.Count);
        face = data.face[faceRandom];
        human.faceIndex = faceRandom;
        int clothesrandom = Random.Range(0, data.clothes.Count);
        human.ClotheIndex = clothesrandom;
        int pantsrandom = Random.Range(0, data.pants.Count);
        human.PantIndex = pantsrandom;
    }
    void wave()
    {
        int selectedRandomIndex = Random.Range(0, randomizerList.humanData.Count);
        human.HumanType = selectedRandomIndex;
        WaveSystem(randomizerList.humanData[selectedRandomIndex]);
    }
    public void HumanJsonSave()
    {
        string sprite = JsonUtility.ToJson(human);
        indexcounter++;
        PlayerPrefs.SetInt("humanCount", indexcounter);
        File.WriteAllText(Application.dataPath + "/JsonHumanFolder/jsondata" + indexcounter.ToString() + ".json", sprite);
    }
}
