using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introbutton : MonoBehaviour
{
    public GameObject introVideo;
    public void StartGame()
    {
        introVideo.SetActive(true);
    }
    public void Update()
    {
        if(Input.GetMouseButtonUp(0))
            SoundManager.instance.PlaySound("instaHeart");
    }
}
