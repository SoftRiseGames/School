using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalUILister : MonoBehaviour
{
    public List<GameObject> animalObject;
    [SerializeField] List<Vector2> objectTransforms;
    public int ObjectClickControl;
    public GameObject animalAdopt;
    void Start()
    {
        int limiter = animalAdopt.GetComponent<AnimalAdoptationSettings>().textStr.Length;
        Debug.Log(limiter);
        for (int i = 0; i<animalObject.Count ; i++)
        {
            objectTransforms.Add(animalObject[i].transform.position);
            animalObject[i].name = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ObjectReposition();
    }

    void ObjectReposition()
    {
        if(objectTransforms[ObjectClickControl].x == objectTransforms[ObjectClickControl+1].x && animalObject[ObjectClickControl].transform.position.y< animalObject[ObjectClickControl + 1].transform.position.y)
        {
         

            animalObject[ObjectClickControl].name =(ObjectClickControl+1).ToString();
            animalObject[ObjectClickControl+1].name = (ObjectClickControl).ToString();
            
            string uppername = animalObject[ObjectClickControl].name;
            string downername = animalObject[ObjectClickControl + 1].name;

            animalObject.Add(animalObject[ObjectClickControl]);
            animalObject.Add(animalObject[ObjectClickControl + 1]);
            
            animalObject[int.Parse(downername)] = animalObject[animalObject.Count-1];
            animalObject[int.Parse(uppername)] = animalObject[animalObject.Count - 2];
            
         
            animalObject.RemoveAt(animalObject.Count - 1);
            animalObject.RemoveAt(animalObject.Count - 1);
          
            ObjectClickControl = int.Parse(uppername);
            

            Debug.Log("altta");
        }
    }
}
