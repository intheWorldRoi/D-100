using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    StatusManager manager;

    public static string readingBook;


    public static void Toeic()
    {
        StatusManager.Engknowledge += 3 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); // ���� ������ ���߷� * (0.01 * ��Ʈ����) * ������ ���� ����
        StatusManager.Happyness -= 5; //��ſ� 5 ����
        StatusManager.Stress += (int)(0.003 * (StatusManager.Anxiety * StatusManager.Depress)); // ��� * �Ҿ� * 0.003 ��ŭ ��Ʈ���� ����
        
    }

    public static void Fitness()
    {
        StatusManager.healthy += 5 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); //�ǰ��� ���߷� * ��Ʈ���� /100 * ������ ���� ����
    }

    public static void Reading()
    {
        if (readingBook == "�ڱ��߼�")
        {
            StatusManager.Anxiety += 5;
            StatusManager.Willingness += 5;
            StatusManager.Happyness -= 3;
        }
        else if (readingBook == "������")
        {
            StatusManager.Depress -= (int)(5 * (StatusManager.Stress / 100 * StatusManager.Happyness / 10));
        }
        else if (readingBook == "�Ҽ�")
        {
            StatusManager.Happyness += (int)(5 * StatusManager.Stress / 100 * StatusManager.Willingness /10);
        }
    }

    public static void Rest()
    {
        StatusManager.Anxiety += 5;
        StatusManager.Willingness += 5;
        StatusManager.Happyness += 5; // �ٵ� �� �� �ູ �����ϴ°͵� ��Ʈ������ ������ �޾ƾ��ϳ�...?��������������    
    }

    public static void GoOut()
    {

    }

    public static void Partjob()
    {
        GameManager.money += 50000;
        StatusManager.Stress += (int)(3 * StatusManager.Stress / 10);
    }

    
}
