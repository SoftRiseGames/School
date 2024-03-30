using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimalUILister : MonoBehaviour
{
    public List<GameObject> animalObject;
    [SerializeField] List<Vector2> objectTransforms;
    public int ObjectClickControl;
    public GameObject animalAdopt;

    void Start()
    {
        int limiter = animalAdopt.GetComponent<AnimalAdoptationSettings>().textStr.Length;
   
        for (int i = 0; i<=animalObject.Count ; i++)
        {
            if (i < limiter)
            {
                objectTransforms.Add(animalObject[i].transform.position);
                animalObject[i].name = i.ToString();
            }
            else if(i>= limiter)
            {
                int degree = animalObject.Count;
                animalObject.RemoveAt(degree - 1);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        ObjectReposition();
        objectTweening();
    }

    

    void ObjectReposition()
    {
        //aþaðý gitmek için

        if (ObjectClickControl < animalObject.Count - 1 &&
        objectTransforms[ObjectClickControl].x == objectTransforms[ObjectClickControl + 1].x &&
        animalObject[ObjectClickControl].transform.position.y < animalObject[ObjectClickControl + 1].transform.position.y)
        {
            if (Vector2.Distance(animalObject[ObjectClickControl].transform.position, animalObject[ObjectClickControl + 1].transform.position) < .5f)
            {
                animalObject[ObjectClickControl].name = (ObjectClickControl + 1).ToString();
                animalObject[ObjectClickControl + 1].name = (ObjectClickControl).ToString();

                string uppername = animalObject[ObjectClickControl].name;
                string downername = animalObject[ObjectClickControl + 1].name;

                animalObject.Add(animalObject[ObjectClickControl]);
                animalObject.Add(animalObject[ObjectClickControl + 1]);

                animalObject[int.Parse(downername)] = animalObject[animalObject.Count - 1];
                animalObject[int.Parse(uppername)] = animalObject[animalObject.Count - 2];


                animalObject.RemoveAt(animalObject.Count - 1);
                animalObject.RemoveAt(animalObject.Count - 1);

                
                ObjectClickControl = int.Parse(uppername);

                Debug.Log("altta");
            }
        }
        //yukarý için

        else if ((ObjectClickControl > 0 && ObjectClickControl <= animalObject.Count-1) &&
    objectTransforms[ObjectClickControl].x == objectTransforms[ObjectClickControl - 1].x &&
    animalObject[ObjectClickControl].transform.position.y > animalObject[ObjectClickControl - 1].transform.position.y)
        {
            if (Vector2.Distance(animalObject[ObjectClickControl].transform.position, animalObject[ObjectClickControl - 1].transform.position) < .5f)
            {
                animalObject[ObjectClickControl].name = (ObjectClickControl - 1).ToString();
                animalObject[ObjectClickControl - 1].name = (ObjectClickControl).ToString();

                string uppername = animalObject[ObjectClickControl - 1].name;
                string downername = animalObject[ObjectClickControl].name;
                Debug.Log(downername);

                animalObject.Add(animalObject[ObjectClickControl]);
                animalObject.Add(animalObject[ObjectClickControl - 1]);


                animalObject[int.Parse(downername)] = animalObject[animalObject.Count - 2];
                animalObject[int.Parse(uppername)] = animalObject[animalObject.Count - 1];

                animalObject.RemoveAt(animalObject.Count - 1);
                animalObject.RemoveAt(animalObject.Count - 1);

                
                ObjectClickControl = int.Parse(downername);
            }
        }
      
    }

    public void objectTweening()
    {
        foreach(GameObject i in animalObject)
        {
            if(!i.GetComponent<DragAndDrop>().isMove)
                i.transform.DOMove(objectTransforms[int.Parse(i.name)], .1f);
        }
    }
   

}
