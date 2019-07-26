using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : SkillBase {

    public override void SkillContent()
    {
        owner.GetComponent<Animator>().SetTrigger("attack");
        attackTarget.GetComponent<RoleBase>().TakeDamage(attack);
    }
}
