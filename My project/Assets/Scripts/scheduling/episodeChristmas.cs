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

        if (gameObject.transform.name == "Christmas")
        {
            SoundManager.instance.PlayBGM("christmas");
            system.GetComponent<DialogueSystem>().Begin(data.EpChrist[0]);
            PhoneWidget.GetComponent<BuffAnim>().enabled = true;
        }
        else if (gameObject.transform.name == "part1")
        {
            system.GetComponent<DialogueSystem>().StartDialogue(2, 4, data.EpChrist);
        }
        else if (gameObject.transform.name == "part3")
        {
            GameManager.money -= 5;
            system.GetComponent<DialogueSystem>().StartDialogue(7, 31, data.EpChrist);
        }
        else if (gameObject.transform.name == "part4")
        {
            if (choice)
            {
                system.GetComponent<DialogueSystem>().Begin(data.EpChrist[33]);
                StatusManager.innerpeace += 30;
            }
            else
            {
                system.GetComponent<DialogueSystem>().Begin(data.EpChrist[34]);
                StatusManager.Anxiety += 10;
                StatusManager.Lonely += 10;
                StatusManager.Depress += 10;
            }
            PhoneWidget.GetComponent<Button>().interactable = true;
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
        system.GetComponent<DialogueSystem>().Begin(data.EpChrist[32]);

    }

    /*public void closeChrist()
    {
        PhoneWidget.GetComponent<Button>().enabled = true;
        transform.parent.gameObject.SetActive(false);
        SoundManager.instance.PlayBGM("main");
    }*/
}
