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
        ActionDialogues.sentences.Add("���� �ΰ��� ��Ŀ��~");
    }
    public void FitnessDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("��ٵ��~");
    }
    public void ReadingDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("���� å�� ������");
    }
    public void RestDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("������ ����");
    }
    public void GoOutDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "mongmong";
        ActionDialogues.sentences.Add("���� ��������");
    }
    public void AlbaDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "mongmong";
        ActionDialogues.sentences.Add("...�� ����...");
    }

}
