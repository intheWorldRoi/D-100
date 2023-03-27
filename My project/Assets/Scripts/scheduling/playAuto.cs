using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playAuto : MonoBehaviour
{
    private void OnMouseDown()      //세부구현 필요.
    {   
        Debug.Log("실행");
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //연쇄적 작동 시키는 함수를 불러온다
    }
}
