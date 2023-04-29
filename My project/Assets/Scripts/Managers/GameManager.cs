using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int Day; //¸çÄ¥ÀÌ³ª Áö³µ³ª
    public static int month; //¿ù
    public static int monthday; //ÀÏ

    public static string TODAY; // ¿À´ÃÀº ¹«½¼ ¿äÀÏÀÎ
    public static int week; // ¸î¹øÂ° ÁÖ ÀÎ°¡

    public static int money;

    private void Awake()
    {
        Day = 1;
        month = 11;
        monthday = 22;
        week = 5;

        money = 0;
    }
    public static void EndingCheck()
    {
        SoundManager s = SoundManager.instance;
        if(StatusManager.Anxiety >= 100 || StatusManager.Depress >= 100 || StatusManager.Stress >= 100 || StatusManager.Lonely >= 100 || money < 0)
        {
            SceneManager.LoadScene(1);
            s.PlayBGM("BadMad");

        }
    }

    private void Update()
    {
        if(week == 15)
        {
            if(StatusManager.innerpeace > 80 && StatusManager.Engknowledge > 100 && StatusManager.healthy > 80)
            {
                //Âð¿£µù¾À ºÎ¸£±â
            }
            
        }
    }

    

    
}
