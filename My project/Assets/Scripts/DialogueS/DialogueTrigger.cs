using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> info;

    public GameObject textBox;
    public GameObject DialogueSystem;

    public static int endingNum;
    SoundManager s;
    private void Awake()
    {
        s = SoundManager.instance;
    }
    private void Start()
    {
        endingNum = -1;
        var system = DialogueSystem.GetComponent<DialogueSystem>();
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Ending_GameOver")
        {
            if (GameManager.money <= 0)
                system.StartDialogue(0, 1, info);
            else
                system.Begin(info[1]);
        }
       
        if (scene.name == "Ending_Nomal" || scene.name == "Ending_Trip")
        {
            endingNum = infoCal(StatusManager.Engknowledge, StatusManager.healthy, StatusManager.innerpeace);
            if(endingNum == 7)
            {
                SoundManager.instance.PlayBGM("badEnding");
            }
            else
            {
                SoundManager.instance.PlayBGM("show");
            }
            
            system.Begin(info[endingNum]);

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
    public static int infoCal(int Eng, int heal, int inner)
    {
        if (Eng > 100 && heal > 100 && inner > 150)
        {
            return 0;
        }
        else if (Eng > 100 && heal > 100 && inner < 150)
        {
            return 1;
        }
        else if (Eng > 100 && heal < 100 && inner > 150)
        {
            return 2;
        }
        else if (Eng > 100 && heal < 100 && inner < 150)
        {
            return 3;
        }
        else if (Eng < 100 && heal > 100 && inner > 150)
        {
            return 4;
        }
        else if (Eng < 100 && heal > 100 && inner < 150)
        {
            return 5;
        }
        else if (Eng < 100 && heal < 100 && inner > 150)
        {
            return 6;
        }
        else
        {
            return 7;
        }
    }
}
