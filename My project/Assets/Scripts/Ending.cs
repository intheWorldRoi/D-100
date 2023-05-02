using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ending : MonoBehaviour
{

    public GameObject[] badDummys;
    public float wait;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void badEndingAnimation()
    {
        StartCoroutine(dummysUp());
    }

    public IEnumerator dummysUp()
    {
        yield return new WaitForSeconds(1f);
        for(int i = 0; i <badDummys.Length; i++)
        {

            
           
            badDummys[i].SetActive(true);
            yield return new WaitForSeconds(0.01f);
            SoundManager.instance.PlaySound("chalkak");

            yield return new WaitForSeconds(wait);

        }

        yield return new WaitForSeconds(2f);
        for(int i =0; i < badDummys.Length; i++)
        {
            for (float j = 1.2f; j > -0.3f; j -= 0.1f)
            {
                badDummys[i].GetComponent<Image>().color = new Color(255, 255, 255, j);
                badDummys[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(badDummys[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color.r,
                    badDummys[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color.b, badDummys[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color.g, j);
                yield return new WaitForSeconds(0.01f);
            }
            
        }

        Invoke("NextBadDialogue", 2f);
        //StartCoroutine(NextBadDialogue());

        
    }
    /*IEnumerator NextBadDialogue()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.parent.GetComponent<DialogueSystem>().Begin(gameObject.transform.GetChild(0).GetComponent<DialogueTrigger>().info[8]);

    }*/

    void NextBadDialogue()
    {
        gameObject.transform.parent.GetComponent<DialogueSystem>().Begin(gameObject.transform.GetChild(0).GetComponent<DialogueTrigger>().info[8]);
    }
}
