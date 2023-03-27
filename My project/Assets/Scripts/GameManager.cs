using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string playername;

    public static int Day = 1;

    public static string TODAY; // 오늘은 무슨 요일인가

    public static int week =1; // 몇번째 주 인가

    public static int money = 100000;
    // Start is called before the first frame update
    void Start()
    {
    //이거 string 어케입력받냐 ?.. getkey는 반환값이 0이나 1이지 않아? 우리는 string 받아야됨     
    }

    // Update is called once per frame
    void Update()   
    {
    }
}
