using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int Day; //��ĥ�̳� ������
    public static int month; //��
    public static int monthday; //��

    public static string TODAY; // ������ ���� ������
    public static int week; // ���° �� �ΰ�

    public static int money;

    public static bool ending;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Day =1;
            month = 11;
            monthday = 22;
            week =1;

            money = 30;
        }
        
    }
    public static void EndingCheck()
    {
        if(StatusManager.Anxiety >= 100 || StatusManager.Depress >= 100 || StatusManager.Stress >= 100 || StatusManager.Lonely >= 100 || money < 0)
        {
            SceneManager.LoadScene("Ending_GameOver");
            SoundManager.instance.PlayBGM("BadMad");

        }
    }

    public static void Ending()
    {
        if (Day == 100)
        {
            Debug.Log("day == 100");
            if (money > 150)
            {
                SceneManager.LoadScene("Ending_Trip");
            }
            else
            {
                SceneManager.LoadScene("Ending_Nomal");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}
