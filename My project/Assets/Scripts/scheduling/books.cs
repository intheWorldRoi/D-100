using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class books : MonoBehaviour
{
    public int bookIndex =-1;

    public GameObject ReadingUI;

    public GameObject dataManager;

    DialogueData data;

  

    private void Start()
    {
        
    }
    public void BookChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        if (gameObject.transform.name == "choice1")
        {
            DialogueSystem.StopNextPlay = false;
            ActionManager.Reading(0);
            system.GetComponent<DialogueSystem>().BeginSchedule(data.ReadingBooks[0]);
              
            
        }
        else if (gameObject.transform.name == "choice2")
        {
            ActionManager.Reading(1);
        }
        else if (gameObject.transform.name == "choice3")
        {
            ActionManager.Reading(2);
        }


    }
}
