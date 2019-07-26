using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : RoleBase {

    public SkillBase[] skills = new SkillBase[4];

    /// <summary>
    /// 设置角色各项属性值
    /// </summary>
    public void SetPlayerProPerty(PlayerKernelDataProxy player)
    {
        curHp = player.TotalHp;
        maxHp = curHp;
        attack = player.TotalAttack;
        defense = player.TotalDefense;
        speed = player.TotalSpeed;
        
        //设置技能
        for(int i = 0; i < player.Skills.Count; i++)
        {
            skills[i] = SkillPrefabDic.Instance.GetSkillPrefabById(player.Skills[i]).GetComponent<SkillBase>();
        }
    }

    /// <summary>
    /// 设置技能持有者
    /// </summary>
    public void SetSkillOwner()
    {
        foreach(SkillBase skill in skills)
        {
            if(skill != null)
            {
                skill.SetOwner(gameObject);
            }
        }
    }

    /// <summary>
    /// 技能1
    /// </summary>
    public virtual void UseSkill1()
    {
        Debug.Log(gameObject.name + "使用了技能1");
        skills[0].SetAttackTarget(AttackTarget);
        skills[0].SkillContent();

        BattleManager.Instance.UpdateUnActPlayers();
    }

    /// <summary>
    /// 技能2
    /// </summary>
    public virtual void UseSkill2()
    {
        Debug.Log(gameObject.name + "使用了技能2");
        skills[1].SetAttackTarget(AttackTarget);
        skills[1].SkillContent();

        BattleManager.Instance.UpdateUnActPlayers();
    }

    /// <summary>
    /// 技能3
    /// </summary>
    public virtual void UseSkill3()
    {
        Debug.Log(gameObject.name + "使用了技能3");
        skills[2].SetAttackTarget(AttackTarget);
        skills[2].SkillContent();

        BattleManager.Instance.UpdateUnActPlayers();
    }

    /// <summary>
    /// 技能4
    /// </summary>
    public virtual void UseSkill4()
    {
        Debug.Log(gameObject.name + "使用了技能4");
        skills[3].SetAttackTarget(AttackTarget);
        skills[3].SkillContent();

        BattleManager.Instance.UpdateUnActPlayers();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if( curHp == 0)
        {
            BattleManager.Instance.UpdatePlayerList(gameObject);
        }
    }

}
