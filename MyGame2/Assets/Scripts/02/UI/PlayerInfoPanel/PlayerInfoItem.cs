using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色信息实体类
/// </summary>
public class PlayerInfoItem  {

    private int playerID;
    private string playerName;
    private float hp;
    private float attack;
    private float defense;
    private float speed;
    private int[] skill;
    private string image;

    public PlayerInfoItem() { }

    public PlayerInfoItem(int playerID, string playerName, float hp, float attack, float defense, float speed, int[] skill, string image)
    {
        this.playerID = playerID;
        this.playerName = playerName;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.skill = skill;
        this.image = image;
    }

    public override string ToString()
    {
        return "playerName:" + this.playerName + " skill1:" + this.skill[0] + " skill2:" + this.skill[1] + " skill3:" + this.skill[2];
    }

    public int PlayerID
    {
        get { return playerID; }
        set
        {
            playerID = value;
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

    public float Hp
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

    public float Attack
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

    public float Defense
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

    public float Speed
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

    public int[] Skill
    {
        get
        {
            return skill;
        }

        set
        {
            skill = value;
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

    
}
