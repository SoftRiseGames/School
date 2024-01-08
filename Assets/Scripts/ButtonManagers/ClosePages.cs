using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ClosePages : MonoBehaviour
{
    public ButtonScriptableObjects buttons;
    public GameObject MainMenu;
    public TextMeshProUGUI ObjectName;
    private void Awake()
    {
        ObjectName.text = buttons.marketname;
        this.gameObject.GetComponent<Image>().sprite = buttons.sprite;
    }
    public void CloseInMarket()
    {
        MainMenu.SetActive(true);
        this.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
