using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDiary : MonoBehaviour
{
    public GameObject Diary;
    public void Hide()
    {
        Diary.SetActive(false);
    }
}
