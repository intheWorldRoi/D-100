using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class play : MonoBehaviour
{
    public GameObject TextBox;
    /*private void OnEnale()      //���α��� �ʿ�.
    {
        
        system.Begin(ActionDialog.dialogues);
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //������ �۵� ��Ű�� �Լ��� �ҷ��´�
    }*/
    private void OnEnable()
    {
        //TextBox.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        if(gameObject.transform.name == "playReadingBook")
        {
            system.Begin(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
            
        }
        else
        {
            system.Begin(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
        }
        
    }

}

