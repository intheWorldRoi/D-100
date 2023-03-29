using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject diary;
    public GameObject desk;
    public GameObject playActions;

    public void HideDiary()          //exit ��ư���� ����
    {
        diary.SetActive(false);
    }
    public void HideAndReveal()      //Go ��ư�� �޷� �ְ� ��ư ������ ���̾ ����� ����ũ ����.
    {                                //����ũ�� ���̾ �θ����� ��ƾ �� �� ������ ����� ���̾, ����ũ �� �� ��Ȱ��ȭ
        DialogueSystem.IsInAction = true;
        Debug.Log(Diary.actionList[0][0]);
        diary.SetActive(false);
        desk.SetActive(false);
        

        switch (Diary.actionList[0][0])
        {
            case 0:
                ActionManager.Toeic();
                playActions.GetComponent<ActionDialog>().ToeicDialogue();
                playActions.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                
                break;
            case 1:
                ActionManager.Fitness();
                playActions.GetComponent<ActionDialog>().FitnessDialogue();
                playActions.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                
                break;
            case 2:
                ActionManager.Reading();
                playActions.GetComponent<ActionDialog>().ReadingDialogue();
                playActions.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                
                break;
            case 3:
                ActionManager.Rest();
                playActions.GetComponent<ActionDialog>().RestDialogue();
                playActions.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                
                break;
            case 4:
                ActionManager.GoOut();
                playActions.GetComponent<ActionDialog>().GoOutDialogue();
                playActions.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                
                break;
            case 5:
                ActionManager.Partjob();
                playActions.GetComponent<ActionDialog>().AlbaDialogue();
                playActions.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                
                break;
        }
        playActions.SetActive(true);      //goAction�� �׼��� �����ϴ� ������Ʈ���� �θ�.(�����ۿ� �Ű��� ����)

        
    }

    public void RemoveText()              //go ��ư ���� �� �÷��� �ؽ�Ʈ �ʱ�ȭ
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < Diary.actionList[i].Count; j++)
            {
                diary.transform.GetChild(0).transform.GetChild(i).transform.GetChild(j).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            }

        }
    }
}
