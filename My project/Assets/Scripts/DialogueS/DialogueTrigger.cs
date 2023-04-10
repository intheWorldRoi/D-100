using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public GameObject textBox;
    public GameObject DialogueSystem;


    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if( scene.name == "Ending_GameOver")
        {
            GameOver();
        }
        
    }
    public void Trigger()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info);
    }

   public void GameOver()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info);
    }
}
