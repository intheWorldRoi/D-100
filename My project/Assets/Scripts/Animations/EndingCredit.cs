using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{
    float alpha;
    float y;
    // Start is called before the first frame update

    private void Awake()
    {

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
