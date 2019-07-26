using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : RoleBase {

    [SerializeField]
    private int enemyId;

    public void EnemyAct()
    {
        Debug.Log(gameObject.name + "使用了技能1");
        Debug.Log("名称：砍击");
        m_Anim.SetTrigger("attack");
        AttackTarget.GetComponent<RoleBase>().TakeDamage(attack);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (curHp == 0)
        {
            CheckQuestRequest();
            BattleManager.Instance.UpdateEnemyList(gameObject);
            BattleManager.Instance.UpdateCurAtkTarget();
        }
    }

    /// <summary>
    /// 检测已接受任务中是否有击杀该怪物的要求
    /// </summary>
    private void CheckQuestRequest()
    {
        foreach(QuestItem quest in QuestManager.Instance.AcceptedQuestList)
        {
            foreach(QuestItem.QuestEnemy enemy in quest.QuestKillEnemy)
            {
                //有击杀该敌人的任务，击杀数加1
                if(enemy.EnemyId == this.enemyId)
                {
                    if(enemy.CurEnemyNum < enemy.EnemyNum)
                    {
                        enemy.CurEnemyNum++;
                    }
                }
            }
        }
    }

}
