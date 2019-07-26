using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家信息实体类
/// </summary>
public class PlayerItem  {

    private int playerId;           //编号 
    private string playerName;      //名称
    private string image;           //角色图片

    private int hp;                 //生命值
    private int mp;                 //魔法值
    private int attack;             //攻击力
    private int defense;            //防御力
    private int speed;              //速度

    private int level;              //角色等级

    private List<int> skills;        //当前装备的技能 

    private int[] equips;           //当前穿戴的装备
    private int hpByEquip;          //装备血量
    private int mpByEquip;          //装备蓝量
    private int attackByEquip;      //装备攻击力
    private int defenseByEquip;     //装备防御力
    private int speedByEquip;       //装备速度

    public PlayerItem() { }

    public void SetInfo(PlayerKernelDataProxy player)
    {
        this.hp = player.Hp;
        this.mp = player.Mp;
        this.attack = player.Attack;
        this.defense = player.Defense;
        this.speed = player.Speed;
        this.level = player.Level;
        this.skills = player.Skills;
        this.equips = player.Equips;
        this.hpByEquip = player.HpByEquip;
        this.mpByEquip = player.MpByEquip;
        this.attackByEquip = player.AttackByEquip;
        this.defenseByEquip = player.DefenseByEquip;
        this.speedByEquip = player.SpeedByEquip;
    }

    public int PlayerId
    {
        get
        {
            return playerId;
        }

        set
        {
            playerId = value;
        }
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public string Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
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

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public List<int> Skills
    {
        get
        {
            return skills;
        }

        set
        {
            skills = value;
        }
    }

    public int[] Equips
    {
        get
        {
            return equips;
        }

        set
        {
            equips = value;
        }
    }

    public int HpByEquip
    {
        get
        {
            return hpByEquip;
        }

        set
        {
            hpByEquip = value;
        }
    }

    public int MpByEquip
    {
        get
        {
            return mpByEquip;
        }

        set
        {
            mpByEquip = value;
        }
    }

    public int AttackByEquip
    {
        get
        {
            return attackByEquip;
        }

        set
        {
            attackByEquip = value;
        }
    }

    public int DefenseByEquip
    {
        get
        {
            return defenseByEquip;
        }

        set
        {
            defenseByEquip = value;
        }
    }

    public int SpeedByEquip
    {
        get
        {
            return speedByEquip;
        }

        set
        {
            speedByEquip = value;
        }
    }
}
