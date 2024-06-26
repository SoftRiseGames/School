using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreenSystem : MonoBehaviour
{
    public CinemachineVirtualCamera MainCam;
    public CinemachineVirtualCamera ScreenCam;
    public GameObject monitor;
    
    public Button[] Sites;

    private void Awake()
    {
      
    }
    private void OnMouseDown()
    {
        MainCam.gameObject.SetActive(false);
        ScreenCam.gameObject.SetActive(true);
        StartCoroutine("isInteractible");
    }
    public void Close()
    {
       
        DeInteractive();
        StopCoroutine("isInteractible");
        
        MainCam.gameObject.SetActive(true);
        ScreenCam.gameObject.SetActive(false);
    }
    // Update is called once per frame
    
    IEnumerator isInteractible()
    {
        
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Sites.Length; i++)
        {
            Sites[i].GetComponent<Button>().interactable = true;
        }
        GetComponent<BoxCollider2D>().enabled = false;

    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.X))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    void DeInteractive()
    {
        for (int i = 0; i < Sites.Length; i++)
        {
            Sites[i].GetComponent<Button>().interactable = false;
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
