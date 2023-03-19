using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{


    public GameObject txtName;
    public GameObject txtSentence;

    public TypeEffect effectTxt;

    public GameObject TextBox;
    

    Queue<string> sentences = new Queue<string>(); //���������� dialogue Ŭ�������� ������ �޾� ��������ϹǷ� queue ���

    
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

    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }

        //txtSentence.GetComponent<TextMeshProUGUI>().text = sentences.Dequeue();
        effectTxt.SetMsg(sentences.Dequeue());  
    }

    private void End()
    {
        TextBox.SetActive(false);
    }
}
