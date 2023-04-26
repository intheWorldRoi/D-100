using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    static int nowIndex;
    public GameObject[] UI;
    
    // Start is called before the first frame update
    void Start()
    {
        nowIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nowIndex);
    }

    public void nextUI()
    {
        
        if(nowIndex != UI.Length -1)
        {
            UI[nowIndex].SetActive(false);
            UI[nowIndex + 1].SetActive(true);
            nowIndex++;
        }
        else
        {
            UI[0].SetActive(true);
            UI[nowIndex].SetActive(false);
            nowIndex = 0;
        }
        
        
    }

    public void previousUI()
    {
        Debug.Log("¿€µø");
        if(nowIndex != 0)
        {
            UI[nowIndex].SetActive(false);
            UI[nowIndex - 1].SetActive(true);
            nowIndex--;
        }
        else
        {
            UI[UI.Length - 1].SetActive(true);
            UI[nowIndex].SetActive(false);
            nowIndex = UI.Length -1;
        }
        
    }

    public void Escape()
    {
        transform.parent.gameObject.SetActive(false);
        for(int i = 0; i < UI.Length; i++)
        {
            if(i == 0)
            {
                UI[i].SetActive(true);
            }
            else
            {
                UI[i].SetActive(false);
            }
        }
        
    }
}
