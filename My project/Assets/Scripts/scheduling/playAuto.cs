using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class playAuto : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject TextBox2;
    /*private void OnEnale()      //���α��� �ʿ�.
    {
        
        system.Begin(ActionDialog.dialogues);
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //������ �۵� ��Ű�� �Լ��� �ҷ��´�
    }*/
    private void OnEnable()
    {
        TextBox2.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        Debug.Log("�������");
        if(gameObject.transform.name == "playReadingBook")
        {
            system.BeginSchedule(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
            
        }
        else
        {
            system.BeginSchedule(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
        }
        
    }

}

