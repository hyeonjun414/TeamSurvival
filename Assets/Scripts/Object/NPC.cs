using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Conversation conversation;

    public Quest[] quests;
    public Quest curQuest;

    public Mark mark;

    private void Awake()
    {
        quests = GetComponentsInChildren<Quest>();
    }
    private void Update()
    {
        MarkSelect();

    }
    public bool Interaction()
    {
        // 1. 가능한 퀘스트가 있으면 퀘스트 진행
        foreach(Quest quest in quests)
        {
            if(quest.isActive)
            {
                return quest.Interaction();
            }
        }


        // 2. 퀘스트가 없다면 평소 대화
        return conversation.Interaction();
    }
    void MarkSelect()
    {
        if (quests.Length == 0) return;

        foreach(Quest quest in quests)
        {
            if(quest.isActive)
            {
                mark.gameObject.SetActive(true);

                if(quest.isStarted)
                {
                    if(quest.isFinished)
                    {
                        mark.SetSprite(2);
                    }
                    else
                    {
                        mark.SetSprite(1);
                    }
                }
                else
                {
                    mark.SetSprite(0);
                }
                return;
            }
        }

        mark.gameObject.SetActive(false);
    }
}
