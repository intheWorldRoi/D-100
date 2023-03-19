using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    //���ϴ� ���� �迭�� �������� �ƴ� �׳� ������ ���� �������� �˷���� ��
    // + ���۽��� 0�����Ұ��� 1���Ұ��� �ƴ� �̹� ������� ����� ��������

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
        // �Ű������� ���������� ���밪 ���� ������ �ƴ� �׳� switch�Ἥ ���� �𸣰���
    }

}
