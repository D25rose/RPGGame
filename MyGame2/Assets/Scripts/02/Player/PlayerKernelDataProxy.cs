using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家核心数据类的代理类
/// </summary>
public class PlayerKernelDataProxy : PlayerKernelData {


	public PlayerKernelDataProxy( int id , string name , string image , int hp, int mp, int attack, int defense, int speed, int level, List<int> skills, int[] equips, int hpByEquip, int mpByEquip, int attackByEquip, int defenseByEquip, int speedByEquip)
        : base( id , name , image , hp, mp, attack, defense, speed, level, skills, equips, hpByEquip, mpByEquip, attackByEquip, defenseByEquip, speedByEquip)
    {
    }

    public int TotalHp { get { return Hp + HpByEquip; } }
    public int TotalMp { get { return Mp + MpByEquip; } }
    public int TotalAttack { get { return Attack + AttackByEquip; } }
    public int TotalDefense { get { return Defense + DefenseByEquip; } }
    public int TotalSpeed { get { return Speed + SpeedByEquip; } }

    #region 生命值
    /// <summary>
    /// 增加生命值
    /// </summary>
    public void IncreaseHp( int value)
    {
        base.Hp += value;
    }

    /// <summary>
    /// 减少生命值
    /// </summary>
    public void DecreaseHp(int value)
    {
        base.Hp -= value;
        if(base.Hp <= 0)
        {
            base.Hp = 1;
        }
    }
    #endregion

    #region 魔法值
    /// <summary>
    /// 增加魔法值
    /// </summary>
    public void IncreaseMp(int value)
    {
        base.Mp += value;
    }

    /// <summary>
    /// 减少魔法值
    /// </summary>
    public void DecreaseMp(int value)
    {
        base.Mp -= value;
        if (base.Mp <= 0)
        {
            base.Mp = 1;
        }
    }
    #endregion

    #region 攻击力
    /// <summary>
    /// 增加攻击力
    /// </summary>
    public void IncreaseAttack(int value)
    {
        base.Attack += value;
    }

    /// <summary>
    /// 减少攻击力
    /// </summary>
    public void DecreaseAttack(int value)
    {
        base.Attack -= value;
        if (base.Attack <= 0)
        {
            base.Attack = 1;
        }
    }
    #endregion

    #region 防御力
    /// <summary>
    /// 增加防御力
    /// </summary>
    public void IncreaseDefense(int value)
    {
        base.Defense += value;
    }

    /// <summary>
    /// 减少防御力
    /// </summary>
    public void DecreaseDefense(int value)
    {
        base.Defense -= value;
        if (base.Defense <= 0)
        {
            base.Defense = 1;
        }
    }
    #endregion

    #region 速度
    /// <summary>
    /// 增加速度
    /// </summary>
    public void IncreaseSpeed(int value)
    {
        base.Speed += value;
    }

    /// <summary>
    /// 减少速度
    /// </summary>
    public void DecreaseSpeed(int value)
    {
        base.Speed -= value;
        if (base.Speed <= 0)
        {
            base.Speed = 1;
        }
    }
    #endregion

    #region 装备生命值
    /// <summary>
    /// 增加装备生命值
    /// </summary>
    public void IncreaseHpByEquip(int value)
    {
        base.HpByEquip += value;
    }

    /// <summary>
    /// 减少装备生命值
    /// </summary>
    public void DecreaseHpByEquip(int value)
    {
        base.HpByEquip -= value;
        if (base.HpByEquip < 0)
        {
            base.HpByEquip = 0;
        }
    }
    #endregion

    #region 装备魔法值
    /// <summary>
    /// 增加装备魔法值
    /// </summary>
    public void IncreaseMpByEquip(int value)
    {
        base.MpByEquip += value;
    }

    /// <summary>
    /// 减少装备魔法值
    /// </summary>
    public void DecreaseMpByEquip(int value)
    {
        base.MpByEquip -= value;
        if (base.MpByEquip < 0)
        {
            base.MpByEquip = 0;
        }
    }
    #endregion

    #region 装备攻击力
    /// <summary>
    /// 增加装备攻击力
    /// </summary>
    public void IncreaseAttackByEquip(int value)
    {
        base.AttackByEquip += value;
    }

    /// <summary>
    /// 减少装备攻击力
    /// </summary>
    public void DecreaseAttackByEquip(int value)
    {
        base.AttackByEquip -= value;
        if (base.AttackByEquip < 0)
        {
            base.AttackByEquip = 0;
        }
    }
    #endregion

    #region 装备防御力
    /// <summary>
    /// 增加装备防御力
    /// </summary>
    public void IncreaseDefneseByEquip(int value)
    {
        base.DefenseByEquip += value;
    }

    /// <summary>
    /// 减少装备防御力
    /// </summary>
    public void DecreaseDefenseByEquip(int value)
    {
        base.DefenseByEquip -= value;
        if (base.DefenseByEquip < 0)
        {
            base.DefenseByEquip = 0;
        }
    }
    #endregion

    #region 装备速度
    /// <summary>
    /// 增加装备速度
    /// </summary>
    public void IncreaseSpeedByEquip(int value)
    {
        base.SpeedByEquip += value;
    }

    /// <summary>
    /// 减少装备速度
    /// </summary>
    public void DecreaseSpeedByEquip(int value)
    {
        base.SpeedByEquip -= value;
        if (base.SpeedByEquip < 0)
        {
            base.SpeedByEquip = 0;
        }
    }
    #endregion
}
