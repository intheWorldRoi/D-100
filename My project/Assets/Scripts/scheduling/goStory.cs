using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class goStory : MonoBehaviour
{
    private void OnEnable()      //세부구현 필요.
    {
        Debug.Log("스토리 실행");
        switch (GameManager.week)
        {
            case 5:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 9:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 11:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}
   
