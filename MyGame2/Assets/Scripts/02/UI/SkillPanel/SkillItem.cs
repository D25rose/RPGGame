using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能信息实体类
/// </summary>
public class SkillItem  {

    private int skillID;
    private string skillName;
    private string skillDescr;
    private string image;
    private double attack;
    private int mpConsume;
    private int learnLevel;
    private bool isEquip;
    private bool isLearn;

    public SkillItem() { }

    public SkillItem(int skillID, string skillName, string skillDescr, string image, float attack, int mpConsume, int learnLevel, bool isEquip, bool isLearn)
    {
        this.skillID = skillID;
        this.skillName = skillName;
        this.skillDescr = skillDescr;
        this.image = image;
        this.attack = attack;
        this.mpConsume = mpConsume;
        this.learnLevel = learnLevel;
        this.isEquip = isEquip;
        this.isLearn = isLearn;
    }

    public override string ToString()
    {
        return "skillName:" + SkillName + " skillID:" + skillID + " isLearn:" + isLearn;
    }

    public int SkillID
    {
        get
        {
            return skillID;
        }

        set
        {
            skillID = value;
        }
    }

    public string SkillName
    {
        get
        {
            return skillName;
        }

        set
        {
            skillName = value;
        }
    }

    public string SkillDescr
    {
        get
        {
            return skillDescr;
        }

        set
        {
            skillDescr = value;
        }
    }

    public double Attack
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

    public int MpConsume
    {
        get
        {
            return mpConsume;
        }

        set
        {
            mpConsume = value;
        }
    }

    public int LearnLevel
    {
        get
        {
            return learnLevel;
        }

        set
        {
            learnLevel = value;
        }
    }

    public bool IsLearn
    {
        get
        {
            return isLearn;
        }

        set
        {
            isLearn = value;
        }
    }

    public bool IsEquip
    {
        get
        {
            return isEquip;
        }

        set
        {
            isEquip = value;
        }
    }
}
