using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public int CPS; //CharPerSecond = �ӵ�
    TextMeshProUGUI msgtext;
    int index;

    float interval;

    public GameObject endcursor;

    private void Awake()
    {
        msgtext = GetComponent<TextMeshProUGUI>();
    }



    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
        
    }

    private void EffectStart()
    {
        msgtext.text = "";
        index = 0;
        endcursor.SetActive(false);
        interval = 1.0f / CPS;
        //Debug.Log(interval);

        Invoke("Effecting", 1/CPS); 
    }
    private void Effecting()
    {
        if(msgtext.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgtext.text += targetMsg[index];
        index++;
        Invoke("Effecting", interval);
    }

    private void EffectEnd()
    {
        endcursor.SetActive(true);
    }
}
