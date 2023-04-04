using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class play : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ReadingUI;
    public GameObject GoOutUI;

    public GameObject dataManager;
    DialogueData data;

    bool sns;
    bool pnp;

    private void OnEnable()
    {
        var actionManager = transform.parent.gameObject.GetComponent<ActionManager>();
        sns = actionManager.SNS();
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();

        var index = transform.GetSiblingIndex();

        if (sns) 
        {
            if ((index != 3) || (index != 4))
            {
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[0]);
                return;
            }
        }
        else
            pnp= actionManager.PNP();

        switch (transform.GetSiblingIndex())
        {
            case 0:
                ActionManager.Toeic(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playToeic[Convert.ToInt16(pnp)]);
                Debug.Log(Convert.ToInt16(pnp));
                break;
            case 1:
                ActionManager.Fitness(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playFitness[Convert.ToInt16(pnp)]);
                break;
            case 2:
                //ActionManager.Reading();
                
                DialogueSystem.IsInAction = false; //안 넘어가게 하기, 이벤트 처리 후 true로 바꾸고 NextSchedule()을 부른다.
                ReadingUI.SetActive(true);
                system.GetComponent<DialogueSystem>().Begin(data.playReadingBook[0]);
                break;
            case 3:
                ActionManager.Rest(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playRest[0]);
                break;
            case 4:
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
                ActionManager.GoOut();
                DialogueSystem.IsInAction = false;  //안 넘어가게 하기, 이벤트 처리 후 true로 바꾸고 NextSchedule()을 부른다.
                GoOutUI.SetActive(true);
                system.GetComponent<DialogueSystem>().Begin(data.playGoOut[0]); 
                break;
            case 5:
                ActionManager.Partjob(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playAlba[Convert.ToInt16(pnp)]);
                break;
        }
        
    }

}

