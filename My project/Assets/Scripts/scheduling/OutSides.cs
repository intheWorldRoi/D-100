using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSides : MonoBehaviour
{
    GameObject playGoOut;
    public GameObject GoOutUI;
    public GameObject dataManager;

    DialogueData data;

    int num;
    private void Awake()
    {
        playGoOut = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; //하이어라키 창의 playGoOut
    }
    // Start is called before the first frame update
    public void PlaceChoice()
    {
        data = dataManager.GetComponent<DialogueData>();
        var system = FindObjectOfType<DialogueSystem>();
        DialogueSystem.IsInAction = true;

        if (gameObject.transform.name == "choice1")
        {
            SoundManager.instance.PlayBGM("park");
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            ActionManager.GoOut();
            num = UnityEngine.Random.Range(0, data.GoPark.Count);
            system.GetComponent<DialogueSystem>().Begin(data.GoPark[num]);
            
        }
        else if(gameObject.transform.name == "choice2")
        {
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            ActionManager.GoOut();
            GameManager.money -= 3;
            StatusManager.innerpeace += 3;
            StatusManager.Joy += 10;
            num = UnityEngine.Random.Range(0, data.GoTheater.Count);
            system.GetComponent<DialogueSystem>().Begin(data.GoTheater[num]);
        }
        else if (gameObject.transform.name == "choice3")
        {
            SoundManager.instance.PlayBGM("park");
            GoOutUI.SetActive(false);
            playGoOut.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            ActionManager.GoOut();
            num = UnityEngine.Random.Range(0, data.GoAnyWhere.Count);
            system.GetComponent<DialogueSystem>().Begin(data.GoAnyWhere[num]);
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
