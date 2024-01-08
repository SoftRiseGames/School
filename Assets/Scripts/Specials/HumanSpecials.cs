using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Humans
{
    public int HumanType;
    public int bodyIndex;
    public int clotheIndex;
    public int eyesIndex;
    public int hairIndex;
    public int mouthIndex;
    public int noseIndex;

    public int personality;
    public int hobbies;

    //personality için 1 en enerjik 3 en tembel
    //hobiler için 1 indoor, 2 ev insaný

}
public class HumanSpecials : MonoBehaviour
{
    public Humans human = new Humans();
    public HumanRandomManager randomizerList;
    public int indexcounter;

    [SerializeField] Sprite face;
    
    void Start()
    {
        HumanPersonalities();
    }
    public void HumanPersonalities()
    {
        int randompersonality = Random.Range(1, 4);
        int randomhobbie = Random.Range(1, 3);

        human.personality = randompersonality;
        human.hobbies = randomhobbie;
    }
    void WaveSystem(Data data)
    {
        int bodyRandom = Random.Range(0, data.body.Count);
        face = data.body[bodyRandom];
        human.bodyIndex = bodyRandom;
        int clothesrandom = Random.Range(0, data.clothes.Count);
        human.clotheIndex = clothesrandom;
        int eyesRandom = Random.Range(0, data.eyes.Count);
        human.eyesIndex = eyesRandom;
        int hairRandom = Random.Range(0, data.hair.Count);
        human.hairIndex = hairRandom;
        int mouthRandom = Random.Range(0, data.mouth.Count);
        human.mouthIndex = mouthRandom;
        int noseRandom = Random.Range(0, data.nose.Count);
        human.noseIndex = noseRandom;
    }
    public void wave()
    {
        int selectedRandomIndex = Random.Range(0, randomizerList.humanData.Count);
        human.HumanType = selectedRandomIndex;
        WaveSystem(randomizerList.humanData[selectedRandomIndex]);
        iconMaker(randomizerList.humanData[human.HumanType]);
    }
    private void Update()
    {
        if(PlayerPrefs.HasKey("humanCount"))
            indexcounter = PlayerPrefs.GetInt("humanCount"); 

    }
    public void iconMaker(Data data)
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = data.body[human.bodyIndex];
        this.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = data.clothes[human.clotheIndex];
        this.gameObject.transform.GetChild(3).GetComponent<Image>().sprite = data.eyes[human.eyesIndex];
        this.gameObject.transform.GetChild(4).GetComponent<Image>().sprite = data.hair[human.hairIndex];
        this.gameObject.transform.GetChild(5).GetComponent<Image>().sprite = data.mouth[human.mouthIndex];
        this.gameObject.transform.GetChild(6).GetComponent<Image>().sprite = data.nose[human.noseIndex];
    }
    public void HumanJsonSave()
    {
        string sprite = JsonUtility.ToJson(human);
        indexcounter++;
        PlayerPrefs.SetInt("humanCount", indexcounter);
        File.WriteAllText(Application.dataPath + "/JsonHumanFolder/jsondata" + indexcounter.ToString() + ".json", sprite);
    }
}
