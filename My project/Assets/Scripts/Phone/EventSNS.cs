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
    public GameObject playActions; //�׼� �߿� Ȱ��ȭ�Ǵ� ������Ʈ. IsInAction�� ���̾�α� üũ�� �Ǿ �̰��� Ȱ��ȭ ���η� �ܼ� ����Ʈ�� ���� ���� SNS ����

    public void OnEnable()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();

        if (Phone.activeSelf)
        {
            if (playActions.transform.GetChild(6).gameObject.activeSelf)
            {
                Phone.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(true); // ũ�������� ������ �� ũ���������� �� ��ũ�� ���
            }
            else if (play.sns == true){
                if (playActions.transform.GetChild(0).gameObject.activeSelf)
                {
                    Phone.transform.GetChild(0).transform.GetChild(0).gameObject.gameObject.SetActive(true);
                }
                if (playActions.transform.GetChild(1).gameObject.activeSelf)
                {
                    Phone.transform.GetChild(1).transform.GetChild(0).gameObject.gameObject.SetActive(true);
                }
                play.sns = false;
            }
        }
    }
    public void StartPhone()
    {
        if (play.sns || playActions.transform.GetChild(6).gameObject.activeSelf) {
            Phone.SetActive(true);
            GetComponent<UI.Image>().color = new Color(1, 1, 1, 1);
            gameObject.GetComponent<BuffAnim>().enabled = false;
        }
        
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
