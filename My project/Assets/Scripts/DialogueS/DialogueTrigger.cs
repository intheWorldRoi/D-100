using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> info;

    public GameObject textBox;
    public GameObject DialogueSystem;


    private void Start()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        
        Scene scene = SceneManager.GetActiveScene();
        if( scene.name == "Ending_GameOver")
        { 
            if (GameManager.money <= 0)
                system.StartDialogue(0, 1, info);
            else
                system.Begin(info[1]);
        }
    }
    public void Trigger()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        SoundManager.instance.PlaySound("click");
        system.Begin(info[0]);
    }
    public void introDia()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info[0]);
    }
    public void letsStart() {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info[1]);
    }

}
