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

    int num;
    public void BookChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        DialogueSystem.IsInAction = true;   
        if (gameObject.transform.name == "choice1")
        {
            num = UnityEngine.Random.Range(0, data.SuccessBooks.Count);
            ActionManager.Reading(0);
            system.GetComponent<DialogueSystem>().Begin(data.SuccessBooks[num]);
              
            
        }
        else if (gameObject.transform.name == "choice2")
        {
            num = UnityEngine.Random.Range(0, data.EssayBooks.Count);
            ActionManager.Reading(1);
            system.GetComponent<DialogueSystem>().Begin(data.EssayBooks[num]);
        }
        else if (gameObject.transform.name == "choice3")
        {
            num = UnityEngine.Random.Range(0, data.NovelBooks.Count);
            ActionManager.Reading(2);
            system.GetComponent<DialogueSystem>().Begin(data.NovelBooks[num]);
        }

        ReadingUI.SetActive(false);


    }
}
