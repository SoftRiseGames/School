using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager instance;
    public bool dayEnd;
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != null && instance != this)
            Destroy(this.gameObject);
    }

}
