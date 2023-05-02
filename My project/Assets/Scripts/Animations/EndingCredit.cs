using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndingCredit : MonoBehaviour
{
    float alpha;
    float y;
    float[] alphaT;
    float videoAlpha;
    float videoSpeed;
    public VideoPlayer player;

    public GameObject texts;
    public GameObject EFF;
    // Start is called before the first frame update

    private void Awake()
    {
        videoSpeed = 0;
        videoAlpha = 0.1f;
        alphaT = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        alpha = 0.1f;
        y = -180f;
        transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, y);

    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Ending_GameOver"|| DialogueTrigger.endingNum ==7)
        {
            StartCoroutine(Fadein());
            Invoke("replay", 5f);
        }
        else {
            StartCoroutine(Fadein());
            Invoke("txtEff", 2f);
        }

    }

    // Update is called once per frame
    IEnumerator Fadein()
    {
        while (alpha < 1f)
        {
            yield return new WaitForSeconds(0.1f);
            transform.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            alpha += 0.1f;
        }
    }

    IEnumerator videoFadein(GameObject o)
    {
        while (videoAlpha < 1f)
        {
            yield return new WaitForSeconds(0.05f);
            o.GetComponent<RawImage>().color = new Color(255, 255, 255, videoAlpha);
            videoAlpha += 0.1f;
        }
        while (videoSpeed < 10f)
        {
            yield return new WaitForSeconds(0.05f);
            player.GetComponent<VideoPlayer>().playbackSpeed = videoSpeed;
            videoSpeed += 0.1f;
        }

    }
    IEnumerator videoFadeout(GameObject o)
    {
        while (videoAlpha >= 0.1f)
        {
            yield return new WaitForSeconds(0.2f);
            o.GetComponent<RawImage>().color = new Color(255, 255, 255, videoAlpha);
            videoAlpha -= 0.1f;
        }

    }

    IEnumerator textFadein(GameObject o)
    {
        for (int i = 0; i < alphaT.Length; i++)
        {
            while (alphaT[i] <= 1f)
            {
                yield return new WaitForSeconds(0.1f);
                o.transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, alphaT[i]);
                alphaT[i] += 0.1f;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator textFadeout(GameObject o, int index)
    {
        while (alphaT[index] > 0f)
        {
            yield return new WaitForSeconds(0.1f);
            o.transform.GetChild(index).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, alphaT[index]);
            alphaT[index] -= 0.1f;
        }
        alphaT[index] = 0f;

    }

    void txtEff()
    {
        texts.SetActive(true);
        StartCoroutine(textFadein(texts));
        Invoke("playFog", 12f);
    }

    void playFog()
    {
        IEnumerator coroutine = textFadein(texts);
        StopCoroutine(coroutine);
        StartCoroutine(videoFadein(EFF));
        player.Play();
        EFF.SetActive(true);
        Invoke("removeText", 6f);
    }
    void removeText()
    {
        IEnumerator coroutine = videoFadein(EFF);
        StopCoroutine(coroutine);
        for (int i = 0; i < alphaT.Length; i++)
        {
            StartCoroutine(textFadeout(texts, i));
        }
        StartCoroutine(videoFadeout(EFF));
        Invoke("removeFog", 3f);

    }

    private void removeFog(){

        StartCoroutine(videoFadeout(EFF));
        Invoke("replay", 1f);
    }
    private void replay(){
        if(SceneManager.GetActiveScene().name != "Ending_GameOver")
        {
            EFF.SetActive(false);
            texts.SetActive(false);
        }
        
        StartCoroutine(Up());
    }
    IEnumerator Up()
    {
        while (y <= 180)//y <= transform.GetChild(0).GetComponent<RectTransform>().rect.height
        {
            yield return new WaitForSeconds(0.1f);
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, y);
            y += 0.5f;
        }

        SceneManager.LoadScene("Intro");
        SoundManager.instance.PlayBGM("introNomal");
    }
}
