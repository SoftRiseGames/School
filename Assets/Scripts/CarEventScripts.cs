using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEventScripts : MonoBehaviour
{
    [SerializeField] GameObject AcceptButton;
    public void AcceptButtontrueValue() => AcceptButton.SetActive(true);
    public void AcceptButtonFalseValue() => AcceptButton.SetActive(false);

    public void AnimationReset() 
    {
        gameObject.GetComponent<Animator>().SetBool("isCarCome", false);
        gameObject.GetComponent<Animator>().SetBool("isCarGo", false);

    }



}