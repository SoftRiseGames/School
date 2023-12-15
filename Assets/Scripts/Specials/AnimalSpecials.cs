using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class AnimalData
{
    public int hungryVariable;
    public int thirstyVariable;
    public bool isIll;
}

public class AnimalSpecials : MonoBehaviour
{
    public AnimalData animalclasses = new AnimalData();
    int indexcounter;
    [SerializeField] int ChanceToIll;
    [SerializeField] int ChanceToHungrySpeed;
    [SerializeField] int ChanceToThirstySpeed;
    private void Start()
    {
        /*
        if (PlayerPrefs.HasKey("indexcounter"))
            indexcounter = PlayerPrefs.GetInt("indexcounter");
        else
            indexcounter = 0;
        */
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
        this.gameObject.GetComponent<Button>().interactable = false;
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




