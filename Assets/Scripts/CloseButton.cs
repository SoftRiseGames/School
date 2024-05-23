using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject Menu;
   
   public void CloseButtonCode()
    {
        Destroy(Menu);
    }
}
