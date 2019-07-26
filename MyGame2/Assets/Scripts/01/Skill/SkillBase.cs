using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour {

    public int id;
    public string skillName;
    public string skillDescr;

    public float attack;

    protected GameObject owner;             //技能持有者
    protected GameObject attackTarget;


    public void SetOwner( GameObject role )
    {
        owner = role;
    }

    public void SetAttackTarget( GameObject role )
    {
        this.attackTarget = role;
    }

    //public abstract void Init();

    /// <summary>
    /// 技能效果
    /// </summary>
    public abstract void SkillContent();

}
