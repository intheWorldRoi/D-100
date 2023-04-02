using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDialog : MonoBehaviour
{
    public Dialogue ActionDialogues;
    public List<Dialogue> paragragh = new List<Dialogue>();

    public void ToeicDialogue() {
        ActionDialogues.sentences.Clear();
        if (StatusManager.Stress > 70)
        {
            ActionDialogues.name = "jay";
            ActionDialogues.sentences.Add("하....");
            ActionDialogues.sentences.Add("진짜 너무 하기 싫다.");
            //이러고 인스타로 토익공부시간 인증하는 sns강제이벤트 구현하면 최고일것같은데 시간상 일단은 텍스트만.
            ActionDialogues.sentences.Add("내 친구는 맨날 인증해서 올리는데.");
            ActionDialogues.sentences.Add("재수없는 새끼들 ...");
            ActionDialogues.sentences.Add("하... XX");
            ActionDialogues.sentences.Add("진짜 .... 짜증난다..");
        }
        else if (StatusManager.Stress > 50)
        {
            ActionDialogues.name = "jay";
            ActionDialogues.sentences.Add("...");
            ActionDialogues.sentences.Add(".......");
            ActionDialogues.sentences.Add("......");
            ActionDialogues.sentences.Add("너무 집중이 안돼.");
            ActionDialogues.sentences.Add("계속 기분이 안 좋아 ...");
            ActionDialogues.sentences.Add("안 돼.. 인스타 보니까 다들 토익공부 12시간씩 하던데");
            ActionDialogues.sentences.Add("이것도 못하면 난 떨어질거야.");

        }
        else
        {
            ActionDialogues.name = "jay";
            ActionDialogues.sentences.Add("토익공부를 하자.");
        }
    }
    public void FitnessDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("득근득근~");
    }
    public void ReadingDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("무슨 책을 읽을까");
    }
    public void RestDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("집에서 쉬자");
    }
    public void GoOutDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("어디로 나가볼까");
    }
    public void AlbaDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("...돈 벌자...");
    }

}
