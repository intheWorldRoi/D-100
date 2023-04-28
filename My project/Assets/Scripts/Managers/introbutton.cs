using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introbutton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        SoundManager.instance.PlayBGM("main");
    }
    public void Update()
    {
        if(Input.GetMouseButtonUp(0))
            SoundManager.instance.PlaySound("instaHeart");
    }
}
