using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class play : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ReadingUI; // 독서 선택지 ui
    public GameObject GoOutUI;   // 외출 선택지 ui
    public GameObject RestUI;


    public GameObject phonebody;

    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;

    public static bool sns;
    bool pnp;

    int randomNum;
    private void OnEnable()
    {
        DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();

        data = dataManager.GetComponent<DialogueData>();


        int index = transform.GetSiblingIndex();

        if (index == 0 || index == 1 || index == 2 || index == 5) //패논패가 등장하는 액션인지 판단한다
        {
            pnp = ActionManager.PNP();
            DialogueSystem.IsSNSAction = true;
        } 
        
        

        switch (transform.GetSiblingIndex())
        {
            case 0:
                int num = UnityEngine.Random.Range(0, data.playToeic.Count);
                ActionManager.Toeic(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playToeic[num]);   // 여기서 이제 플레이토익 인덱스 나눠서 상태에 따라 출력해야됨
                
                break;
            case 1:
                num = UnityEngine.Random.Range(0, data.playFitness.Count); 
                ActionManager.Fitness(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playFitness[num]);
                break;
            case 2:
                //ActionManager.Reading();
                
                DialogueSystem.IsInAction = false; //안 넘어가게 하기, 이벤트 처리 후 true로 바꾸고 NextSchedule()을 부른다.
                ReadingUI.SetActive(true);
                system.GetComponent<DialogueSystem>().Begin(data.playReadingBook[0]);
                break;
            case 3:
                DialogueSystem.IsInAction = false;
                RestUI.SetActive(true);
                ActionManager.Rest();
                system.GetComponent<DialogueSystem>().Begin(data.playRest[0]);
                break;
            case 4:
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                GoOutUI.gameObject.transform.parent.parent.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
                ActionManager.GoOut();
                DialogueSystem.IsInAction = false;  //안 넘어가게 하기, 이벤트 처리 후 true로 바꾸고 NextSchedule()을 부른다.
                GoOutUI.SetActive(true);
                system.GetComponent<DialogueSystem>().Begin(data.playGoOut[0]); 
                break;
            case 5:
                num = UnityEngine.Random.Range(0, data.playAlba.Count);
                ActionManager.Partjob(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playAlba[num]);
                break;
        }
        
    }

    void Update()
    {

        

        if (sns)
        {
            DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
            
            if ((transform.GetSiblingIndex() ==  0)) // 토익 강제 sns 이벤트 일 때
            {
                
                randomNum = UnityEngine.Random.Range(0, 3); //SNS 진입 다이얼로그가 인덱스별로 다 토익 운동 알바 등에 맞춰서 한거라 얘는 정해주기
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[randomNum]);
                phonebody.SetActive(true);
                phonebody.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                
            }
            else if((transform.GetSiblingIndex() == 1)) //
            {
                randomNum = UnityEngine.Random.Range(4, 6);
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[randomNum]);
                phonebody.SetActive(true);
                phonebody.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            sns = false;
            DialogueSystem.IsSNSAction = false;
            
        }
    }

}

