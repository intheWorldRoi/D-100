using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goActions : MonoBehaviour
{
    public GameObject desk;
    public void HideDesk()
    {
        desk.SetActive(false); //화면 전체 지우고 이미지 변경 
    }
}
