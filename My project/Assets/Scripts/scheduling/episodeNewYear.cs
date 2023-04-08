using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class episodeNewYear : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;

    public static bool choice;


    private void OnEnable()
    {
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();

        if (gameObject.transform.name == "NewYear")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpNewYear[0]);
            Invoke("goNewYearPart1", 4.5f);
        }
        else if (gameObject.transform.name == "part1")
        {
            system.GetComponent<DialogueSystem>().StartDialogue(1, 20, data.EpNewYear);
        }
        else if (gameObject.transform.name == "part2")
        {
            DialogueSystem.IsInAction = true;
            if (choice)
            {
                system.GetComponent<DialogueSystem>().Begin(data.EpNewYear[30]);
                GameManager.money += 20;
            }
            else
            {
                system.GetComponent<DialogueSystem>().Begin(data.EpNewYear[31]);
                StatusManager.Anxiety += 15;
                StatusManager.Stress += 20;
                StatusManager.Depress += 15;
            }
            Invoke("closeNewYear", 10.0f);
        }

    }
    public void choicePosi()                        //선택지에 클릭시 호출하는 함수
    {
        choice = true;
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        system.GetComponent<DialogueSystem>().StartDialogue(21, 24, data.EpNewYear);
    }
    public void choiceNega()
    {
        choice = false;
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        system.GetComponent<DialogueSystem>().StartDialogue(25, 29, data.EpNewYear);

    }

    public void goNewYearPart1()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void closeNewYear()
    {
        transform.parent.gameObject.SetActive(false);
    }
}