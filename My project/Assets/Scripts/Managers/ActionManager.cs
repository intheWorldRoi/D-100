using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionManager : MonoBehaviour
{

    public static int NowActionIndex;
    public static int NowDayIndex;

    public TextMeshProUGUI DepNum, StrNum, LonNum, AnxNum, WilNum, joyNum, healTXT, moneyTXT;
    public GameObject Review;

    public GameObject data;

    SoundManager s;
    //public static string readingBook;

    private void Start()
    {
        s = SoundManager.instance;
    }
    public static bool PNP() {
        if (StatusManager.Stress > 70 || StatusManager.Willingness < 40 || StatusManager.Joy < 40)
            return false;
        else
            return true;
    }

    public static bool SNS()
    {
        if (StatusManager.Depress > 55 && StatusManager.Willingness < 45)      //우울하고 의지 없을 시 SNS
        {
            StatusManager.Lonely += 3;
            StatusManager.Anxiety += 5;
            StatusManager.innerpeace -= 10;
            return true;
        }
        else
            return false;
    }
    public static void Toeic(bool pass)
    {
        if (pass)
        {
            StatusManager.Engknowledge += 5;
            StatusManager.Joy -= 2;
            StatusManager.Anxiety -= 3;
            StatusManager.Stress += 3;
        }
        else {
            StatusManager.Engknowledge += 3;
            StatusManager.Joy -= 5;
            StatusManager.Anxiety -= 1;
            StatusManager.Stress += 3;
        }
    }
    public static void Fitness(bool pass)
        {
            if (pass) {
                StatusManager.healthy += 5;
                StatusManager.Willingness += 3;
                StatusManager.Depress -= 3;
                StatusManager.Stress += 3;
                StatusManager.Joy += 2;
            }
            else{
                StatusManager.healthy += 2;
                StatusManager.Willingness += 1;
                StatusManager.Depress -= 1;
                StatusManager.Stress += 3;
            }
        }
    public static void Reading(int index)
    {
        StatusManager.Stress += 3;
        switch (index) {
            case 0:
                {
                    StatusManager.Anxiety += 5;
                    StatusManager.Willingness += 10;
                    StatusManager.innerpeace += 3;
                    if (StatusManager.Willingness < 30)
                    {
                        StatusManager.Willingness += 20;
                    }
                    break;
                }
            case 1:
                {
                    StatusManager.Anxiety -= 10;
                    StatusManager.Depress -= 5;
                    StatusManager.innerpeace += 3;
                    
                    break;
                }
            case 2:
                {
                    StatusManager.Anxiety -= 3;
                    StatusManager.Joy += 5;
                    StatusManager.innerpeace += 5;
                    StatusManager.Depress -= 5;
                    break;
                }
        }
    }

    public static void Rest()
    {

        if(StatusManager.Stress > 80)
        {
            StatusManager.Stress -= 40;
        }
        else if(StatusManager.Stress > 70)
        {
            StatusManager.Stress -= 30;
        }
        else if (StatusManager.Stress > 60)
        {
            StatusManager.Stress -= 20;
        }
        else if (StatusManager.Anxiety > 70)
        {
            StatusManager.Stress -= 1;
            StatusManager.Depress -= 1;
            StatusManager.Joy += 3;
        }
        else
        {
            StatusManager.Stress -= 15;
            StatusManager.Depress -= 3;
            StatusManager.Joy += 10;
        }
        StatusManager.Anxiety += 3;
        StatusManager.Lonely += 3;
        StatusManager.Willingness -= 3;
    }

    public static void GoOut()
    {
        if (StatusManager.Anxiety > 70)
        {
            StatusManager.Anxiety -= 25;
        }
        if (StatusManager.Depress > 70)
        {
            StatusManager.Depress -= 25;
        }
        else
        {
            StatusManager.Depress -= 3;
            StatusManager.Anxiety -= 3;
            StatusManager.Joy += 3;
        }
        if(StatusManager.Lonely > 70)
        {
            StatusManager.Lonely -= 10;
        }
        StatusManager.Stress -= 3;                // ????
        StatusManager.Lonely -= 10;
        StatusManager.innerpeace += 3;
        GameManager.money -= 1;
    }

    public static void Partjob()
    {
        StatusManager.Stress += 5;
        StatusManager.Joy -= 3;
        StatusManager.Lonely -= 1;
        StatusManager.Anxiety -= 1;
        StatusManager.healthy -= 1;
        GameManager.money += 10;
    }
    public static void HowAreYou()
    {
        StatusManager.Lonely += 5;
        StatusManager.Anxiety += 5;

        if (StatusManager.healthy < 50)
        {
            StatusManager.Depress += 3;
            StatusManager.Willingness -= 3;
            StatusManager.Joy -= 3;
        }


        if (StatusManager.Lonely > 50)
        {
            StatusManager.Depress += 3;
            StatusManager.Joy -= 3;
        }


        if (StatusManager.Joy < 50 || StatusManager.Depress >50)
        {
            StatusManager.Willingness -= 3;
        }

        if (StatusManager.Anxiety > 70)
        {
            StatusManager.Willingness +=10;
            StatusManager.Stress += 5;
            StatusManager.innerpeace -= 5;
        }
        else if(StatusManager.Anxiety > 60)
        {
            StatusManager.Willingness += 5;
            StatusManager.Depress += 3;
            StatusManager.Stress += 3;
            StatusManager.innerpeace -= 3;
        }
        else if(StatusManager.Anxiety>50)
        {
            StatusManager.Willingness += 3;
            StatusManager.Depress += 3;
            StatusManager.Stress += 1;
            StatusManager.innerpeace -= 1;
        }


        if (StatusManager.Stress > 70)
        {
            StatusManager.Depress += 5;
            StatusManager.healthy -= 3;
        }

        else if (StatusManager.Stress > 50)
        {
            StatusManager.Depress += 3;
            StatusManager.healthy -= 2;
        }
        else
        {
            StatusManager.Depress += 1;
            StatusManager.healthy -= 1;
        }

        if(StatusManager.innerpeace > 50)
        {
            StatusManager.Anxiety -= 1;
        }
        else if(StatusManager.innerpeace > 100)
        {
            StatusManager.Anxiety -= 3;
        }
        else if(StatusManager.innerpeace > 150)
        {
            StatusManager.Anxiety -= 5;
        }
    }

    public void ReviewIndicate(string Dep, string Str, string Lon, string Anx, string Wil, string Joy, string Health, string Money) 
    {
        StartCoroutine(Fadein(Review, 0.5f, 0));
        
        StartCoroutine(Fadein(Review.transform.GetChild(0).gameObject, 1.5f, 1f));
        
        StartCoroutine(TextFadein(Review.transform.GetChild(0).GetChild(0).gameObject, 1.2f));
        StartCoroutine(TextFadein(Review.transform.GetChild(0).GetChild(2).GetChild(0).gameObject, 1.2f));
        StartCoroutine(TextFadein(Review.transform.GetChild(0).GetChild(2).GetChild(1).gameObject, 1.2f));
        StartCoroutine(Fadein(Review.transform.GetChild(0).GetChild(3).gameObject, 1.2f, 1f));

        StartCoroutine(Reviewsururuk(Dep,Str,Lon,Anx,Wil,Joy, Health, Money));
    }

    IEnumerator Fadein(GameObject o, float maxAlpha, float wait)
    {
        float a = 0;
        
         yield return new WaitForSeconds(wait);
        

        yield return new WaitForSeconds(0.2f);
        while (a <= maxAlpha)
        {
            Debug.Log("a = " + a);
            o.GetComponent<Image>().color = new Color(o.GetComponent<Image>().color.r, o.GetComponent<Image>().color.g, o.GetComponent<Image>().color.b, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator TextFadein(GameObject o, float maxAlpha)
    {
        float a = 0;
        
        if (o.name == "reviewWeek")
        {
            yield return new WaitForSeconds(2f);
        }
        else if (o.name == "mind")
        {
            yield return new WaitForSeconds(2.5f);
        }
        else if (o.name == "Implicit")
        {
            yield return new WaitForSeconds(3.5f);
        }


        yield return new WaitForSeconds(0.2f);
        while (a <= maxAlpha)
        {
            Debug.Log("a = " + a);
            o.GetComponent<TextMeshProUGUI>().color = new Color(o.GetComponent<TextMeshProUGUI>().color.r, o.GetComponent<TextMeshProUGUI>().color.g, o.GetComponent<TextMeshProUGUI>().color.b, a);
            a += 0.1f;
            
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator Reviewsururuk(string Dep, string Str, string Lon, string Anx, string Wil, string Joy, string Health, string Money)
    {
        TypeEffect DepEffect = DepNum.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect StrEffect = StrNum.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect LonEffect = LonNum.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect AnxEffect = AnxNum.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect WilEffect = WilNum.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect JoyEffect = joyNum.transform.gameObject.GetComponent<TypeEffect>(); //최적화 가능한 방법이 없을까...?
        TypeEffect HealEffect = healTXT.transform.gameObject.GetComponent<TypeEffect>();
        TypeEffect MoneyEffect = moneyTXT.transform.gameObject.GetComponent<TypeEffect>();



        yield return new WaitForSeconds(3f);
        s.PlaySound("bororong");
        DepEffect.SetMsg("우울 : " + Dep + "만큼 증가했습니다.");
        yield return new WaitForSeconds(0.5f);
        StrEffect.SetMsg("스트레스 : " + Str + "만큼 증가했습니다.");
        yield return new WaitForSeconds(0.5f);
        LonEffect.SetMsg("외로움 : " + Lon + "만큼 증가했습니다.");
        yield return new WaitForSeconds(0.5f);
        s.PlaySound("bororong");
        AnxEffect.SetMsg("불안 : " + Anx + "만큼 증가했습니다.");
        yield return new WaitForSeconds(0.5f);
        WilEffect.SetMsg("의지 : " + Wil + "만큼 증가했습니다.");
        yield return new WaitForSeconds(0.5f);
        JoyEffect.SetMsg("즐거움 : " + Joy + "만큼 증가했습니다");

        yield return new WaitForSeconds(1f);
        if (StatusManager.healthy > 50 && StatusManager.healthy <80)
        {
            s.PlaySound("bororong");
            HealEffect.SetMsg("건강이 양호하다. 조금만 더 운동하면 될 것 같아!");
        }
        else if(StatusManager.healthy < 20)
        {
            s.PlaySound("bororong");
            HealEffect.SetMsg("건강이 매우 좋지 않은 것 같다..");
        }
        else if (StatusManager.healthy >= 80)
        {
            s.PlaySound("bororong");
            HealEffect.SetMsg("내가 이보다 더 건강했던 적이 있던가 ...?");
        }
        else
        {
            s.PlaySound("bororong");
            HealEffect.SetMsg("건강이 그닥 좋지 않다.. 운동을 더 해야겠다.");
        }


        yield return new WaitForSeconds(0.5f);
        s.PlaySound("bororong");
        MoneyEffect.SetMsg("돈이 " + Money + "만큼 증가했습니다.");
        

    }

    public IEnumerator WeekDiary(int week)
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fadein(Review, 0.4f, 0));
        GameObject notepad = Review.transform.GetChild(2).gameObject;
        StartCoroutine(Fadein(notepad, 1.2f, 0.5f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(TextFadein(notepad.transform.GetChild(0).gameObject, 1.2f));
        yield return new WaitForSeconds(0.4f);
        SoundManager.instance.PlaySound("sagaksagak");
        StartCoroutine(TextFadein(notepad.transform.GetChild(1).gameObject, 1.2f));
        notepad.transform.GetChild(1).gameObject.GetComponent<TypeEffect>().SetMsg(data.GetComponent<DialogueData>().diarys[week-2]);

    }
}
