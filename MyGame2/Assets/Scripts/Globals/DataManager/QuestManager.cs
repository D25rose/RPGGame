using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局存储任务数据的管理器
/// </summary>
public class QuestManager  {

    #region   单例
    private static QuestManager instance;
    
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new QuestManager();
            }
            return instance;
        }
    }
    #endregion

    private List<QuestItem> allQuestList;//存储所有任务的实体类的集合
    private List<QuestItem> acceptedQuestList;//玩家已接受的任务的实体类的集合

    public List<QuestItem> AllQuestList { get { return allQuestList; } }

    public List<QuestItem> AcceptedQuestList { get { return acceptedQuestList; } }

    private QuestManager()
    {       
        
    }

    public void LoadQuestData()
    {
        allQuestList = GetAllQuestItemList();
        acceptedQuestList = GetAcceptedQuestItemList();
    }

    private List<QuestItem> GetAllQuestItemList()
    {
        return JsonTools.GetJsonList<QuestItem>("QuestData");
    }

    private List<QuestItem> GetAcceptedQuestItemList()
    {
        List<QuestItem> temp = new List<QuestItem>();
        foreach (var item in allQuestList)
        {
            //如果任务已接受并且未提交
            if (item.QuestAccept && !item.QuestSubmit)
                temp.Add(item);
        }
        return temp;
    }

    public QuestItem GetQuestItemById(int id)
    {
        for (int i = 0; i < allQuestList.Count; i++)
        {
            if (allQuestList[i].Id == id)
            {
                return allQuestList[i];
            }
        }
        return null;
    }
}
