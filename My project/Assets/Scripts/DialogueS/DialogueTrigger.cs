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
        //SoundManager.instance.PlayBGM("main"); // 아니 브금을 왜 여기서 트는거야
        Scene scene = SceneManager.GetActiveScene();
        if( scene.name == "Ending_GameOver")
        {
            Debug.Log("게임오버");
            GameOver();
        }
        else if(scene.name == "Ending_Loser")
        {
            Debug.Log("거지엔딩");
            GameOver_nomoney();
        }
        
    }
    public void Trigger()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        SoundManager.instance.PlaySound("click");
        system.Begin(info);
    }

    public void GameOver()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info);
    }

    public void GameOver_nomoney()
    {
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        system.Begin(info);
    }
}
