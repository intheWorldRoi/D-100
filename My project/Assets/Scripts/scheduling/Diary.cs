using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int selectedActionItemIndex;
    static public List<List<int>> actionList = new List<List<int>>();
    bool check = false; 
    void OnEnable()
    {
        transform.GetChild(4).gameObject.SetActive(false); //�����ư ��Ȱ��ȭ�� �ʱ� ����
        EpisodeChecker(GameManager.week);   //���Ǽҵ� �ִ� �� ������ �� ����(���� Ȱ��ȭ ��Ȱ��ȭ)
        selectedActionItemIndex = -1;       //�ε����� Ȱ���ϱ� ������ -1�� �ʱ�ȭ (�ʱ�ȭ �� �� �� 0�� �⺻ ���̱� ������ �ƹ� �� ����)  
        
        if (actionList.Count == 0){                                 //���̾ ���� �ѵ� ����
            for (int i = 0; i < 7; i++)
            {
                actionList.Add(new List<int>());

                if (transform.GetChild(0).transform.GetChild(i).gameObject.activeSelf)   //���� Ȱ��ȭ üũ
                {
                    for(int j = 0; j < 3; j++)
                        actionList[i].Add(-1);
                }
                else
                {
                    actionList[i].Add(6);
                }
            }
        }   
        Go();                                              //�÷��� ���� �״� �ص� plan Ŭ�� ���� ��������� go ��ư�� �־�� ��
    }
    void Go()                                                    //go ��ư Ȱ��ȭ�ϴ� �Լ� Panning �� �Լ��� ������
    {
        
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < actionList[i].Count; j++)
            {
                if (actionList[i][j] == -1)
                {
                    check = false;
                    return;
                }
                else
                    check = true;
            }
        }
        if (check)
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    public void EpisodeChecker(int week)                                        //���Ǽҵ� ó��
    {
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(true);

        transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(false);

        switch (week)
        {
            case 5:
                transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 9:
                transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
                break ;
            case 11:
                transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
