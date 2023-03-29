using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public GameObject textBox;
    
    
   public void Trigger()
    {
        textBox.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }

    public void GameObjectTrigger()
    {
        Debug.Log("GameObjectTrigger �۵���");
        textBox.SetActive(true);
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info, this.gameObject);
    }
}
