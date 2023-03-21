using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goActions : MonoBehaviour
{
    public GameObject desk;
    public void HideDesk()
    {
        desk.SetActive(false);
    }
}
