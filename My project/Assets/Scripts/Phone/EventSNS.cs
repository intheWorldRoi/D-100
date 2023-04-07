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
                Phone.transform.GetChild(2).gameObject.SetActive(true); // ũ�������� ������ �� ũ���������� �� ��ũ�� ���
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
