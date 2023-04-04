using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSNS : MonoBehaviour
{
    public GameObject dataManager;
    DialogueData data;

    public GameObject Phone;
    public GameObject playActions; //�׼� �߿� Ȱ��ȭ�Ǵ� ������Ʈ. IsInAction�� ���̾�α� üũ�� �Ǿ �̰��� Ȱ��ȭ ���η� �ܼ� ����Ʈ�� ���� ���� SNS ����

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
