using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int Day = 1; //��ĥ�̳� ������
    public static int month = 11; //��
    public static int monthday = 22; //��

    public static string TODAY; // ������ ���� ������
    public static int week =1; // ���° �� �ΰ�

    public static int money = 30;

    public static void EndingCheck()
    {
        SoundManager s = SoundManager.instance;
        if(StatusManager.Anxiety >= 100 || StatusManager.Depress >= 100 || StatusManager.Stress >= 100 || StatusManager.Lonely >= 100)
        {
            SceneManager.LoadScene(1);
            s.PlayBGM("BadMad");

        }
        if(money < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    

    private void Update()
    {
        if(Day == 100)
        {
            if(StatusManager.innerpeace > 80 && StatusManager.Engknowledge > 100 && StatusManager.healthy > 80)
            {
                //�𿣵��� �θ���
            }
            
        }
    }

    

    
}
