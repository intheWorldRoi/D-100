using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class scheduler : MonoBehaviour
{
    private bool isClick = false;

    private void OnMouseDown()
    {
        if (isClick)
        {
            isClick = false;
        }
        else
        {
            isClick = true;
        }
        callScheduler();
    }

    void callScheduler()
    {
        if (isClick)
        {
            GameObject.Find("weekly").SetActive(false);
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("weekly").gameObject.SetActive(true);
        }
    }

}
