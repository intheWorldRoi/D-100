using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueData : MonoBehaviour
{
    string myname;

    Dictionary<int, string[]> TextData;

    public List<Dialogue> ReadingBooks;

    private void Awake()
    {
        
        

    }

    private void OnMouseDown()
    {
        //TextData[100];
    }



    void GenerateData()
    {
        TextData.Add(100, new string[] { "4�ð� �Ѿ��µ�", "�� �ڰ��ִ� �� �λ��� ������", "�� ��ħ �Ծ�ߵǴµ�", "�̷��� �ʰ��ڸ� ����ɸԾ� ������" });

        //������ �ڱ��߼� ���̾�α� ������
        ReadingBooks.Add(new Dialogue("name", new string[] { "�ڱ��߼� ....", "������ ���� ���� �ʶ���������", "�о������ ���� ���� �� �����ž�." }));
            
            /*(111, new string[] { "��ȸ�ΰ��� �Ϻ����Ƕ�" , "�߿��� Ÿ�ε��� �ڽſ��� ������������ ���� ������ �䱸�ϰ� ������",
            "�̸� �����ؾ߸� ������ ���� �� �ִٰ� �ϴ� �����̴�.", "...�̷��� ��ȸ�ΰ��� �Ϻ����Ǵ� �������� �ҼӰ����� ���ɸ��� ���롯�� ����",
            "�ڻ��浿�� �ҷ�����Ű�� �ȴ�."});*/
    }


    
}
