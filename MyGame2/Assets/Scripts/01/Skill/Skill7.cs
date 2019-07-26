using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill7 : SkillBase {

    public override void SkillContent()
    {
        owner.GetComponent<Animator>().SetTrigger("attack");
        attackTarget.GetComponent<RoleBase>().TakeDamage(attack);
    }
}
