using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.VirtualTexturing;

public class playSNS : MonoBehaviour
{
    public GameObject DialogSystem;
    public GameObject dataManager;
    DialogueData data;
    public GameObject phonebody;
    int randomNum;

    int num;
    public void OnEnable()
    {
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
        data = dataManager.GetComponent<DialogueData>();

        if (play.sns)
        {

            if ((transform.GetSiblingIndex() == 0)) // ���� ���� sns �̺�Ʈ �� ��
            {
                randomNum = UnityEngine.Random.Range(0, 3); //SNS ���� ���̾�αװ� �ε������� �� ���� � �˹� � ���缭 �ѰŶ� ��� �����ֱ�
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[randomNum]);
                phonebody.transform.parent.GetComponent<BuffAnim>().enabled = true;          //transform.parent.gameObject.GetComponent<BuffAnim>().enabled;
            }
            else if ((transform.GetSiblingIndex() == 1)) //
            {
                randomNum = UnityEngine.Random.Range(4, 6);
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[randomNum]);
                phonebody.transform.parent.GetComponent<BuffAnim>().enabled = true;
            }
            DialogueSystem.IsSNSAction = false;
            
        }
        this.transform.GetComponent<playSNS>().enabled = false;
    }
}
