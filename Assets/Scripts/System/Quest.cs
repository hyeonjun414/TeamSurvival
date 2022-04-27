using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum QuestType
{
    COLLECT,
    KILL,
    ESCORT,
    DELIVERY,
}

public class Quest : MonoBehaviour
{
    [TextArea]
    public string title;
    [TextArea]
    public string sub;
    public MonsterData target;
    public int curCount;
    public int maxCount;

    public bool isFinish = false;
    public int code =0;


    // public UnityAction<Quest> OnStart;
    // public UnityAction<Quest> OnComplete;
    
    // // 퀘스트의 종류 -> 몬스터 잡기나 배송, 아이템 수집 같은 퀘스트
    // public QuestType type;

    // public bool isActive; // 퀘스트를 받기 가능한 상황인가?
    // public bool isStarted = false; // 퀘스트가 수락됐을 때
    // public bool isFinished = false; // 퀘스트가 완료됐을 때

    // public string title;

    // [TextArea]
    // public string description;

    // public GameObject requirement;

    // public int curAmount;       // 현재량
    // public int requireAmount;   // 필요량

    // public int expReward;
    // public int goldReward;

    // public ItemData itemReward;

    // public Conversation accept, progress, complete;

    // public Quest[] nextQuests;

    // private void Start()
    // {
    //     OnStart += QuestManager.Instance.QuestStart;
    //     OnComplete += QuestManager.Instance.QuestComplete;
    // }

    // public void Accept()
    // {
    //     OnStart?.Invoke(this);
    //     isStarted = true;
    //     print($"{title}이(가) 수락되었습니다.");
    // }
    
    // public void Progress()
    // {
    //     curAmount++;
    //     if(curAmount >= requireAmount)
    //     {
    //         print($"{title} 이(가) 완료!  - {curAmount}/{requireAmount}");
    //         isFinished = true;
    //     }
    //     else
    //         print($"{title} 이(가) 진행중!  - {curAmount}/{requireAmount}");
    // }
    // public void Complete()
    // {
    //     OnComplete?.Invoke(this);
    //     isActive = false;
    //     if(nextQuests.Length > 0)
    //     {
    //         foreach (Quest quest in nextQuests)
    //         {
    //             quest.isActive = true;
    //         }
    //     }

    //     print($"{title}이(가) 완료되었습니다.");
    // }

    // public bool Interaction()
    // {
    //     if(!isStarted) // 수락 전
    //     {
    //         bool reaction = accept.Interaction();
    //         if(reaction)
    //         {
    //             return true;
    //         }
    //         else
    //         {
    //             Accept();
    //             return false;
    //         }
    //     }
    //     else if (!isFinished) // 진행 중
    //     {
    //         return progress.Interaction();
    //     }
    //     else // 완료 시
    //     {
    //         bool reaction = complete.Interaction();
    //         if (reaction)
    //         {
    //             return true;
    //         }
    //         else
    //         {
    //             Complete();
    //             return false;
    //         }
    //     }
    // }


}
