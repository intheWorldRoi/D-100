using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int selectedActionItemIndex;
    public int[] actionList;
    public Queue<int> schedule = new Queue<int>();
    void OnEnable()
    {   selectedActionItemIndex = -1;       //�ε����� Ȱ���ϱ� ������ -1�� �ʱ�ȭ
        actionList = new int[transform.GetChild(0).transform.childCount];   //
    
        for (int i = 0; i < actionList.Length; i++) // actionList �ʱ�ȭ
        {
            actionList[i] = -1;
        }
    }
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
