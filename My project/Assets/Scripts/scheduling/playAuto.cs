using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class playAuto : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject TextBox2;
    /*private void OnEnale()      //세부구현 필요.
    {
        
        system.Begin(ActionDialog.dialogues);
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //연쇄적 작동 시키는 함수를 불러온다
    }*/
    private void OnEnable()
    {
        TextBox2.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        Debug.Log("오토실행");
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

