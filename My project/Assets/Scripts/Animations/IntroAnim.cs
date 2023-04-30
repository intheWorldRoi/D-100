using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.XR;

//intro ¾À video¿¡ ºÙ¾îÀÖ´Â ½ºÅ©¸³Æ®ÀÔ´Ï´Ù.
public class IntroAnim : MonoBehaviour
{
    float upsideY;
    float underY;
    float upDeltaY;
    float underDeltaY;

    public GameObject dialougeData;
    public GameObject eyes;

    public VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player.Play();
        Invoke("stopVideo", 13.1f);
        
    }

    // Update is called once per frame
   
    void stopVideo()
    {
        player.Pause();
        StartCoroutine(Under(underY, underDeltaY));
        StartCoroutine(Up(upsideY, upDeltaY));
        Invoke("playVideo", 4f);
    }

    void playVideo()
    {
        player.Play();
        Invoke("ClickDiary", 2f);
    }
    void ClickDiary()
    {
        player.Pause();
        dialougeData.GetComponent<DialogueTrigger>().introDia();
        Invoke("ClickEvent", 5f);
    }
    void ClickEvent()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).transform.GetChild(0).GetComponent<BuffAnim>().enabled = true;
    }
    public void StartPlay()
    {
        player.Play();
    }
    public void goMain()
    {
        SoundManager.instance.PlayBGM("main");
        SceneManager.LoadScene("Main");
    }


    //´«±ôºýÀÓÈ¿°ú ÄÚ·çµòÀÛ¼º
    IEnumerator Up(float posY, float deltaY)
    {
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY - deltaY);
            deltaY += 1.0f;
        }
        posY = posY - deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY+ deltaY);
            deltaY += 1.0f;
        }
        posY = posY + deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY - deltaY);
            deltaY += 1.0f;
        }
        posY = posY - deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY + deltaY);
            deltaY += 1.0f;
        }

    }
    IEnumerator Under(float posY, float deltaY)
    {
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY + deltaY);
            deltaY += 1.0f;
        }
        posY = posY + deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY - deltaY);
            deltaY += 1.0f;
        }
        posY = posY - deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY + deltaY);
            deltaY += 1.0f;
        }
        posY = posY + deltaY;
        deltaY = 0;
        while (deltaY <= 115)
        {
            yield return new WaitForSeconds(0.01f);
            eyes.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY - deltaY);
            deltaY += 1.0f;
        }
    }
    private void Awake()
    {
        upsideY = 200f;
        underY = -120f;
        upDeltaY = 0f;
        underDeltaY = 0f;
        player.Prepare();
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(2).transform.GetChild(0).GetComponent<BuffAnim>().enabled = false;
    }

}
