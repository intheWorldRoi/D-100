using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class episodeChristmas : MonoBehaviour
{
    private void OnMouseDown()      //���α��� �ʿ�.
    {
        Debug.Log("ũ�������� ����");
        gameObject.SetActive(false);
        transform.parent.gameObject.transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //������ �۵� ��Ű�� �Լ��� �ҷ��´�
    }
}
