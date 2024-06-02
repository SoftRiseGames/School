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

    private async void CarCome()
    {
        Car.GetComponent<Animator>().SetBool("isCarCome", true);
        await Task.Delay(10000);
        Car.GetComponent<Animator>().SetBool("isCarGo", true);
    }

    void AfternoonEventManage()
    {
        sky.transform.DOMoveY(-5f, 20f);
    }
    void NightEventManage()
    {
        sky.transform.DOMoveY(-20f, 20f);
    }

    async void CloseEventManage()
    {
        audios.GetComponent<AudioSource>().clip = audios.GetComponent<AudioVoices>().AudioList[0];
        await Task.Delay(100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.DeleteKey("hoursString");
        PlayerPrefs.DeleteKey("minutesString");

    }
   



}
