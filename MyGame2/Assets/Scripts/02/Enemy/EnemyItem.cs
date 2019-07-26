using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敌人信息实体类
/// </summary>
public class EnemyItem {

    private int id;
    private string name;
    private int hp;
    private int mp;
    private int attack;
    private int defense;
    private int speed;
    private Enemy[] battleEnemys;   //在战斗场景中出现的敌人配置
    private EnemyReward enemyRewards;   //击败敌人的奖励物品

    public EnemyItem() { }

    public class Enemy
    {
        private int enemyId;
        private int enemyNum;

        public int EnemyId { get { return enemyId; } set { enemyId = value; } }
        public int EnemyNum { get { return enemyNum; } set { enemyNum = value; } }
    }

    public class RewardItem
    {
        private int itemId;
        private int itemNum;

        public int ItemId { get { return itemId; } set { itemId = value; } }
        public int ItemNum { get { return itemNum; } set { itemNum = value; } }
    }

    public class EnemyReward
    {
        private int gold;
        private RewardItem[] rewardItems;

        public int Gold { get { return gold; } set { gold = value; } }
        public RewardItem[] RewardItems { get { return rewardItems; } set { rewardItems = value; } }
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

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Mp
    {
        get
        {
            return mp;
        }

        set
        {
            mp = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public Enemy[] BattleEnemys
    {
        get
        {
            return battleEnemys;
        }

        set
        {
            battleEnemys = value;
        }
    }

    public EnemyReward EnemyRewards
    {
        get
        {
            return enemyRewards;
        }

        set
        {
            enemyRewards = value;
        }
    }
}
