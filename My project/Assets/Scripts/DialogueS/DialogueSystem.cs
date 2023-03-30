using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static bool IsInAction;

    public GameObject txtName;
    public GameObject txtSentence;
    public TypeEffect effectTxt;
    public GameObject TextBox;
    public GameObject goActions;

    

    Queue<string> sentences = new Queue<string>(); //순차적으로 dialogue 클래스에서 문장을 받아 보여줘야하므로 queue 사용

    
    public void Begin(Dialogue info)
    {
        sentences.Clear();

        txtName.GetComponent<TextMeshProUGUI>().text = info.name;

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
            
        }
        
        Next();
    }

    public void Begin(Dialogue info, GameObject o)
    {
        
        IsInAction = false;
        sentences.Clear();

        txtName.GetComponent<TextMeshProUGUI>().text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);

        }

        Next(o);
    }

    public void BeginSchedule(Dialogue info)
    {
        sentences.Clear();
        Debug.Log(IsInAction);
        txtName.GetComponent<TextMeshProUGUI>().text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);

        }

        Next();
    }
    public void Next()
    {
        if((sentences.Count == 0)&&(IsInAction))
        {
            EndSchedule();
            return;
        }
        if(sentences.Count == 0)
        {
            End();
            return;
        }


        //txtSentence.GetComponent<TextMeshProUGUI>().text = sentences.Dequeue();
        effectTxt.SetMsg(sentences.Dequeue());  
    }

    public void Next(GameObject o)
    {
        
        if (sentences.Count == 0)
        {
            End(o);
            
            return;
        }

        //txtSentence.GetComponent<TextMeshProUGUI>().text = sentences.Dequeue();
        effectTxt.SetMsg(sentences.Dequeue());
    }
    private void End()
    {
        
        TextBox.SetActive(false);

        


    }

    private void End(GameObject o)
    {
        TextBox.SetActive(false);
        if (IsInAction == false) {
            o.transform.GetChild(0).gameObject.SetActive(true);
        }
               
    }
    private void EndSchedule()
    {

        TextBox.SetActive(false);
        goActions.GetComponent<goActions>().nextPlay();


    }
}
