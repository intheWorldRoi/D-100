using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static bool IsInAction;
    public static bool StopNextPlay; // �������� �ִ� �׼ǿ��� �ؽ�Ʈ �ڽ��� ������ �Ѿ�� �ʱ� ����


    public GameObject txtName;
    public GameObject txtSentence;
    public TypeEffect effectTxt;
    public GameObject TextBox;
    public GameObject TextBox2;
    public GameObject goActions;

    

    Queue<string> sentences = new Queue<string>(); //���������� dialogue Ŭ�������� ������ �޾� ��������ϹǷ� queue ���

    
    public void Begin(Dialogue info)
    {
        sentences.Clear();
        

        txtName.GetComponent<TextMeshProUGUI>().text = info.name;

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log(sentence);
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
            Debug.Log(sentences);

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
        else if(sentences.Count == 0 && !IsInAction)
        {
            End();
            return;
        }


        //txtSentence.GetComponent<TextMeshProUGUI>().text = sentences.Dequeue();
        effectTxt.SetMsg(sentences.Dequeue());
        
    }

    public void Next(GameObject o)
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
