using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItems : MonoBehaviour
{
    public GameObject objDiary; //inspector ���� Dairy�� ����
    public void SelectAction()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject; //openDiary. Dairy�� ���� �����ϱ� ����
        objDiary.GetComponent<Diary>().selectedActionItemIndex = transform.GetSiblingIndex();
    }
    //Ŭ���� �׼Ǿ������� �ε����� ���̾�� ���õ� �׼� �ε��� ������ ����.
}
