using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playAuto : MonoBehaviour
{
    private void OnMouseDown()      //���α��� �ʿ�.
    {   
        Debug.Log("����");
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //������ �۵� ��Ű�� �Լ��� �ҷ��´�
    }
}
