using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class animals
{
    public int hungryVariable;
    public int thirstyVariable;
    public bool isIll;
}

public class AnimalSpecials : MonoBehaviour
{
    public animals animalclasses = new animals();
    public void animalStatus()
    {
        int HungryRandomize = Random.Range(1, 101);
        int ThirstyRandomize = Random.Range(1, 101);
        int illRandomize = Random.Range(1, 101);

        if (HungryRandomize < 35)
           animalclasses.hungryVariable = 2;
        else
           animalclasses.hungryVariable = 1;

        if (ThirstyRandomize < 35)
            animalclasses.thirstyVariable = 2;
        else
           animalclasses.thirstyVariable = 1;

        if (illRandomize < 35)
           animalclasses.isIll = true;
        else
           animalclasses.isIll = false;
    }

    public void JsonSave()
    {
        string jsonstring = JsonUtility.ToJson(animalclasses);
        Debug.Log(jsonstring);
        File.WriteAllText(Application.dataPath+"/jsonFolders/jsondatas.json", jsonstring);
    }
}




