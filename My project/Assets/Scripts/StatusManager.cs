using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    //주하님 보면 배열로 구현할지 아님 그냥 일일히 변수 선언할지 알려줘용 ♡
    // + 시작스탯 0으로할건지 1로할건지 아님 이미 어느정도 줘놓고 시작할지

    public static int Depress = 20;
    public static int Stress = 20;
    public static int Lonely = 20;
    public static int Anxiety = 20;
    public static int Willingness = 20;
    public static int Happyness = 20;


    //핵심수치
    public TextMeshProUGUI DepNum;
    public TextMeshProUGUI StrNum;
    public TextMeshProUGUI LonNum;
    public TextMeshProUGUI AnxNum;
    public TextMeshProUGUI WilNum;
    public TextMeshProUGUI HapNum;

    //세부수치

    public static int Engknowledge = 1; // 1 ~ 100 까지의 수치, 70 이상일시 우선은 도전과제 달성으로 해놓고 나중에 밸패 필요
    public static float focus = 0.2f; //  0~1까지의 수치
    public static float patience = 0.4f; // 0 ~ 1 까지의 수치, 지금 적어놓은 세부수치는 다 밸런스패치 필요함 ㅠ
    public static int healthy = 30; // 1~100 , 건강수치


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatusIndicate();
    }


    private void StatusIndicate()
    {
        DepNum.text = Depress.ToString();
        StrNum.text = Stress.ToString();
        LonNum.text = Lonely.ToString();
        AnxNum.text = Anxiety.ToString();
        WilNum.text = Willingness.ToString();
        HapNum.text = Happyness.ToString();
    }
    public void StatusChange(int stat)
    {
        // 매개변수를 스탯종류랑 절대값 같이 받을지 아님 그냥 switch써서 할지 모르겠음
    }

}
