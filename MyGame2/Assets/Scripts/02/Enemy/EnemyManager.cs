using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人管理器
/// </summary>
public class EnemyManager {

    private static EnemyManager instance;

    public static EnemyManager Instance()
    {
        if(instance == null)
        {
            instance = new EnemyManager();
        }
        return instance;
    }

    private List<EnemyItem> enemyList;

    private EnemyManager()
    {
        enemyList = JsonTools.GetJsonList<EnemyItem>("EnemyData");
    }
	
    public EnemyItem GetEnemyById(int enemyId)
    {
        foreach(EnemyItem enemy in enemyList)
        {
            if(enemy.Id == enemyId)
            {
                return enemy;
            }
        }
        return null;
    }

}
