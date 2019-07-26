using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanelModel : MonoBehaviour {

    //private List<QuestItem> allQuestList;//存储所有任务的实体类的集合
    private List<QuestItem> acceptedQuestList;//玩家已接受的任务的实体类的集合

    public List<QuestItem> AcceptedQuestList { get { return acceptedQuestList; } }

    void Awake()
    {
        //allQuestList = QuestManager.Instance.AllQuestList;
        acceptedQuestList = QuestManager.Instance.AcceptedQuestList;
    }

}
