using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
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
    public RandomManager randomizerList;
    //public GameObject Panels;
    public int indexcounter;
    public TextMeshProUGUI personalityText;
    [SerializeField] Sprite face;
    int humanchecktrue = 0;

    void Start()
    {
        HumanPersonalities();
        SpecialsTextManager();
    }
    public void HumanPersonalities()
    {
        human.personality = Random.Range(1, 4);
        human.hobbies = Random.Range(1, 3);
    }
    void WaveSystem(Data data)
    {
        human.bodyIndex = Random.Range(0, data.body.Count);
        human.clotheIndex = Random.Range(0, data.clothes.Count);
        human.eyesIndex = Random.Range(0, data.eyes.Count);
        human.hairIndex = Random.Range(0, data.hair.Count);
        human.mouthIndex = Random.Range(0, data.mouth.Count);
        human.noseIndex = Random.Range(0, data.nose.Count);
    }
   
    public void wave()
    {
        human.HumanType = Random.Range(0, randomizerList.humanData.Count);
        WaveSystem(randomizerList.humanData[human.HumanType]);
        iconMaker(randomizerList.humanData[human.HumanType]);
        SpecialsTextManager();
    }
    private void Update()
    {
        if(PlayerPrefs.HasKey("humanCount"))
            indexcounter = PlayerPrefs.GetInt("humanCount"); 

    }
    void SpecialsTextManager()
    {
        if(human.HumanType == 0 || human.HumanType == 1)
            personalityText.text = "kiþi " + Random.Range(19, 29).ToString() + " yaþýnda";
        else if(human.HumanType == 2 || human.HumanType == 3)
            personalityText.text = "kiþi " + Random.Range(30, 50).ToString() + " yaþýnda";


    }
   
    public void iconMaker(Data data)
    {
        
        this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = data.body[human.bodyIndex];
        this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = data.clothes[human.clotheIndex];
        this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = data.eyes[human.eyesIndex];
        this.gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = data.hair[human.hairIndex];
        this.gameObject.transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = data.mouth[human.mouthIndex];
        this.gameObject.transform.GetChild(0).GetChild(5).GetComponent<Image>().sprite = data.nose[human.noseIndex];
    }
    public void HumanJsonSave()
    {
        string sprite = JsonUtility.ToJson(human);
        indexcounter++;
        humanchecktrue = 1;
        PlayerPrefs.SetInt("humanchecktrue", humanchecktrue);
        PlayerPrefs.SetInt("humanCount", indexcounter);
        File.WriteAllText(Application.dataPath + "/JsonHumanFolder/jsondata" + indexcounter.ToString() + ".json", sprite);
    }
    public void interact()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
}
