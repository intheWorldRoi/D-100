using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class books : MonoBehaviour
{
    public int bookIndex =-1;

    public void OnMousedown()
    {
        bookIndex = transform.GetSiblingIndex();

        switch (bookIndex)
        {
            case 0:
                ActionManager.readingBook = "�ڱ��߼�";
                break;
            case 1:
                ActionManager.readingBook = "������";
                break;
            case 2:
                ActionManager.readingBook = "�Ҽ�";
                break;
        }
    }


}
