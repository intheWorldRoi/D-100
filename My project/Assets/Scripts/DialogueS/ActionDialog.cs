using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDialog : MonoBehaviour
{
    public Dialogue ActionDialogues;
    public List<Dialogue> paragragh = new List<Dialogue>();

    public void ToeicDialogue() {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("토익 인강은 해커스~");
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
        ActionDialogues.name = "mongmong";
        ActionDialogues.sentences.Add("어디로 나가볼까");
    }
    public void AlbaDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "mongmong";
        ActionDialogues.sentences.Add("...돈 벌자...");
    }

}
