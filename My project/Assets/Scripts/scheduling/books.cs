using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class books : MonoBehaviour
{
    public int bookIndex =-1;

    public GameObject    ReadingUI;

    public GameObject dataManager;

    DialogueData data;

    public void BookChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        DialogueSystem.IsInAction = true;   
        if (gameObject.transform.name == "choice1")
        {
            
            ActionManager.Reading(0);
            system.GetComponent<DialogueSystem>().Begin(data.SuccessBooks[0]);
              
            
        }
        else if (gameObject.transform.name == "choice2")
        {
            ActionManager.Reading(1);
            system.GetComponent<DialogueSystem>().Begin(data.EssayBooks[0]);
        }
        else if (gameObject.transform.name == "choice3")
        {
            ActionManager.Reading(2);
            system.GetComponent<DialogueSystem>().Begin(data.NovelBooks[0]);
        }

        ReadingUI.SetActive(false);


    }
}
