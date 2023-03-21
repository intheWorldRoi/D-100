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
    {   selectedActionItemIndex = -1;       //인덱스를 활용하기 때문에 -1로 초기화
        actionList = new int[transform.GetChild(0).transform.childCount];   //
    
        for (int i = 0; i < actionList.Length; i++) // actionList 초기화
        {
            actionList[i] = -1;
        }
    }
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
