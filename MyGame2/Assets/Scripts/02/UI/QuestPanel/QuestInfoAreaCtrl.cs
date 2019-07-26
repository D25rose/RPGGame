using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 管理任务面板右侧的UI和按钮
/// </summary>
public class QuestInfoAreaCtrl : MonoBehaviour {

    private QuestItem m_QuestItem;
     
    public QuestItem QuestItem
    {
        get { return m_QuestItem; }
        set { m_QuestItem = value;
            SetQuestInfo();
        }
    }

    private QuestInfoAreaView m_QuestInfoAreaView;

    private List<GameObject> requiredItemList;//需要条件物体的集合
    private List<GameObject> rewardItemList;//奖励物品物体的集合

    void Awake()
    {
        m_QuestInfoAreaView = gameObject.GetComponent<QuestInfoAreaView>();

        requiredItemList = new List<GameObject>();
        rewardItemList = new List<GameObject>();
    }

    private void SetQuestInfo()
    {
        ClearLastItems();//先清除上一次的需要条件

        m_QuestInfoAreaView.Text_QuestName.text = m_QuestItem.QuestName;//显示任务名称
        m_QuestInfoAreaView.Text_QuestDescr.text = m_QuestItem.QuestDescr;//显示任务描述

        //显示和NPC对话的要求
        foreach (var questNpc in m_QuestItem.QuestTalkNpc)
        {
            if (questNpc.NpcId != -1)
            {
                GameObject requiredItem = GameObject.Instantiate(m_QuestInfoAreaView.Prefab_RequiredItem, m_QuestInfoAreaView.RequiredGrid);
                requiredItem.GetComponent<RequiredItemCtrl>().InitView((questNpc.IsTalk == true ? 1 : 0), 1, string.Format("和{0}对话", questNpc.NpcId));
                requiredItemList.Add(requiredItem);
            }
        }

        //显示击杀敌人的要求
        foreach (var questEnemy in m_QuestItem.QuestKillEnemy)
        {
            if (questEnemy.EnemyId != -1)
            {
                GameObject requiredItem = GameObject.Instantiate(m_QuestInfoAreaView.Prefab_RequiredItem, m_QuestInfoAreaView.RequiredGrid);
                requiredItem.GetComponent<RequiredItemCtrl>().InitView(questEnemy.CurEnemyNum, questEnemy.EnemyNum, string.Format("击杀{0}", questEnemy.EnemyId));
                requiredItemList.Add(requiredItem);
            }
        }

        //显示需要的物品
        foreach (var needItem in m_QuestItem.QuestNeedItem)
        {
            if (needItem.ItemId != -1)
            {
                GameObject requiredItem = GameObject.Instantiate(m_QuestInfoAreaView.Prefab_RequiredItem, m_QuestInfoAreaView.RequiredGrid);
                int haveNum = InventoryPanelCtrl.Instance.GetItemCountById(needItem.ItemId);
                string itemName = GlobalInventoryItemManager.Instance.GetItemNameById(needItem.ItemId);
                requiredItem.GetComponent<RequiredItemCtrl>().InitView(haveNum, needItem.ItemNum, itemName);
                requiredItemList.Add(requiredItem);
            }
        }

        //显示任务奖励金钱数
        m_QuestInfoAreaView.Text_RewardGold.text = m_QuestItem.QuestRewardItem.Gold.ToString();
        //显示任务奖励物品
        foreach (var item in m_QuestItem.QuestRewardItem.RewardItem)
        {
            GameObject rewardItem = GameObject.Instantiate(m_QuestInfoAreaView.Prefab_RewardItem, m_QuestInfoAreaView.RewardGrid);
            rewardItem.GetComponent<RewardItemCtrl>().Init(item.ItemId, item.ItemNum);
            rewardItemList.Add(rewardItem);
        }
    }

    /// <summary>
    /// 清除上一次的需要条件和奖励物品
    /// </summary>
    private void ClearLastItems()
    {
        foreach (GameObject item in requiredItemList)
        {
            GameObject.Destroy(item);
        }
        requiredItemList.Clear();

        foreach (GameObject item in rewardItemList)
        {
            GameObject.Destroy(item);
        }
        rewardItemList.Clear();
    }

}
