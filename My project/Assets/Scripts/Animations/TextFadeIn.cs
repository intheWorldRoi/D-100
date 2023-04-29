using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class TextFadeIn : MonoBehaviour
{
    public GameObject NoMoneyED;
    public GameObject overwhelming;
    public GameObject endingCredit;

    // Start is called before the first frame update
    float alpha;
    private void Awake()
    {
        alpha = 0.1f;
        overwhelming.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
    }
    void Start()
    {
        StartCoroutine(fadein());
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha >= 1f)
        {
            endingCredit.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    IEnumerator fadein()
    {
        while (alpha <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            overwhelming.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, alpha);
            alpha += 0.1f;
        }
        
    }

}
