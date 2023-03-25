using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goActions : MonoBehaviour
{
    public int dayIndex;
    public int actionIndex;

    void OnEnable()
    {
        dayIndex = 0;
        actionIndex = 0;
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void nextPlay()
    {
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);
        if (actionIndex == Diary.actionList[dayIndex].Count)
        {
            actionIndex = 0;
            dayIndex++;
        }
        if (dayIndex == 7)
        {
            gameObject.SetActive(false);
        }
        
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);
    }
}

/*private void OnEnable()
 {
     StartCoroutine(perform(Diary.actionList));
 }
 IEnumerator perform (List<List<int>> actionList)
 {
     for (int i = 0; i < actionList.Count; i++)
     {
         for(int j = 0; j < actionList[i].Count; j++)
         {
             transform.GetChild(actionList[i][j]).gameObject.SetActive(true);
             yield return new WaitForSeconds(2.0f);
         }
     }
 }*/