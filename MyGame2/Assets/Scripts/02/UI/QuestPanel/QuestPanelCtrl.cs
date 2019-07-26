using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanelCtrl : MonoBehaviour {

    public static QuestPanelCtrl Instance;

    private QuestPanelModel m_QuestPanelModel;
    private QuestPanelView m_QuestPanelView;

    private List<QuestItem> acceptQuestList;    //当前已接受的任务的集合
    private List<GameObject> questList;//存储所有任务物体的集合

    public List<QuestItem> AcceptQuestList { get { return acceptQuestList; } }

    void Awake()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        m_QuestPanelModel = gameObject.GetComponent<QuestPanelModel>();
        m_QuestPanelView = gameObject.GetComponent<QuestPanelView>();

        questList = new List<GameObject>();
    }

    public void ReShow()
    {
        ResetQuests();
    }

    void Start()
    {
        acceptQuestList = m_QuestPanelModel.AcceptedQuestList;
        ResetQuests();
    }

    /// <summary>
    /// 生成所有已接受过的任务
    /// </summary>
    private void CreateAllQuests()
    {
        foreach (var item in acceptQuestList)
        {
            GameObject temp = GameObject.Instantiate(m_QuestPanelView.Prefab_QuestItem, m_QuestPanelView.GridOfQuest_Transform);
            temp.GetComponent<QuestItemCtrl>().QuestItem = item;
            questList.Add(temp);
        }
    }

    /// <summary>
    /// 显示右侧任务具体信息
    /// </summary>
    private void SetQuestInfo( QuestItem quest )
    {
        m_QuestPanelView.M_QuestInfoAreaCtrl.QuestItem = quest;
    }

    private void ResetQuests()
    {
        ClearCurQuests();

        if (acceptQuestList.Count > 0)
        {
            m_QuestPanelView.QuestInfoArea.SetActive(true);
            CreateAllQuests();//生成所有已接受任务
            SetQuestInfo(questList[0].GetComponent<QuestItemCtrl>().QuestItem);//默认显示第一个任务的详细信息
        }
        else
        {
            m_QuestPanelView.QuestInfoArea.SetActive(false);
        }
    }

    private void ClearCurQuests()
    {
        for(int i = 0; i < questList.Count; i++)
        {
            GameObject.Destroy(questList[i]);
        }
        questList.Clear();
    }

    public void AddAcceptQuest(QuestItem quest)
    {
        acceptQuestList.Add(quest);
    }

    public void RemoveAcceptQuest(QuestItem quest)
    {
        acceptQuestList.Remove(quest);
    }

    public QuestItem GetQuestItemById(int id)
    {
        return QuestManager.Instance.GetQuestItemById(id);
    }
}
