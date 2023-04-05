using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.U2D;
using UnityEngine.UI;

public class episodeChristmas : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;
    public GameObject PhoneWidget;
    public static bool choice;


    private void OnEnable()
    {
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();

        if(gameObject.transform.name == "Christmas") {
            system.GetComponent<DialogueSystem>().Begin(data.EpChrist[0]);
            PhoneWidget.GetComponent<BuffAnim>().enabled = true;
        }
        else if (gameObject.transform.name == "part1")
        {
            system.GetComponent<DialogueSystem>().StartDialogue(2, 4, data.EpChrist);
        }
        else if (gameObject.transform.name == "part3")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpChrist[7]);
        }
        else if (gameObject.transform.name == "part4")
        {
            DialogueSystem.IsInAction = true;
            if (choice) {
                system.GetComponent<DialogueSystem>().Begin(data.EpChrist[9]);
                StatusManager.innerpeace += 30;
            }
            else
            {
                system.GetComponent<DialogueSystem>().Begin(data.EpChrist[10]);
                StatusManager.Anxiety += 15;
                StatusManager.Lonely += 15;
                StatusManager.Depress += 15;
            }
        }

    }
    public void choicePosi()                        //선택지에 클릭시 호출하는 함수
    {
        choice = true;
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        system.GetComponent<DialogueSystem>().StartDialogue(5, 6, data.EpChrist);
    }
    public void choiceNega()
    {
        
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        system.GetComponent<DialogueSystem>().Begin(data.EpChrist[8]);
        
    }
}
