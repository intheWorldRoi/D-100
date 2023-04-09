using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.VirtualTexturing;

public class play : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ReadingUI; // ���� ������ ui
    public GameObject GoOutUI;   // ���� ������ ui
    public GameObject RestUI;


    public GameObject phonebody;

    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;

    public static bool sns;
    bool pnp;

    public static bool mad;

    int randomNum;

    int num;
    bool ReadyToUp = true;

  
    private void OnEnable()
    {
        Debug.Log("���� �׼� �ε��� : " + ActionManager.NowActionIndex);
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();

        data = dataManager.GetComponent<DialogueData>();


        int index = transform.GetSiblingIndex();

        if (index == 0 || index == 1) //�г��а� �����ϴ� �׼����� �Ǵ��Ѵ�
        {
            pnp = ActionManager.PNP();
            DialogueSystem.IsSNSAction = true;
        } 
        
        

        switch (transform.GetSiblingIndex())
        {
            case 0:
                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    num = UnityEngine.Random.Range(0, data.playToeic.Count);
                    ActionManager.Toeic(pnp);
                    system.GetComponent<DialogueSystem>().Begin(data.playToeic[num]);   // ���⼭ ���� �÷������� �ε��� ������ ���¿� ���� ����ؾߵ�
                }
                
                
                break;
            case 1:
                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    num = UnityEngine.Random.Range(0, data.playFitness.Count);
                    ActionManager.Fitness(pnp);
                    system.GetComponent<DialogueSystem>().Begin(data.playFitness[num]);
                }
               
                break;
            case 2:
                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    DialogueSystem.IsInAction = false; //�� �Ѿ�� �ϱ�, �̺�Ʈ ó�� �� true�� �ٲٰ� NextSchedule()�� �θ���.
                    ReadingUI.SetActive(true);
                    system.GetComponent<DialogueSystem>().Begin(data.playReadingBook[0]);
                }
                
                break;
            case 3:

                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    DialogueSystem.IsInAction = false;
                    RestUI.SetActive(true);
                    system.GetComponent<DialogueSystem>().Begin(data.playRest[0]);
                }
                
                break;
            case 4:
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    DialogueSystem.IsInAction = false;  //�� �Ѿ�� �ϱ�, �̺�Ʈ ó�� �� true�� �ٲٰ� NextSchedule()�� �θ���.
                    GoOutUI.SetActive(true);
                    system.GetComponent<DialogueSystem>().Begin(data.playGoOut[0]);
                }
                
                break;
            case 5:
                if (DialogueSystem.InMad)
                {
                    system.GetComponent<DialogueSystem>().Begin(data.Mad[1]);
                }
                else
                {
                    num = UnityEngine.Random.Range(0, data.playAlba.Count);
                    mad = false;
                    Image red = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
                    red.color = new Color(255, 0, 0, 0);
               
                    if (num == 6) // 
                    {
                        int actionIndex = goActions.actionIndex;
                        int dayIndex = goActions.dayIndex;
                        if (goActions.dayIndex != 6)
                        {
                            Debug.Log("if�������");
                            for (int i = 0; i < 3; i++)
                            {
                                Diary.actionList[dayIndex + 1][i] = 7;

                            }

                        }

                    }
                    ActionManager.Partjob(pnp);
                    system.GetComponent<DialogueSystem>().Begin(data.playAlba[num]);
                }
                
                break;
            case 7:
                if (DialogueSystem.InMad)
                {
                    DialogueSystem.InMad = false;
                }
                
                StatusManager.Stress -= 50;
                system.GetComponent<DialogueSystem>().Begin(data.Mad[0]);
                break;
        }
        
    }

    void Update()
    {

        if (mad)
        {
            Image redSprite;
            if(gameObject.name == "playAlba")
            {
                redSprite = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>(); // �ڽ��� �ڽ��� image ������Ʈ ��
                Debug.Log("���İ� : " + redSprite.color.a);
                if (redSprite.color.a <= 0)
                {
                    StartCoroutine(FadeCoroutine(redSprite));
                }
                else if (redSprite.color.a >= 0.3f)
                {
                    StartCoroutine(FadeOutCoroutine(redSprite));
                }

                if (StatusManager.Stress < 100)
                {
                    if (ReadyToUp)
                    {
                        ReadyToUp = false;
                        Invoke("StressOverwhelming", 0.5f);
                    }
                    
                }
            }
        }
        
    }

    IEnumerator FadeCoroutine(Image i) //���� �ִϸ��̼�
    {
        float fadeCount = 0;
        while (fadeCount < 0.3f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.03f);
            i.color = new Color(255, 0, 0, fadeCount);
        }
        
        
    }

    IEnumerator FadeOutCoroutine(Image i)
    {
        float fadeCount = 0.3f;
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.03f);
            i.color = new Color(255, 0, 0, fadeCount);
        }
        
    }

    void StressOverwhelming()
    {
        
        StatusManager.Stress++;

        ReadyToUp = true;
    }
}

