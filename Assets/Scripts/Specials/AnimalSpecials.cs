using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class AnimalData
{
    public int Animaltype;
    public int nose;
    public int eyes;
    public int body;
    //
    public int hungryVariable;
    public int thirstyVariable;
    public bool isIll;

    //personality kýsýmlarý için ayarlý yer
    public int personality;
    public int hobbies;

    //personality için 1 en enerjik 3 en tembel
    //hobiler için 1 indoor, 2 ev insaný
}

public class AnimalSpecials : MonoBehaviour
{
    public AnimalData animalclasses = new AnimalData();
    public HumanRandomManager randomizer;
    int indexcounter;
    [SerializeField] int ChanceToIll;
    [SerializeField] int ChanceToHungrySpeed;
    [SerializeField] int ChanceToThirstySpeed;
    private void Start()
    {
        AnimalPersonalities();
        animalTypeSelection();
        animalVisualSettings();
    }

    public void AnimalPersonalities()
    {
        int randompersonality = Random.Range(1, 4);
        int randomhobbie = Random.Range(1, 3);

        animalclasses.personality = randompersonality;
        animalclasses.hobbies = randomhobbie;
    }
    public void animalTypeSelection()
    {
        int randomAnimalType = Random.Range(0, randomizer.animalData.Count);
        animalclasses.Animaltype = randomAnimalType;
        Debug.Log(animalclasses.Animaltype);
    }
    public void animalVisualSettings()
    {
        int animalTypeRandom = Random.Range(0, randomizer.animalData[animalclasses.Animaltype].animaltype.Count);
        animalclasses.nose = Random.Range(0, randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].nose.Count);
        animalclasses.eyes = Random.Range(0, randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].eyes.Count);
        animalclasses.body = Random.Range(0, randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].body.Count);


        Debug.Log(animalTypeRandom);
        
        gameObject.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].body[animalclasses.body];
        gameObject.transform.GetChild(2).transform.GetComponent<SpriteRenderer>().sprite = randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].nose[animalclasses.nose];
        gameObject.transform.GetChild(3).transform.GetComponent<SpriteRenderer>().sprite = randomizer.animalData[animalclasses.Animaltype].animaltype[animalTypeRandom].eyes[animalclasses.eyes];
        
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("indexcounter"))
            indexcounter = PlayerPrefs.GetInt("indexcounter");
    }
    public void animalStatus()
    {
        int HungryRandomize = Random.Range(1, 101);
        int ThirstyRandomize = Random.Range(1, 101);
        int illRandomize = Random.Range(1, 101);

        if (HungryRandomize < ChanceToHungrySpeed)
           animalclasses.hungryVariable = 2;
        else
           animalclasses.hungryVariable = 1;

        if (ThirstyRandomize < ChanceToThirstySpeed)
            animalclasses.thirstyVariable = 2;
        else
           animalclasses.thirstyVariable = 1;

        if (illRandomize < ChanceToIll)
           animalclasses.isIll = true;
        else
           animalclasses.isIll = false;
    }

    public void JsonSave()
    {
        string jsonstring = JsonUtility.ToJson(animalclasses);
        indexcounter++;
        PlayerPrefs.SetInt("indexcounter", indexcounter);
        Debug.Log(jsonstring);

#if UNITY_EDITOR
        File.WriteAllText(Application.dataPath + "/JsonFolder/jsondata" + indexcounter.ToString() + ".json", jsonstring);
#else
        if(!Directory.Exists(Application.persistentDataPath + "/JsonFolder"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/JsonFolder");
        }
        File.WriteAllText(Application.persistentDataPath +"/JsonFolder/jsondata"+indexcounter.ToString()+".json", jsonstring);
        Debug.Log(Application.persistentDataPath + "/JsonFolder/jsondata" + indexcounter.ToString() + ".json");
#endif
    }
}




