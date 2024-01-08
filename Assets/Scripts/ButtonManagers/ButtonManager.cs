using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
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
        MainMenu.SetActive(false);
        ScreenPage.SetActive(true);
    }
    public void ClosePage()
    {
        MainMenu.SetActive(true);
        backgame.Close();
    }

}
