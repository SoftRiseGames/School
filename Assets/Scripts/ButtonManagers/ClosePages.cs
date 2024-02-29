using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class ClosePages : MonoBehaviour
{
    public ButtonScriptableObjects buttons;
    public GameObject MainMenu;
    public TextMeshProUGUI ObjectName;
    private void Awake()
    {
        this.gameObject.GetComponent<Image>().sprite = buttons.sprite;
    }
    public void CloseInMarket()
    {
        MainMenu.SetActive(true);
        this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.DOScale(0, .5f).OnComplete(() => this.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false));
        
    }
}
