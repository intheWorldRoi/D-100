using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItems : MonoBehaviour
{
    GameObject objDiary;
    public void SelectAction()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject; // Dairy에 접근
        objDiary.GetComponent<Diary>().selectedActionItemIndex = transform.GetSiblingIndex();
    }
    //클릭시 액션아이템의 인덱스를 다이어리의 선택된 액션 인덱스 변수에 저장.
}
