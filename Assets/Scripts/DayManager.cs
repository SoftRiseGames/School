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
        await Task.Delay(500);
        AnimalAcceptButton.gameObject.SetActive(true);

    }

    void AfternoonEventManage()
    {
        float targetY = -5;

        sky.transform.DOMoveY(targetY, 20f).OnComplete(() =>
        {
            Clock.AfternoonEvent -= AfternoonEventManage;
        });
    }
    void NightEventManage()
    {
        float targetY = -20;

        sky.transform.DOMoveY(targetY, 20f).OnComplete(() =>
        {
            Clock.NightEvent -= NightEventManage;
        });
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
