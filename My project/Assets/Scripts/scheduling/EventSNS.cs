using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSNS : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;

    public GameObject Phone;
    public GameObject playActions; //액션 중에 활성화되는 오브젝트. IsInAction은 다이얼로그 체크만 되어서 이것의 활성화 여부로 단순 스마트폰 사용과 강제 SNS 구분

    public void StartPhone()
    {
        Phone.SetActive(true);
    }
    public void touchScreen()
    {

    }
    public void StopPhone()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();

        if (playActions.activeSelf)
        {
            DialogueSystem.IsInAction = true;
            system.GetComponent<DialogueSystem>().Begin(data.SNS[1]);
            Phone.SetActive(false);
        }
        else
            Phone.SetActive(false);
    }
}
