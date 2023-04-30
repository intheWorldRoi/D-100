using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class TextFadeIn : MonoBehaviour
{
    public GameObject endingType;
    public GameObject endingCredit;

    // Start is called before the first frame update
    float alpha;
    private void Awake()
    {
        alpha = 0.1f;
        endingType.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
    }
    void Start()
    {
       StartCoroutine(fadein(endingType));
    }

    // Update is called once per frame


    IEnumerator fadein(GameObject o)
    {
        while (alpha <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            o.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, alpha);
            alpha += 0.1f;
        }
        yield return new WaitForSeconds(3f);
        endingCredit.SetActive(true);
        gameObject.SetActive(false);
    }

}
