using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Serialization;

using UnityEngine;

public class goStory : MonoBehaviour
{
    public GameObject goActions;
    private void OnEnable()      
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
                if (episodeChristmas.choice)
                {                                                  //ǥ����
                    SoundManager.instance.PlayBGM("show");
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);     //���� ������
                }
                else                                                                            //�� ����
                {
                    transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
                }
                return;

            }
            else if (transform.GetChild(0).transform.GetChild(2).gameObject.activeSelf)             //���� �� ��
            {
                transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
                SoundManager.instance.PlayBGM("main");
                return;
            }

            if (transform.GetChild(0).transform.GetChild(3).gameObject.activeSelf)
            {
                transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(false);
                DialogueSystem.IsInAction = true;
                goActions.GetComponent<goActions>().nextPlay();
                return;
            }

        }
        if (GameManager.week == 9)
        {
            
            if (transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf)
            {
                transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);

                return;
            }
            else if (transform.GetChild(1).transform.GetChild(2).gameObject.activeSelf)
            {
                transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                goActions.GetComponent<goActions>().nextPlay();
            }
            else if (transform.GetChild(1).gameObject.activeSelf)
            {
                transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                return;
            }
            else
                return;
        }
        if (GameManager.week == 11)
        {
            if (transform.GetChild(2).transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (transform.GetChild(2).transform.GetChild(2).gameObject.activeSelf)
            {
                transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (transform.GetChild(2).transform.GetChild(3).gameObject.activeSelf)
            {
                transform.GetChild(2).transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                goActions.GetComponent<goActions>().nextPlay();
            }
            else if (transform.GetChild(2).gameObject.activeSelf)
            {
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
                
            }
            else
            {
                return;
            }
        }
    }
}
   
