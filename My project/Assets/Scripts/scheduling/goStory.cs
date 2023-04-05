using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using UnityEngine;

public class goStory : MonoBehaviour
{
    public GameObject goActions;
    private void OnEnable()      //세부구현 필요.
    {
        DialogueSystem.IsInAction = false;
        Debug.Log("스토리 실행");
        switch (GameManager.week)
        {
            case 5:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 9:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 11:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }

    public void DivEpisode()
    {
        if (GameManager.week == 5)
        {
            if (transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf)  //크리스마스 도입부일 때
            {
                transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true); //연극 선택지
            }
            else if (transform.GetChild(0).transform.GetChild(1).gameObject.activeSelf)      
            {
                if (episodeChristmas.choice) {                                                  //표구매
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);    
                    transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);     //연극 보러감
                }
                else                                                                            //안 구매
                {
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
                }
                
            }
            else if (transform.GetChild(0).transform.GetChild(2).gameObject.activeSelf)             //연극 본 후
            {
                transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            }
 
        }
    }
}
   
