using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    //주하님 보면 배열로 구현할지 아님 그냥 일일히 변수 선언할지 알려줘용 ♡
    // + 시작스탯 0으로할건지 1로할건지 아님 이미 어느정도 줘놓고 시작할지

    public int Depress = 1;
    public int Stress = 1;
    public int Lonely = 1;
    public int Anxiety = 1;
    public int Willingness = 1;
    public int Happyness = 1;


    public TextMeshProUGUI DepNum;
    public TextMeshProUGUI StrNum;
    public TextMeshProUGUI LonNum;
    public TextMeshProUGUI AnxNum;
    public TextMeshProUGUI WilNum;
    public TextMeshProUGUI HapNum;


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
