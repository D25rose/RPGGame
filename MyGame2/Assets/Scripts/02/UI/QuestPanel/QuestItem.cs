using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务信息实体类
/// </summary>
public class QuestItem {

    private int id;//任务id
    private string releaseNpc;//发布任务的Npc
    private int overNpc;//提交任务的Npc的id
    private string questName;//任务名称
    private string questDescr;//任务描述
    private string[] questDialogueNpc;//Npc的任务对话
    private string[] questDialoguePlayer;//玩家的任务对话
    private string unFinished;//任务未完成的对话
    private string finished;//任务完成的对话
    private QuestNPC[] questTalkNpc;//任务需要对话的NPC
    private bool questAccept;//任务接受状态
    private bool questState;//任务完成状态
    private bool questSubmit;//任务提交状态
    private QuestEnemy[] questKillEnemy;//任务需要击杀的敌人
    private Quest_Item[] questNeedItem;//任务完成需要的物品
    private QuestReward questRewardItem;//任务奖励

    //需要对话的NPC
    public class QuestNPC
    {
        private int npcId;
        private bool isTalk;//是否已谈过话
        private string questDialogueNpc;//任务对话

        public int NpcId { get { return npcId; } set { npcId = value; } }
        public bool IsTalk { get { return isTalk; } set { isTalk = value; } }
        public string QuestDialogueNpc { get { return questDialogueNpc; } set { questDialogueNpc = value; } }
    }

    //需要击杀的敌人
    public class QuestEnemy
    {
        private int enemyId;//击杀的怪物的id
        private int enemyNum;//要击杀的数目
        private int curEnemyNum;//当前击杀数目

        public int EnemyId { get { return enemyId; } set { enemyId = value; } }
        public int EnemyNum { get { return enemyNum; } set { enemyNum = value; } }
        public int CurEnemyNum { get { return curEnemyNum; } set { curEnemyNum = value; } }
    }

    //任务物品（任务需要或者任务奖励）
    public class Quest_Item
    {
        private int itemId;//物品id
        private int itemNum;//物品数量

        public int ItemId { get { return itemId; } set { itemId = value; } }
        public int ItemNum { get { return itemNum; } set { itemNum = value; } }
    }

    //任务奖励
    public class QuestReward
    {
        private int gold;//任务奖励金钱数
        private Quest_Item[] rewardItem;//任务奖励物品

        public int Gold { get { return gold; } set { gold = value; } }
        public Quest_Item[] RewardItem { get { return rewardItem; } set { rewardItem = value; } }
    }

    public QuestItem() { }

    public QuestItem(int id, string releaseNpc, int overNpc, string questName, string questDescr, string[] questDialogueNpc, string[] questDialoguePlayer, string unFinished, string finished,QuestNPC[] questTalkNpc, bool questAccept, bool questState, bool questSubmit, QuestEnemy[] questKillEnemy, Quest_Item[] questNeedItem, QuestReward questRewardItem)
    {
        this.id = id;
        this.releaseNpc = releaseNpc;
        this.overNpc = overNpc;
        this.questName = questName;
        this.questDescr = questDescr;
        this.questDialogueNpc = questDialogueNpc;
        this.questDialoguePlayer = questDialoguePlayer;
        this.unFinished = unFinished;
        this.finished = finished;
        this.questTalkNpc = questTalkNpc;
        this.questAccept = questAccept;
        this.questState = questState;
        this.questSubmit = questSubmit;
        this.questKillEnemy = questKillEnemy;
        this.questNeedItem = questNeedItem;
        this.questRewardItem = questRewardItem;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string ReleaseNpc
    {
        get
        {
            return releaseNpc;
        }

        set
        {
            releaseNpc = value;
        }
    }

    public int OverNpc
    {
        get
        {
            return overNpc;
        }

        set
        {
            overNpc = value;
        }
    }

    public string QuestName
    {
        get
        {
            return questName;
        }

        set
        {
            questName = value;
        }
    }

    public string QuestDescr
    {
        get
        {
            return questDescr;
        }

        set
        {
            questDescr = value;
        }
    }

    public string[] QuestDialogueNpc
    {
        get
        {
            return questDialogueNpc;
        }

        set
        {
            questDialogueNpc = value;
        }
    }

    public string[] QuestDialoguePlayer
    {
        get
        {
            return questDialoguePlayer;
        }

        set
        {
            questDialoguePlayer = value;
        }
    }

    public string UnFinished
    {
        get
        {
            return unFinished;
        }

        set
        {
            unFinished = value;
        }
    }

    public string Finished
    {
        get
        {
            return finished;
        }

        set
        {
            finished = value;
        }
    }

    public QuestNPC[] QuestTalkNpc
    {
        get
        {
            return questTalkNpc;
        }

        set
        {
            questTalkNpc = value;
        }
    }

    public bool QuestAccept
    {
        get
        {
            return questAccept;
        }

        set
        {
            questAccept = value;
        }
    }

    public bool QuestState
    {
        get
        {
            return questState;
        }

        set
        {
            questState = value;
        }
    }

    public bool QuestSubmit
    {
        get
        {
            return questSubmit;
        }

        set
        {
            questSubmit = value;
        }
    }

    public QuestEnemy[] QuestKillEnemy
    {
        get
        {
            return questKillEnemy;
        }

        set
        {
            questKillEnemy = value;
        }
    }

    public Quest_Item[] QuestNeedItem
    {
        get
        {
            return questNeedItem;
        }

        set
        {
            questNeedItem = value;
        }
    }

    public QuestReward QuestRewardItem
    {
        get
        {
            return questRewardItem;
        }

        set
        {
            questRewardItem = value;
        }
    }


    
}
