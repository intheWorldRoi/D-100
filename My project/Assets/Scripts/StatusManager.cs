using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    //���ϴ� ���� �迭�� �������� �ƴ� �׳� ������ ���� �������� �˷���� ��
    // + ���۽��� 0�����Ұ��� 1���Ұ��� �ƴ� �̹� ������� ����� ��������

    public static int Depress = 20;
    public static int Stress = 20;
    public static int Lonely = 20;
    public static int Anxiety = 20;
    public static int Willingness = 20;
    public static int Happyness = 20;


    //�ٽɼ�ġ
    public TextMeshProUGUI DepNum;
    public TextMeshProUGUI StrNum;
    public TextMeshProUGUI LonNum;
    public TextMeshProUGUI AnxNum;
    public TextMeshProUGUI WilNum;
    public TextMeshProUGUI HapNum;

    //���μ�ġ

    public static int Engknowledge = 1; // 1 ~ 100 ������ ��ġ, 70 �̻��Ͻ� �켱�� �������� �޼����� �س��� ���߿� ���� �ʿ�
    public static float focus = 0.2f; //  0~1������ ��ġ
    public static float patience = 0.4f; // 0 ~ 1 ������ ��ġ, ���� ������� ���μ�ġ�� �� �뷱����ġ �ʿ��� ��
    public static int healthy = 30; // 1~100 , �ǰ���ġ


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
        // �Ű������� ���������� ���밪 ���� ������ �ƴ� �׳� switch�Ἥ ���� �𸣰���
    }

}
