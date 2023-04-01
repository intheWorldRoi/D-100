using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using Unity.VisualScripting;

public class DialogueSystem : MonoBehaviour
{
    public static bool IsInAction = false;
    public static bool NewLoop = true;

    public GameObject txtName;
    public GameObject txtSentence;
    public TypeEffect effectTxt;
    public GameObject TextBox;
    public GameObject TextBox2;
    public GameObject goActions;
    public GameObject diary;

    
    Queue<string> sentences = new Queue<string>(); //순차적으로 dialogue 클래스에서 문장을 받아 보여줘야하므로 queue 사용


    /*public void StartDialogue(List<Dialogue> paragragh)
    {
        foreach(var dia in paragragh)
        {
            Begin(dia);

        }
    }*/
    public void Begin(Dialogue info)
    {
        sentences.Clear();
        TextBox.SetActive(true);
        txtName.GetComponent<TextMeshProUGUI>().text = info.name;

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            if (IsInAction)
            {
                NextSchedule();
                return;
            }

            else
            {
                End();
                return;
            }
        }
        else
        {
            //txtSentence.GetComponent<TextMeshProUGUI>().text = sentences.Dequeue();
            effectTxt.SetMsg(sentences.Dequeue());
        }
        
    }
    private void End()
    {
        if (NewLoop)
        {
            diary.SetActive(true);
        }
        TextBox.SetActive(false);
    }

    
    private void NextSchedule()
    {
            
        TextBox.SetActive(false);
        goActions.GetComponent<goActions>().nextPlay();


    }
}


/*public void Begin(Dialogue info, GameObject o)
   {

       IsInAction = false;
       sentences.Clear();

       txtName.GetComponent<TextMeshProUGUI>().text = info.name;

       foreach (var sentence in info.sentences)
       {
           sentences.Enqueue(sentence);

       }

       Next(o);
   }*/
/*public void Next(GameObject o)
   {

       if ((sentences.Count == 0))
       {
           End(o);

           return;
       }
       else if ((sentences.Count == 0) && (!IsInAction))
       {

           EndSchedule();
           return;
       }


       effectTxt.SetMsg(sentences.Dequeue());
   }*/
/* private void End(GameObject o)
     {
         TextBox.SetActive(false);
         if (IsInAction == false) {
             o.transform.GetChild(0).gameObject.SetActive(true);
         }

     }*/