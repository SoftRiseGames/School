using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class DayManager : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject sky;
    [SerializeField] GameObject audios;

    [SerializeField] GameObject Car;
    [SerializeField] GameObject AnimalAcceptButton;

   

    private void Start()
    {
      
    }
    private void OnEnable()
    {
        Clock.AfternoonEvent += AfternoonEventManage;
        Clock.NightEvent += NightEventManage;
        Clock.CloseEvent += CloseEventManage;
        Clock.CarEvent += CarCome;
    }
    private void OnDisable()
    {
        Clock.AfternoonEvent -= AfternoonEventManage;
        Clock.NightEvent -= NightEventManage;
        Clock.CloseEvent -= CloseEventManage;
        Clock.CarEvent -= CarCome;
    }

    private void CarCome()
    {
        
    }

    void AfternoonEventManage()
    {

    }
    void NightEventManage()
    {

    }

    async void CloseEventManage()
    {
        audios.GetComponent<AudioSource>().clip = audios.GetComponent<AudioVoices>().AudioList[0];
        await Task.Delay(100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
   
    private void Update()
    {
        Car.transform.DOMoveX(0.9928551f, .5f).OnComplete(() => { AnimalAcceptButton.gameObject.SetActive(true); });
    }

}
