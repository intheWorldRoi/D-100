using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using UnityEngine;

public class goStory : MonoBehaviour
{
    public GameObject goActions;
    private void OnEnable()      //���α��� �ʿ�.
    {
        DialogueSystem.IsInAction = false;
        Debug.Log("���丮 ����");
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
            if (transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf)  //ũ�������� ���Ժ��� ��
            {
                transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true); //���� ������
            }
            else if (transform.GetChild(0).transform.GetChild(1).gameObject.activeSelf)      
            {
                if (episodeChristmas.choice) {                                                  //ǥ����
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);    
                    transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);     //���� ������
                }
                else                                                                            //�� ����
                {
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
                }
                
            }
            else if (transform.GetChild(0).transform.GetChild(2).gameObject.activeSelf)             //���� �� ��
            {
                transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            }
 
        }
    }
}
   
