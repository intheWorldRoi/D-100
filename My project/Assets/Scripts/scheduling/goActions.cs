using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goActions : MonoBehaviour
{
    public int dayIndex;                                //list[dayIndex][actionIndex] ���� ���� childindex�� ������ �̿�
    public int actionIndex;
    public GameObject Desk;

    

    void OnEnable()
    {
        dayIndex = 0;                                   //go ��ư Ŭ���� Ȱ��ȭ�Ǵ� ������Ʈ�Դ�
        actionIndex = 0;
        //transform.GetChild(0).gameObject.SetActive(true);
    }
    public void nextPlay()                              //�������� ������ ���� 
    {
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);    //�� ������ ����
        if (actionIndex == Diary.actionList[dayIndex].Count)                                          //�Ϸ�ġ �׼��� �� �����ߴ���
        {
            actionIndex = 0;
            dayIndex++;
            GameManager.Day++;
            StatusManager.Lonely += 3;
        }
        if (dayIndex == 7)                                                            //������ġ �׼��� �� �����ߴ���
        {   GameManager.week++;
            gameObject.SetActive(false);                                              //������ 1����ġ �Ϸ�� ������ ��Ȱ��ȭ�� ��ƾ 1 ����
            Desk.SetActive(true);
            Diary.actionList.Clear();
        }
        
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);         //���� ������ Ȱ��ȭ
        switch (Diary.actionList[dayIndex][actionIndex])
        {
            case 0:
                ActionManager.Toeic();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1: 
                ActionManager.Fitness();
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                ActionManager.Reading();
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                ActionManager.Rest();
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                ActionManager.GoOut();
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                ActionManager.Partjob();
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
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