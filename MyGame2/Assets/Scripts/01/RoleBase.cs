using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 所有角色的共同父类
/// </summary>
public abstract class RoleBase : MonoBehaviour {

    public float curHp;
    public float attack;
    public float defense;
    public float speed;

    public float maxHp;

    private GameObject attackTarget;         //攻击目标

    protected Slider m_BloodSlider;         //血条UI

    protected Animator m_Anim;

    public GameObject AttackTarget { get { return attackTarget; } set { attackTarget = value; } }

    protected virtual void Start()
    {
        m_Anim = gameObject.GetComponent<Animator>();
        m_BloodSlider = transform.Find("BloodSlider").GetComponent<Slider>();

        UpdateBloodUI();
    }


    /// <summary>
    /// 受到伤害
    /// </summary>
    public virtual void TakeDamage( float damage)
    {
        curHp -= damage;
        if (damage > 0)
        {
            m_Anim.SetTrigger("hit");
        }
        if( curHp <= 0)
        {
            curHp = 0;
            m_Anim.SetTrigger("die");
        }
        if( curHp > maxHp)
        {
            curHp = maxHp;
        }
        UpdateBloodUI();
    }

    protected void UpdateBloodUI()
    {
        m_BloodSlider.value = curHp / maxHp;
    }

}
