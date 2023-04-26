using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;

public class widgetBtn : MonoBehaviour
{
    public GameObject HowToUI;

    private void Start()
    {
        transform.GetComponent<BuffAnim>().enabled = true;
    }
    public void HowToPlay()
    {
        HowToUI.SetActive(true);
        GetComponent<UI.Image>().color = new Color(1, 1, 1, 1);
        transform.GetComponent<BuffAnim>().enabled = false;
    }
}
