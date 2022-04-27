using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<QuestManager>();

            return instance;
        }
    }
    public Quest[] quests;      // 전체 퀘스트 목록
    public Quest[] curQuests;   // 현재 퀘스트 목록

    // 현재 퀘스트 0
    public Text title0;
    public Text sub0;
    public Text count0;
    // 현재 퀘스트 1
    public Text title1;
    public Text sub1;
    public Text count1;
    // 현재 퀘스트 2
    public Text title2;
    public Text sub2;
    public Text count2;
    List<int> questList = new List<int>();
    int randomQuest;
    private void Awake()
    {
        instance = this;
        curQuests[0] = quests[0];
        curQuests[1] = quests[1];
        curQuests[2] = quests[2];
        questList.Add(0);
        questList.Add(1);
        questList.Add(2);

        AllChange();
    }
    private void Update() {
        if (Input.GetKeyDown("z"))
        {
            curQuests[0].curCount++;
            CountChange();
            FinishCheck();
        }
        if (Input.GetKeyDown("x"))
        {
            curQuests[1].curCount++;
            CountChange();
            FinishCheck();
        }
        if (Input.GetKeyDown("c"))
        {
            curQuests[2].curCount++;
            CountChange();
            FinishCheck();
        }
    }

    private void KillCheck(string targetname){  // TODO : 몬스터와 연결
        for (int i = 0; i < 3; i++)
        {
            if (curQuests[i].target.name == targetname)
            {
                curQuests[i].curCount++;
                CountChange();
                FinishCheck();
            }
        }
    }

    private void Renew(){
        for (int i = 0; i < 3; i++)
        {
            if (curQuests[i].isFinish)
            {
                curQuests[i].isFinish = false;
                questList.Remove(curQuests[i].code);

                randomQuest = Random.Range(0,5);
                for (int j = 0; j < 1;)
                {
                    if (questList.Contains(randomQuest))
                        randomQuest = Random.Range(0,5);
                    else
                    {
                        curQuests[i] = quests[randomQuest];
                        questList.Add(randomQuest);
                        j++;
                    } 
                }
            }
        }
    }

    private void FinishCheck(){
        foreach(Quest quest in curQuests)
        {
            if (quest.curCount >= quest.maxCount)   // 퀘스트 조건 충족 ?
            {
                quest.curCount = 0; // 진행도 초기화
                quest.isFinish = true;
                RewardManager.Instance.ExcuteReward(RewardType.Talent);
                Renew();            // 퀘스트 변경
                AllChange();        // 퀘스트 변경 UI 적용
            }     
        }
    }
    private void AllChange(){
        title0.text = curQuests[0].title.ToString();
        sub0.text = curQuests[0].sub.ToString();
        count0.text = curQuests[0].curCount.ToString() + " / " + curQuests[0].maxCount.ToString();

        title1.text = curQuests[1].title.ToString();
        sub1.text = curQuests[1].sub.ToString();
        count1.text = curQuests[1].curCount.ToString() + " / " + curQuests[1].maxCount.ToString();

        title2.text = curQuests[2].title.ToString();
        sub2.text = curQuests[2].sub.ToString();
        count2.text = curQuests[2].curCount.ToString() + " / " + curQuests[2].maxCount.ToString();
    }

    private void CountChange(){
        count0.text = curQuests[0].curCount.ToString() + " / " + curQuests[0].maxCount.ToString();
        count1.text = curQuests[1].curCount.ToString() + " / " + curQuests[1].maxCount.ToString();
        count2.text = curQuests[2].curCount.ToString() + " / " + curQuests[2].maxCount.ToString();
    }

    
    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Q))
    //     {
    //         if(null != curQuest)
    //         {
    //             title.text = curQuest.title;
    //             desc.text = curQuest.description;
    //         }
    //         else
    //         {
    //             title.text = "퀘스트 없음";
    //             desc.text = "퀘스트 없음";
    //         }
    //         if(ui.gameObject.activeSelf)
    //         {
    //             ui.anim.SetTrigger("Disable");
    //         }
    //         else
    //         {
    //             ui.gameObject.SetActive(!ui.gameObject.activeSelf);
    //         }
    //     }
    // }
    // public void QuestStart(Quest quest)
    // {
    //     // 퀘스트 창에 현재 퀘스트를 띄워주기
    //     print("퀘스트 시작");
    //     print($"퀘스트 이름 : {quest.title}");
    //     print($"퀘스트 설명 : {quest.description}");

    //     curQuest = quest;

    //     switch (curQuest.type)
    //     {
    //         case QuestType.COLLECT:
    //             DropItem.OnGlobalObtain += OnItemCollect;
    //             break;
    //         case QuestType.KILL:
    //             Enemy.OnGlobalKill += OnKillEnemy;
    //             break;
    //     }

    // }
    // public void QuestComplete(Quest quest)
    // {
    //     // 보상 진행
    //     print("퀘스트 완료");
    //     print($"퀘스트 보상 골드 : {quest.goldReward}");
    //     print($"퀘스트 보상 경험치 : {quest.expReward}");
        
    //     switch(curQuest.type)
    //     {
    //         case QuestType.COLLECT:
    //             DropItem.OnGlobalObtain -= OnItemCollect;
    //             break;
    //         case QuestType.KILL:
    //             Enemy.OnGlobalKill -= OnKillEnemy;
    //             break;
    //     }

    //     InventoryManager.Instance.Add(quest.itemReward);

    //     curQuest = null;

        
    // }

    // public void OnItemCollect(DropItem item)
    // {
    //     DropItem curTarget = curQuest.requirement.GetComponent<DropItem>();

    //     if (null == curQuest ||
    //         curQuest.type != QuestType.COLLECT ||
    //         curTarget.itemName != item.itemName)
    //         return;

    //     curQuest.Progress();

    // }
    // public void OnKillEnemy(Enemy enemy)
    // {
    //     Enemy curTarget = curQuest.requirement.GetComponent<Enemy>();

    //     if (null == curQuest ||
    //         curQuest.type != QuestType.KILL ||
    //         curTarget.enemyName != enemy.enemyName)
    //         return;

    //     curQuest.Progress();
    // }
}
