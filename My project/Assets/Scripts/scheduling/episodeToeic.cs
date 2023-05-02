using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class episodeToeic : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;

    public static int answer;
    private void OnEnable()
    {
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();

        if (gameObject.transform.name == "ToeicTest")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[0]);
            Invoke("goToeicPart1", 8.5f);
        }
        else if (gameObject.transform.name == "part1")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[1]);
        }
        else if (gameObject.transform.name == "part2")
        {
            DialogueSystem.IsInAction = true;
            if (answer == 2)
            {
                StatusManager.Engknowledge += 15;
            }
            else if (answer == 1)
            {
                StatusManager.Engknowledge += 5;
            }
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[4]);
            Invoke("closeToeic", 10.0f);
        }

    }
    public void choicePosi()                        //선택지에 클릭시 호출하는 함수
    {
        answer++;
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        if (gameObject.transform.name == "LCposi")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[2]);
        }
        else if (gameObject.transform.name == "RCposi")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[3]);
        }
    }
    public void choiceNega()
    {
        data = dataManager.GetComponent<DialogueData>();
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        gameObject.transform.parent.gameObject.SetActive(false);
        if(gameObject.transform.name == "LCnega")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[2]);
        }
        else if(gameObject.transform.name == "RCnega")
        {
            system.GetComponent<DialogueSystem>().Begin(data.EpToeic[3]);
        }
    }

    public void goToeicPart1()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void closeToeic()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
