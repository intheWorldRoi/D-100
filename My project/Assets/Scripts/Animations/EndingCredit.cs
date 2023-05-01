using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndingCredit : MonoBehaviour
{
    float alpha;
    float y;
    float[] alphaT;
    VideoPlayer player;

    GameObject texts;
    // Start is called before the first frame update

    private void Awake()
    {
        alphaT = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        alpha = 0.1f;
        y = -60f;
        transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        transform.GetChild(0).GetComponent< RectTransform >().anchoredPosition = new Vector2(0, y);

    }
    void Start()
    {
        StartCoroutine(Fadein());
        Invoke("replay", 5f);
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
    
    IEnumerator fadein(GameObject o)
    {
        for(int i = 0; i < alphaT.Length; i++)
        {
            while (alphaT[i] <= 1f)
            {
                yield return new WaitForSeconds(0.1f);
                o.transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, alphaT[i]);
                alphaT[i] += 0.1f;
            }
            yield return new WaitForSeconds(1f);
        }
        
       
    }
    void txtEff()
    {
        StartCoroutine(fadein(texts));
    }

    void playFog()
    {
        player.Play();

    }
    private void replay()
    {
            StopCoroutine(Fadein());
            StartCoroutine(Up());
    }
    IEnumerator Up()
    {
        while (y <= transform.GetChild(0).GetComponent<RectTransform>().rect.height)
        {
            yield return new WaitForSeconds(0.1f);
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, y);
            y += 0.5f;
        }

        SceneManager.LoadScene("Intro");
        SoundManager.instance.PlayBGM("introNomal");
    }
}
