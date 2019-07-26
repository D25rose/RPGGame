using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialogueTootip : MonoBehaviour {

    private QuestItem m_QuestItem;

    private GameObject me;  //玩家标识
    private GameObject npc; //npc标识
    private Text npcName;   
    private Text talkContent;   //当前对话内容
    private Button nextBtn;     //下一句按钮
    private Button acceptBtn;   //接受任务按钮
    private Button abandonBtn;  //放弃接受任务按钮
    private Button finishBtn;   //完成对话按钮

    private int playerTalkIndex = 0;
    private int npcTalkIndex = 0;
    private bool isNpcTalk = true;  //是否轮到npc说话

    private bool isSubmitQuest = false; //是否要提交任务
    private QuestItem submitQuest;  //要提交的任务

    public QuestItem QuestItem
    {
        get { return m_QuestItem; }
        set {
            m_QuestItem = value;
            InitQuset();  
        }
    }

    void Awake ()
    {
        me = transform.Find("me").gameObject;
        npc = transform.Find("npc").gameObject;
        npcName = npc.transform.Find("Text").GetComponent<Text>();
        talkContent = transform.Find("talkContent").GetComponent<Text>();
        nextBtn = transform.Find("nextBtn").GetComponent<Button>();
        acceptBtn = transform.Find("acceptBtn").GetComponent<Button>();
        abandonBtn = transform.Find("abandonBtn").GetComponent<Button>();
        finishBtn = transform.Find("finishBtn").GetComponent<Button>();

        nextBtn.onClick.AddListener(OnNextBtn);
        acceptBtn.onClick.AddListener(OnAcceptBtn);
        abandonBtn.onClick.AddListener(OnAbandonBtn);
        finishBtn.onClick.AddListener(OnFinishBtn);
    }

    private void InitQuset()
    {
        //当前任务没被接受
        if (!m_QuestItem.QuestAccept)
        {
            InitUI();
            //npc对话只有一句
            if(m_QuestItem.QuestDialogueNpc.Length == 1)
            {
                acceptBtn.gameObject.SetActive(true);
                abandonBtn.gameObject.SetActive(true);
                nextBtn.gameObject.SetActive(false);
            }
            else
            {
                npcTalkIndex++;
                nextBtn.gameObject.SetActive(true);
                isNpcTalk = false;
            }
        }
        else
        {
            me.SetActive(false);
            npc.SetActive(true);
            npcName.text = m_QuestItem.ReleaseNpc;
            talkContent.text = m_QuestItem.UnFinished;
            acceptBtn.gameObject.SetActive(false);
            abandonBtn.gameObject.SetActive(false);
            nextBtn.gameObject.SetActive(false);
            finishBtn.gameObject.SetActive(true);
        }
    }

    private void InitUI()
    {
        playerTalkIndex = 0;
        npcTalkIndex = 0;
        me.SetActive(false);
        npc.SetActive(true);
        npcName.text = m_QuestItem.ReleaseNpc;
        talkContent.text = m_QuestItem.QuestDialogueNpc[0];
        acceptBtn.gameObject.SetActive(false);
        abandonBtn.gameObject.SetActive(false);
        finishBtn.gameObject.SetActive(false);
    }

    private void OnNextBtn()
    {
        //轮到玩家说话
        if (!isNpcTalk)
        {
            if(m_QuestItem.QuestDialoguePlayer.Length > 0)
            {
                talkContent.text = m_QuestItem.QuestDialoguePlayer[playerTalkIndex];
                playerTalkIndex++;
                me.SetActive(true);
                npc.SetActive(false);
                isNpcTalk = true;
            }
        }
        else
        {
            talkContent.text = m_QuestItem.QuestDialogueNpc[npcTalkIndex];
            npcTalkIndex++;
            me.SetActive(false);
            npc.SetActive(true);
            isNpcTalk = false;
            //如果npc最后一句话说完了
            if(npcTalkIndex == m_QuestItem.QuestDialogueNpc.Length)
            {
                acceptBtn.gameObject.SetActive(true);
                abandonBtn.gameObject.SetActive(true);
                nextBtn.gameObject.SetActive(false);
            }
        }
    }

    private void OnAcceptBtn()
    {
        m_QuestItem.QuestAccept = true;
        QuestPanelCtrl.Instance.AddAcceptQuest(m_QuestItem);

        TootipPanelManager.Instance.HideQuestDialogueTootip();
        TootipPanelManager.Instance.ShowWarningTootip("任务已接受");
    }

    private void OnAbandonBtn()
    {
        TootipPanelManager.Instance.HideQuestDialogueTootip();
    }

    private void OnFinishBtn()
    {
        TootipPanelManager.Instance.HideQuestDialogueTootip();
        if (isSubmitQuest)
        {
            SubmitQuest(submitQuest);
            isSubmitQuest = false;
        }
    }

    /// <summary>
    /// 和任务中要求的NPC对话，只有一句
    /// </summary>
    public void TalkWithQuestRequireNPC(QuestItem.QuestNPC npc)
    {
        acceptBtn.gameObject.SetActive(false);
        abandonBtn.gameObject.SetActive(false);
        finishBtn.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(false);

        talkContent.text = npc.QuestDialogueNpc;
        me.SetActive(false);
        this.npc.SetActive(true);
        npcName.text = "id:" + npc.NpcId;
    }

    /// <summary>
    /// 和任务的提交者对话，只有一句
    /// </summary>
    public void TalkWithQuestOverNPC(QuestItem quest)
    {
        acceptBtn.gameObject.SetActive(false);
        abandonBtn.gameObject.SetActive(false);
        finishBtn.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(false);

        talkContent.text = quest.Finished;
        me.SetActive(false);
        this.npc.SetActive(true);
        npcName.text = "id:" + quest.OverNpc;

        isSubmitQuest = true;
        submitQuest = quest;
    }

    /// <summary>
    /// 提交任务
    /// </summary>
    private void SubmitQuest(QuestItem quest)
    {
        quest.QuestSubmit = true;

        //发放任务奖励
        string temp = "获得奖励. ";   //奖励文字说明
        GlobalPlayerData.Instance.AddGold(quest.QuestRewardItem.Gold);
        temp += "金钱：x" + quest.QuestRewardItem.Gold + "\n";
        foreach (QuestItem.Quest_Item item in quest.QuestRewardItem.RewardItem)
        {
            for (int i = 0; i < item.ItemNum; i++)
            {
                InventoryPanelCtrl.Instance.AddItem(item.ItemId);
            }
            temp += GlobalInventoryItemManager.Instance.GetItemNameById(item.ItemId) + " x" + item.ItemNum + "\n";
        }

        //将该任务从已接受任务列表中移除
        QuestPanelCtrl.Instance.RemoveAcceptQuest(quest);

        TootipPanelManager.Instance.ShowWarningTootip(temp);
    }
}
