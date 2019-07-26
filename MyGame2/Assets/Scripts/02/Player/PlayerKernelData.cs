using System.Collections.Generic;

/// <summary>
/// 玩家核心数据类，用来存储玩家的核心信息
/// </summary>
public class PlayerKernelData  {

    //更新角色属性UI的委托变量
    public static event GlobalParamters.del_UpdatePlayerInfoUI eventUpdatePlayerInfo;

    private int id;                 //编号 
    private string name;            //名称
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

    public PlayerKernelData( int id , string name , string image , int hp, int mp, int attack, int defense, int speed, int level, List<int> skills, int[] equips, int hpByEquip, int mpByEquip, int attackByEquip, int defenseByEquip, int speedByEquip)
    {
        this.id = id;
        this.name = name;
        this.image = image;
        this.hp = hp;
        this.mp = mp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.level = level;
        this.skills = skills;
        this.equips = equips;
        this.hpByEquip = hpByEquip;
        this.mpByEquip = mpByEquip;
        this.attackByEquip = attackByEquip;
        this.defenseByEquip = defenseByEquip;
        this.speedByEquip = speedByEquip;
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
            //更新UI，UI显示的是角色本身属性值加上装备的增加的属性值
            eventUpdatePlayerInfo("Hp", Hp + HpByEquip);
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
            eventUpdatePlayerInfo("Mp", Mp + MpByEquip);
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
            eventUpdatePlayerInfo("Attack", Attack + AttackByEquip);
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
            eventUpdatePlayerInfo("Defense", Defense + DefenseByEquip);
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
            eventUpdatePlayerInfo("Speed", Speed + SpeedByEquip);
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
            eventUpdatePlayerInfo("Hp", Hp + HpByEquip);
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
            eventUpdatePlayerInfo("Mp", Mp + MpByEquip);
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
            eventUpdatePlayerInfo("Attack", Attack + AttackByEquip);
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
            eventUpdatePlayerInfo("Defense", Defense + DefenseByEquip);
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
            eventUpdatePlayerInfo("Speed", Speed + SpeedByEquip);
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
}
