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
    public static bool IsSNSAction = false;
    public static bool NewLoop = true;
    public static bool SwitchGoOut = false;
    public static bool InPara = false;

    public GameObject txtName;
    public GameObject txtSentence;
    public TypeEffect effectTxt;
    public GameObject TextBox;
    public GameObject TextBox2;
    public GameObject goActions;
    public GameObject diary;

    List<Dialogue> paragragh = new List<Dialogue>();
    int start;
    int end;


    Queue<string> sentences = new Queue<string>(); //순차적으로 dialogue 클래스에서 문장을 받아 보여줘야하므로 queue 사용


    public void StartDialogue(int firstindex, int lastindex, List<Dialogue> para)
    {
        InPara = true;
        start = firstindex;
        end = lastindex;
        Debug.Log(start);
        paragragh=para;
        Begin(paragragh[start++]);
    }
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
        Debug.Log("Next 호출 , IsSNSAction : " + IsSNSAction);
        if (sentences.Count == 0)
        {
            if (IsSNSAction)
            {
                play.sns = ActionManager.SNS();
                IsSNSAction = false;
                return;
            }
            else if (IsInAction)
            {
                NextSchedule();
                return;
            }
            else if (InPara)
            {
                if (start == end)
                {
                    Begin(paragragh[start]);
                    InPara = false;
                }
                Begin(paragragh[start++]);
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
        
        if (goActions.transform.GetChild(6))
        {
            goActions.transform.GetChild(6).GetComponent<goStory>().DivEpisode();
        }
    }

    
    private void NextSchedule()
    {
        SwitchGoOut = true;   
        TextBox.SetActive(false);
        goActions.GetComponent<goActions>().nextPlay();


    }
}