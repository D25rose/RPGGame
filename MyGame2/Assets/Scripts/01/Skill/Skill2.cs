using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 给自身恢复生命值
/// </summary>
public class Skill2 : SkillBase {

    public override void SkillContent()
    {
        owner.GetComponent<Animator>().SetTrigger("attack");
        owner.GetComponent<RoleBase>().TakeDamage(-attack);
    }
}
