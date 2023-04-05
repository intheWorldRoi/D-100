using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScreen : MonoBehaviour
{
    bool CountReady = true; //½ºÅ©·ÑÀ» ÂßÂßÂß ³»¸®´Â °Å ¸»°í
    int Count;

    public GameObject manager;
    public GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Count);
        if(Input.mouseScrollDelta.y != 0 && CountReady)
        {
            Count++;
            CountReady = false;
            Invoke("ReadyToCount", 1f);
        }

        if(gameObject.name == "ToeicScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSToeic[0]);
            Count = 0;
            DialogueSystem.IsInAction = true;
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if(gameObject.name == "FitnessScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSFitness[0]);
        }

        
        
    }

    void ReadyToCount()
    {
        CountReady = true;
    }
}
