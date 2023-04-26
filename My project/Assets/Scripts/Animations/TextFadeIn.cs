using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public GameObject NoMoneyED;
    public GameObject overwhelming;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadein());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator fadein()
    {
        float a = 0.1f;
        while (a <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            overwhelming.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, a);
            a += 0.1f;
        }
        
        
    }
}
