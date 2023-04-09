using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PhoneScreen : MonoBehaviour
{
    bool CountReady = true; //½ºÅ©·ÑÀ» ÂßÂßÂß ³»¸®´Â °Å ¸»°í
    int Count;

    public GameObject manager;
    public GameObject dialog;
    
    public GameObject christmas;
    // Start is called before the first frame update
    
    void Update()
    {
        Debug.Log(Count);
        if(Input.mouseScrollDelta.y != 0 && CountReady)
        {
            Count++;
            CountReady = false;
            Invoke("ReadyToCount", 1f);
        }

        if (gameObject.name == "ToeicScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSToeic[0]);
            StatusManager.Stress += 10;
            Count = 0;
            DialogueSystem.IsInAction = true;
            transform.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (gameObject.name == "FitnessScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSFitness[0]);
            StatusManager.Stress += 10;
            Count = 0;
            DialogueSystem.IsInAction = true;
            transform.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (gameObject.name == "EpiChrist" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.EpChrist[1]);
            Count = 0;
            gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
            Invoke("goChristPart1", 3.5f);
        }

    }

    void ReadyToCount()
    {
        CountReady = true;
    }
    void goChristPart1()
    {
        christmas.transform.GetChild(0).gameObject.SetActive(true);
    }
}
