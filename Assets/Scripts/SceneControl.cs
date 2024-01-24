using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl : MonoBehaviour
{
    int isCarSkipped;
    public void animalAccept()
    {
        PlayerPrefs.SetInt("isCarSkipped", isCarSkipped);
        SceneManager.LoadScene(2);
    }
    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }
    public void Adoptation()
    {
        SceneManager.LoadScene(1);
    }

}
