using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avoidClick : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(noClick());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator noClick()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            this.transform.GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.2f);
            this.transform.GetComponent<Button>().interactable = true;

        }

    }
}
