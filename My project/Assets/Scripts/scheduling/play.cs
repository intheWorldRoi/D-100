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


    public GameObject phonebody;

    public GameObject dataManager;
    DialogueData data;
    public GameObject DialogSystem;

    public static bool sns;
    bool pnp;

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
                int num = UnityEngine.Random.Range(0, 2);
                ActionManager.Toeic(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playToeic[num]);
                
                break;
            case 1:
                ActionManager.Fitness(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playFitness[Convert.ToInt16(pnp)]);
                break;
            case 2:
                //ActionManager.Reading();
                
                DialogueSystem.IsInAction = false; //안 넘어가게 하기, 이벤트 처리 후 true로 바꾸고 NextSchedule()을 부른다.
                ReadingUI.SetActive(true);
                system.GetComponent<DialogueSystem>().Begin(data.playReadingBook[0]);
                break;
            case 3:
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
                ActionManager.Partjob(pnp);
                system.GetComponent<DialogueSystem>().Begin(data.playAlba[Convert.ToInt16(pnp)]);
                break;
        }
        
    }

    void Update()
    {

        

        if (sns)
        {
            if ((transform.GetSiblingIndex() != 3) || (transform.GetSiblingIndex() != 4)) // index값을 업데이트에서 매번 호출하면 과부하가 걸릴까봐 이렇게 함 ㅠㅠ
            {
                DialogueSystem system = DialogSystem.GetComponent<DialogueSystem>();
                int randomNum = UnityEngine.Random.Range(0, 3);
                DialogueSystem.IsInAction = false;
                system.GetComponent<DialogueSystem>().Begin(data.SNS[randomNum]);
                phonebody.SetActive(true);
                
            }
            sns = false;
            DialogueSystem.IsSNSAction = false;
            
        }
    }

}

