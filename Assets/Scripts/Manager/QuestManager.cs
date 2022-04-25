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

    Quest[] quests;
    Quest curQuest;

    public Dialog ui;
    public Text title;
    public Text desc;

    private void Awake()
    {
        instance = this;
            
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(null != curQuest)
            {
                title.text = curQuest.title;
                desc.text = curQuest.description;
            }
            else
            {
                title.text = "퀘스트 없음";
                desc.text = "퀘스트 없음";
            }
            if(ui.gameObject.activeSelf)
            {
                ui.anim.SetTrigger("Disable");
            }
            else
            {
                ui.gameObject.SetActive(!ui.gameObject.activeSelf);
            }
        }
    }
    public void QuestStart(Quest quest)
    {
        // 퀘스트 창에 현재 퀘스트를 띄워주기
        print("퀘스트 시작");
        print($"퀘스트 이름 : {quest.title}");
        print($"퀘스트 설명 : {quest.description}");

        curQuest = quest;

        switch (curQuest.type)
        {
            case QuestType.COLLECT:
                DropItem.OnGlobalObtain += OnItemCollect;
                break;
            case QuestType.KILL:
                Enemy.OnGlobalKill += OnKillEnemy;
                break;
        }

    }
    public void QuestComplete(Quest quest)
    {
        // 보상 진행
        print("퀘스트 완료");
        print($"퀘스트 보상 골드 : {quest.goldReward}");
        print($"퀘스트 보상 경험치 : {quest.expReward}");
        
        switch(curQuest.type)
        {
            case QuestType.COLLECT:
                DropItem.OnGlobalObtain -= OnItemCollect;
                break;
            case QuestType.KILL:
                Enemy.OnGlobalKill -= OnKillEnemy;
                break;
        }

        InventoryManager.Instance.Add(quest.itemReward);

        curQuest = null;

        
    }

    public void OnItemCollect(DropItem item)
    {
        DropItem curTarget = curQuest.requirement.GetComponent<DropItem>();

        if (null == curQuest ||
            curQuest.type != QuestType.COLLECT ||
            curTarget.itemName != item.itemName)
            return;

        curQuest.Progress();

    }
    public void OnKillEnemy(Enemy enemy)
    {
        Enemy curTarget = curQuest.requirement.GetComponent<Enemy>();

        if (null == curQuest ||
            curQuest.type != QuestType.KILL ||
            curTarget.enemyName != enemy.enemyName)
            return;

        curQuest.Progress();
    }

}
