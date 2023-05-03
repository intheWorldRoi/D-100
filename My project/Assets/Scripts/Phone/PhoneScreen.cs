using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScreen : MonoBehaviour
{
    bool CountReady = true; //½ºÅ©·ÑÀ» ÂßÂßÂß ³»¸®´Â °Å ¸»°í
    int Count;

    public GameObject manager;
    public GameObject dialog;
    
    public GameObject christmas;
    public GameObject[] ScrollObjects;
    // Start is called before the first frame update
    
    void Update()
    {
        Debug.Log(Count);
        if(Input.mouseScrollDelta.y != 0 && CountReady)
        {
            SoundManager.instance.PlaySound("instaHeart", 0.5f);
            Count++;
            GetComponent<RectTransform>().position += Vector3.up * 650;
            CountReady = false;
            Invoke("ReadyToCount", 0.5f);
        }

        if (gameObject.name == "ToeicScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSToeic[0]);
            Count = 0;
            DialogueSystem.IsInAction = true;
            transform.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            GetComponent<RectTransform>().position += Vector3.down * 650*3;
        }
        else if (gameObject.name == "FitnessScreen" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.SNSFitness[0]);
            Count = 0;
            DialogueSystem.IsInAction = true;
            transform.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            GetComponent<RectTransform>().position += Vector3.down * 650 * 3;
        }
        else if (gameObject.name == "EpiChrist" && Count >= 3)
        {
            DialogueData data = manager.GetComponent<DialogueData>();
            DialogueSystem system = dialog.GetComponent<DialogueSystem>();
            system.Begin(data.EpChrist[1]);
            Count = 0;
            transform.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            GetComponent<RectTransform>().position += Vector3.down * 650 * 3;
            Invoke("goChristPart1", 4f);
        }
        if(Count >= 3)
        {
            for(int i = 0; i < ScrollObjects.Length; i++)
            {
                ScrollObjects[i].SetActive(false);
            }
        }

    }

    void ReadyToCount()
    {
        CountReady = true;
    }
    void goChristPart1()
    {
        gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        christmas.transform.GetChild(0).gameObject.SetActive(true);
    }
}
