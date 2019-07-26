using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanelView : MonoBehaviour {

    private string path = "UI/QuestPanel/";

    private Transform gridOfQuest_Transform;//所有显示任务物体的Gird

    private GameObject prefab_QuestItem;//任务物体预制体

    private GameObject questInfoArea;   //任务详细信息显示区域

    private QuestInfoAreaCtrl m_QuestInfoAreaCtrl;//任务面板右侧信息显示即按钮事件控制

    public Transform GridOfQuest_Transform { get { return gridOfQuest_Transform; } }

    public GameObject Prefab_QuestItem { get { return prefab_QuestItem; } }

    public GameObject QuestInfoArea { get { return questInfoArea; } }

    public QuestInfoAreaCtrl M_QuestInfoAreaCtrl { get { return m_QuestInfoAreaCtrl; } }

    void Awake()
    {
        gridOfQuest_Transform = transform.Find("QuestListArea/content/Grid");

        prefab_QuestItem = Resources.Load<GameObject>(path + "QuestItem");

        questInfoArea = transform.Find("QuestInfoArea").gameObject;

        m_QuestInfoAreaCtrl = questInfoArea.GetComponent<QuestInfoAreaCtrl>();
    }

}
