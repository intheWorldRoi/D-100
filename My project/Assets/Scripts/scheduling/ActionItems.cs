using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItems : MonoBehaviour
{
    GameObject objDiary;
    public void SelectAction()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject; // Dairy�� ����
        objDiary.GetComponent<Diary>().selectedActionItemIndex = transform.GetSiblingIndex();
    }
    //Ŭ���� �׼Ǿ������� �ε����� ���̾�� ���õ� �׼� �ε��� ������ ����.
}
