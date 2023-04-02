using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class play : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ReadingUI;
    public GameObject GoOutUI;
    /*private void OnEnale()      //세부구현 필요.
    {
        
        system.Begin(ActionDialog.dialogues);
        transform.parent.gameObject.GetComponent<goActions>().nextPlay();       //연쇄적 작동 시키는 함수를 불러온다
    }*/
    private void OnEnable()
    {
        //TextBox.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        if(gameObject.transform.name == "playReadingBook")
        {
            ReadingUI.SetActive(true);
            system.Begin(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
            
        }
        else if(gameObject.transform.name == "playGoOut")
        {
            
            GoOutUI.SetActive(true);
            system.Begin(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);

        }
        else
        {
            system.Begin(transform.parent.gameObject.GetComponent<ActionDialog>().ActionDialogues);
        }
        
    }

}

