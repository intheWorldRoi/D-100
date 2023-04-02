using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSides : MonoBehaviour
{
    GameObject playGoOut;
    public GameObject GoOutUI;
    public GameObject dataManager;

    DialogueData data;

    private void Awake()
    {
        playGoOut = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; //하이어라키 창의 playGoOut
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        DialogueSystem.IsInAction = true;

        if (gameObject.transform.name == "choice1")
        {
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(1).gameObject.SetActive(true);
            ActionManager.GoOut();
            
            system.GetComponent<DialogueSystem>().Begin(data.GoPark[0]);
            
        }
        else if(gameObject.transform.name == "choice2")
        {
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(2).gameObject.SetActive(true);
            ActionManager.GoOut();
            system.GetComponent<DialogueSystem>().Begin(data.GoTheater[0]);
        }
        else if (gameObject.transform.name == "choice3")
        {
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(3).gameObject.SetActive(true);
            ActionManager.GoOut();
            system.GetComponent<DialogueSystem>().Begin(data.GoAnyWhere[0]);
        }

    }

    private void OnMouseDown()
    {
        if(DialogueSystem.SwitchGoOut == true)
        {
            gameObject.SetActive(false);
            
        }
    }
}
