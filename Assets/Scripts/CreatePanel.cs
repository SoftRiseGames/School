using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePanel : MonoBehaviour
{
    [SerializeField] GameObject Panels;
   

    public void OpenPanel() => Instantiate(Panels, new Vector2(1.5f,-2.5f), Quaternion.identity);

}
