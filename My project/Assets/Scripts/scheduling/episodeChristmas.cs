using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class episodeChristmas : MonoBehaviour
{
    private void OnMouseDown()      //세부구현 필요.
    {
        Debug.Log("크리스마스 실행");
        gameObject.SetActive(false);
        transform.parent.gameObject.transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //연쇄적 작동 시키는 함수를 불러온다
    }
}
