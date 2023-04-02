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
            ActionDialogues.sentences.Add("��....");
            ActionDialogues.sentences.Add("��¥ �ʹ� �ϱ� �ȴ�.");
            //�̷��� �ν�Ÿ�� ���Ͱ��νð� �����ϴ� sns�����̺�Ʈ �����ϸ� �ְ��ϰͰ����� �ð��� �ϴ��� �ؽ�Ʈ��.
            ActionDialogues.sentences.Add("�� ģ���� �ǳ� �����ؼ� �ø��µ�.");
            ActionDialogues.sentences.Add("������� ������ ...");
            ActionDialogues.sentences.Add("��... XX");
            ActionDialogues.sentences.Add("��¥ .... ¥������..");
        }
        else if (StatusManager.Stress > 50)
        {
            ActionDialogues.name = "jay";
            ActionDialogues.sentences.Add("...");
            ActionDialogues.sentences.Add(".......");
            ActionDialogues.sentences.Add("......");
            ActionDialogues.sentences.Add("�ʹ� ������ �ȵ�.");
            ActionDialogues.sentences.Add("��� ����� �� ���� ...");
            ActionDialogues.sentences.Add("�� ��.. �ν�Ÿ ���ϱ� �ٵ� ���Ͱ��� 12�ð��� �ϴ���");
            ActionDialogues.sentences.Add("�̰͵� ���ϸ� �� �������ž�.");

        }
        else
        {
            ActionDialogues.name = "jay";
            ActionDialogues.sentences.Add("���Ͱ��θ� ����.");
        }
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
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("���� ��������");
    }
    public void AlbaDialogue()
    {
        ActionDialogues.sentences.Clear();
        ActionDialogues.name = "jay";
        ActionDialogues.sentences.Add("...�� ����...");
    }

}
