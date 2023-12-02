using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
public class AdoptList : MonoBehaviour
{
    public List<GameObject> customer = new List<GameObject>();
    string jsonfolders;
    public  TextAsset[] text;
    void Start()
    {
        text = Resources.LoadAll<TextAsset>("JsonFolder");

        for (int indexcontrol = 0; indexcontrol < text.Length; indexcontrol++)
        {
            animals data = JsonUtility.FromJson<animals>(text[indexcontrol].ToString());
            customer[indexcontrol].GetComponent<AnimalAdoptaionPrefabs>().thirstyVariable = data.thirstyVariable;
            customer[indexcontrol].GetComponent<AnimalAdoptaionPrefabs>().hungryVariable = data.hungryVariable;
            customer[indexcontrol].GetComponent<AnimalAdoptaionPrefabs>().isIll = data.isIll;
        }
    }
}
