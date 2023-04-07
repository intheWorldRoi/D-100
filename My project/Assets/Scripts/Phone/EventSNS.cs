using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UI = UnityEngine.UI;

public class EventSNS : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;

    public GameObject Phone;
    public GameObject playActions; //액션 중에 활성화되는 오브젝트. IsInAction은 다이얼로그 체크만 되어서 이것의 활성화 여부로 단순 스마트폰 사용과 강제 SNS 구분

    public void OnEnable()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();

        if (Phone.activeSelf)
        {
            if (playActions.transform.GetChild(6).gameObject.activeSelf)
            {
                Phone.transform.GetChild(2).gameObject.SetActive(true); // 크리스마스 에피일 때 크리스마스용 폰 스크린 띄움
            }
        }
    }
    public void StartPhone()
    {
        Phone.SetActive(true);
        GetComponent<UI.Image>().color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<BuffAnim>().enabled = false;
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
            Phone.SetActive(false);
        }
        else
            Phone.SetActive(false);
    }
}
