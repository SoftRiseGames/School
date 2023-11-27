using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ButtonManager : MonoBehaviour
{
    public GameObject ScreenPage;
 
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
 
    public void OpenPage()
    {
        ScreenPage.SetActive(true);
    }
    public void ClosePage()
    {
        backgame.Close();
    }

}
