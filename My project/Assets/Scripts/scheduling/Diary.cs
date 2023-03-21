using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int selectedActionItemIndex;
    public int[][] actionList;
    public Queue<int> dayPlan = new Queue<int>();
    public Queue<Queue<int>> weekPlan = new Queue<Queue<int>>();
    void OnEnable()
    {
        transform.GetChild(4).gameObject.SetActive(false); //�����ư ��Ȱ��ȭ�� �ʱ� ����
        EpisodeChecker(GameManager.week);   //���Ǽҵ� �ִ� �� ������ �� ����(���� Ȱ��ȭ ��Ȱ��ȭ)
        selectedActionItemIndex = -1;       //�ε����� Ȱ���ϱ� ������ -1�� �ʱ�ȭ (�ʱ�ȭ �� �� �� 0�� �⺻ ���̱� ������ �ƹ� �� ����)  
        actionList = new int[7][];          //������ 7��. �Ϸ�� �ൿ 3���� �⺻, �׷��� ���Ǽҵ�� �ൿ 1��

        for (int i = 0; i < 7; i++)         
        {
            if (transform.GetChild(0).transform.GetChild(i).gameObject.activeSelf)   //���� Ȱ��ȭ üũ
            {
                actionList[i] = new int[] { -1, -1, -1 };
            }
            else
            {
                actionList[i] = new int[] { -1 };
            }
        }
    }
    public void EpisodeChecker(int week)
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
