using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueData : MonoBehaviour
{
    string myname;

    Dictionary<int, string[]> TextData;

    public List<Dialogue> ReadingBooks;

    private void Awake()
    {
        
        

    }

    private void OnMouseDown()
    {
        //TextData[100];
    }



    void GenerateData()
    {
        TextData.Add(100, new string[] { "4시가 넘었는데", "안 자고있는 내 인생이 레전드", "아 아침 먹어야되는데", "이렇게 늦게자면 어뜨케먹어 병신이" });

        //독서의 자기계발서 다이얼로그 데이터
        ReadingBooks.Add(new Dialogue("name", new string[] { "자기계발서 ....", "읽으면 내가 정말 초라해지지만", "읽어야지만 내가 변할 수 있을거야." }));
            
            /*(111, new string[] { "사회부과적 완벽주의란" , "중요한 타인들이 자신에게 비현실적으로 높은 기준을 요구하고 있으며",
            "이를 충족해야만 인정을 받을 수 있다고 믿는 경향이다.", "...이러한 사회부과적 완벽주의는 ‘좌절된 소속감’과 ‘심리적 극통’을 거쳐",
            "자살충동을 불러일으키게 된다."});*/
    }


    
}
