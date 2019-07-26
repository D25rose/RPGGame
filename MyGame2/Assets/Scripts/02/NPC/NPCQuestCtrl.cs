using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestCtrl : MonoBehaviour {

    private List<QuestItem> questList;  //当前npc带有的任务
    [SerializeField]
    private int[] quests;   //任务的id
    [SerializeField]
    private int npcId;

    void Start()
    {
        questList = new List<QuestItem>();
        for(int i = 0; i < quests.Length; i++)
        {
            questList.Add(QuestPanelCtrl.Instance.GetQuestItemById(quests[i]));
        }
    }

    /// <summary>
    /// 鼠标点击NPC时
    /// </summary>
    void OnMouseDown()
    {
        //当该npc是接受的任务中的任务提交人时
        foreach (QuestItem quest in QuestPanelCtrl.Instance.AcceptQuestList)
        {
            if(quest.OverNpc == this.npcId)
            {
                if (IsQuestFinished(quest))
                {
                    quest.QuestSubmit = true;
                    RemoveQuestNeedItems(quest);    //扣除任务所需物品
                    TootipPanelManager.Instance.ShowTalkWithOverNPCTootip(quest);   //显示任务完成对话
                    return;
                }
            }
        }

        //当前接受的任务中是否有和这个npc谈话的要求
        foreach(QuestItem quest in QuestPanelCtrl.Instance.AcceptQuestList)
        {
            foreach(QuestItem.QuestNPC npc in quest.QuestTalkNpc)
            {
                if (!npc.IsTalk)
                {
                    if(npc.NpcId == this.npcId)
                    {
                        npc.IsTalk = true;
                        TootipPanelManager.Instance.ShowTalkWithRequireNPCTootip(npc);
                        return;
                    }
                }
            }
        }

        //如果有还未提交的任务，显示对话框
        foreach(QuestItem quest in questList)
        {
            if (!quest.QuestSubmit)
            {
                TootipPanelManager.Instance.ShowQuestDialogueTootip(quest);
                break;
            }
        }
    }

    /// <summary>
    /// 检测任务是否完成
    /// </summary>
    private bool IsQuestFinished(QuestItem quest)
    {
        //有要求对话的NPC
        if(quest.QuestTalkNpc[0].NpcId != -1)
        {
            foreach(QuestItem.QuestNPC npc in quest.QuestTalkNpc)
            {
                if(npc.IsTalk == false)
                {
                    return false;
                }
            }
        }
        //有要击杀的敌人
        if(quest.QuestKillEnemy[0].EnemyId != -1)
        {
            foreach(QuestItem.QuestEnemy enemy in quest.QuestKillEnemy)
            {
                if(enemy.CurEnemyNum < enemy.EnemyNum)
                {
                    return false;
                }
            }
        }
        //有要获得的物品
        if(quest.QuestNeedItem[0].ItemId != -1)
        {
            foreach(QuestItem.Quest_Item item in quest.QuestNeedItem)
            {
                if(InventoryPanelCtrl.Instance.GetItemCountById(item.ItemId) < item.ItemNum)
                {
                    return false;
                }
            }
        }
        quest.QuestState = true;
        return true;
    }

    /// <summary>
    /// 提交任务时从背包中移除任务所需物品
    /// </summary>
    private void RemoveQuestNeedItems(QuestItem quest)
    {
        foreach(QuestItem.Quest_Item item in quest.QuestNeedItem)
        {
            for(int i = 0; i < item.ItemNum; i++)
            {
                InventoryManager.Instance.RemoveItem(item.ItemId);
            }
        }
    }
}
