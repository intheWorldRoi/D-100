using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goActions : MonoBehaviour
{
    public int dayIndex;                                //list[dayIndex][actionIndex] ���� ���� childindex�� ������ �̿�
    public int actionIndex;
    public GameObject Desk;

    

    

    void OnEnable()
    {
        dayIndex = 0;                                   //go ��ư Ŭ���� Ȱ��ȭ�Ǵ� ������Ʈ�Դ�
        actionIndex = 0;
    }
    public void nextPlay()                              //�������� ������ ���� 
    {
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);    //�� ������ ����
        if (actionIndex == Diary.actionList[dayIndex].Count)                                          //�Ϸ�ġ �׼��� �� �����ߴ���
        {
            actionIndex = 0;
            dayIndex++;
            GameManager.Day++;
            StatusManager.DayCalculate();
            StatusManager.Lonely += 3;
        }
        if (dayIndex == 7)                                                            //������ġ �׼��� �� �����ߴ���
        {   GameManager.week++;
            gameObject.SetActive(false);                                              //������ 1����ġ �Ϸ�� ������ ��Ȱ��ȭ�� ��ƾ 1 ����
            Desk.SetActive(true);
            Diary.actionList.Clear();
            DialogueSystem.IsInAction = false;
        }
        
        
        switch (Diary.actionList[dayIndex][actionIndex])
        {
            case 0:
                ActionManager.Toeic();
                transform.GetComponent<ActionDialog>().ToeicDialogue();
                
                break;
            case 1: 
                ActionManager.Fitness();
                transform.GetComponent<ActionDialog>().FitnessDialogue();
                
                break;
            case 2:
                //ActionManager.Reading();
                transform.GetComponent<ActionDialog>().ReadingDialogue();
                break;
            case 3:
                ActionManager.Rest();
                transform.GetComponent<ActionDialog>().RestDialogue();
                break;
            case 4:
                ActionManager.GoOut();
                transform.GetComponent<ActionDialog>().GoOutDialogue();
                break;
            case 5:
                ActionManager.Partjob();
                transform.GetComponent<ActionDialog>().AlbaDialogue();
                break;
        }
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);         //���� ������ Ȱ��ȭ
    }
}

/*private void OnEnable()
 {
     StartCoroutine(perform(Diary.actionList));
 }
 IEnumerator perform (List<List<int>> actionList)
 {
     for (int i = 0; i < actionList.Count; i++)
     {
         for(int j = 0; j < actionList[i].Count; j++)
         {
             transform.GetChild(actionList[i][j]).gameObject.SetActive(true);
             yield return new WaitForSeconds(2.0f);
         }
     }
 }*/