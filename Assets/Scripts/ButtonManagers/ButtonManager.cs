using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class ButtonManager : MonoBehaviour
{
    public GameObject ScreenPage;
    public GameObject MainMenu;
 
    public ScreenSystem backgame;
    private void Awake()
    {
        if (this.gameObject.CompareTag("OutMenuButton"))
        {
            ScreenPage = GameObject.Find("ScreenPages/" + this.gameObject.name);
            ScreenPage.SetActive(false);
        }
        backgame = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<ScreenSystem>();
    }
    private void Start()
    {
        MainMenu = GameObject.Find("MonitorInScreen");
    }
    public void OpenPage()
    {
        ScreenPage.SetActive(true);
        ScreenPage.transform.DOScale(.39f, .5f).OnComplete(() => MainMenu.SetActive(false));
    }
    public void ClosePage()
    {
        MainMenu.SetActive(true);
        backgame.Close();
    }

}
