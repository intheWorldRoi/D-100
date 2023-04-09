using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestThings : MonoBehaviour
{
    GameObject playRest;
    public GameObject RestUI;
    public GameObject dataManager;

    DialogueData data;

    int n;
    // Start is called before the first frame update
    void Start()
    {
        playRest = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; //하이어라키 창의 playRest
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void thingChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        DialogueSystem.IsInAction = true;

        if (gameObject.transform.name == "choice1")
        {
            RestUI.SetActive(false);
            ActionManager.Rest();

            n = UnityEngine.Random.Range(0, data.DoEat.Count);
            system.GetComponent<DialogueSystem>().Begin(data.DoEat[n]);
            GameManager.money -= 3;
            StatusManager.Stress -= 5;
            StatusManager.Happyness += 5;


        }
        else if(gameObject.transform.name == "choice2")
        {
            RestUI.SetActive(false);
            ActionManager.Rest();

            n = UnityEngine.Random.Range(0, data.DoOTT.Count);
            system.GetComponent<DialogueSystem>().Begin(data.DoOTT[n]);
        }
        else if (gameObject.transform.name == "choice3")
        {
            RestUI.SetActive(false);
            ActionManager.Rest();

            n = UnityEngine.Random.Range(0, data.DoSNS.Count);
            system.GetComponent<DialogueSystem>().Begin(data.DoSNS[n]);
        }

    }
}
