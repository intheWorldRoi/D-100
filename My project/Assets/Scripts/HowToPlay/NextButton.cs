using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    static int nowIndex;
    public GameObject MainUI;
    public GameObject interfaceUI;
    // Start is called before the first frame update
    void Start()
    {
        nowIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nowIndex);
    }

    public void nextUI()
    {
        if(nowIndex == 1)
        {
            MainUI.SetActive(false);
            interfaceUI.SetActive(true);
            nowIndex = 2;
        }
        
        
    }

    public void previousUI()
    {
        Debug.Log("¿€µø");
        if(nowIndex == 2)
        {
            MainUI.SetActive(true);
            interfaceUI.SetActive(false);
            nowIndex = 1;
        }
        
    }

    public void Escape()
    {
        transform.parent.gameObject.SetActive(false);
        MainUI.SetActive(true);
        interfaceUI.SetActive(false);
    }
}
