using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject Diary;
    public GameObject Desk;
    public GameObject goActions;
    public void HideAndReveal()
    {
        Diary.SetActive(false);
        Desk.SetActive(false);
        goActions.SetActive(true);
    }
}
