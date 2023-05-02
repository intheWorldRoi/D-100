using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem system;
    public static bool IsInAction = false;
    public static bool IsSNSAction = false;
    public static bool NewLoop = true;
    public static bool SwitchGoOut = false;
    public static bool InPara = false;
    public static bool InMad = false;

    public static bool IsMainScene;

    public GameObject txtName;
    public GameObject txtSentence;
    public TypeEffect effectTxt;
    public GameObject TextBox;
    public GameObject TextBox2;
    public GameObject goActions;
    public GameObject diary;

    public GameObject ninebackground;


    List<Dialogue> paragragh = new List<Dialogue>();
    int start, end;


    Queue<string> sentences = new Queue<string>(); //순차적으로 dialogue 클래스에서 문장을 받아 보여줘야하므로 queue 사용

    bool nine;

    bool EndingSwitch;
    bool dummysUpSwitch;
    
    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            IsMainScene = true;
        }
        else if (SceneManager.sceneCount == 1 || SceneManager.sceneCount == 3)
        {
            IsMainScene = false;
        }

        nine = true;
        EndingSwitch = false;
    }
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
        
        //Debug.Log("Next 호출 , IsSNSAction : " + IsSNSAction);
        if (sentences.Count == 0)
        {

            if (InPara)
            {
                if (start == end)
                {
                    Begin(paragragh[start]);
                    InPara = false;
                    return;
                }
                Begin(paragragh[start++]);
                return;
            }

            if (IsMainScene && IsSNSAction && !InMad)
            {
                play.sns = ActionManager.SNS();
                IsSNSAction = false;
                if (play.sns) {
                    goActions.transform.GetChild(0).gameObject.GetComponent<playSNS>().enabled = true;
                    goActions.transform.GetChild(1).gameObject.GetComponent<playSNS>().enabled = true;
                }
                

                return;
            }
            
            
            else if (IsMainScene && IsInAction)
            {
                NextSchedule();
                return;
            }
            else if (IsMainScene && InMad)
            {
                play.mad = false;
                NextSchedule();
                return;
            }
            if (SceneManager.GetActiveScene().name == "Main" && GameManager.Day == 99 && nine)
            {
                Debug.Log("nine false 작동");
                Begin(DialogueData.data.ninetynine[1]);
                ninebackground.SetActive(true);
                nine = false;
            }
            
            if (SceneManager.GetActiveScene().name == "Ending_Nomal" && dummysUpSwitch)
            {
                Ending e = transform.GetChild(1).GetComponent<Ending>();
                Debug.Log("dummysUp 작동");
                e.badEndingAnimation();
                dummysUpSwitch = false;
                TextBox.SetActive(false);
            }

            else
            {
                End();
                return;
            }
        }
        else
        {
            
            if (sentences.Peek().Contains("아.... 정말 스트레스가..  주체가 안 돼.")) // 폭주 지점 확인
            {     
                play.mad = true;
                InMad = true;
            }
            else if(StatusManager.Stress == 100)
            {
                play.mad = true;
                InMad = true;
            }
            else if(sentences.Peek().Contains("힘들다고 여기서 멈추면 정말 돌이킬 수 없을 것 같으니까..."))
            {
                dummysUpSwitch = true;
            }
            else if (sentences.Peek().Contains("당신의 마음은 안녕하십니까?"))
            {
                EndingSwitch = true;
            }
            SoundManager s = SoundManager.instance; 
            
            s.PlaySound("tadadada");
            effectTxt.SetMsg(sentences.Dequeue());
            
            
        }
        
    }
    private void End()
    {
        if (!nine && GameManager.Day == 99 && EndingSwitch)
        {
            Debug.Log("dayplus작동");
            dayplus();
            GameManager.Ending();
            nine = true;
        }
        else if (IsMainScene && NewLoop && GameManager.Day != 99)
        {
            diary.SetActive(true);
            diary.GetComponentInParent<Button>().enabled = false;
        }
        TextBox.SetActive(false);
        
        if (IsMainScene && goActions.transform.GetChild(6))
        {
            goActions.transform.GetChild(6).GetComponent<goStory>().DivEpisode();
        }

        if (SceneManager.GetActiveScene().name != "Intro"&& SceneManager.GetActiveScene().name != "Main")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        
    }

    
    private void NextSchedule()
    {
        SwitchGoOut = true;   
        TextBox.SetActive(false);
        goActions.GetComponent<goActions>().nextPlay();


    }
    
    private void Awake()
    {
        IsInAction = false;
        IsSNSAction = false;
        NewLoop = true;
        SwitchGoOut = false;
        InPara = false;
        InMad = false;
        system = this;
    }

    void dayplus()
    {
        GameManager.Day++;
    }
}