using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 根据id获取玩家角色或敌人的模型预制体
/// </summary>
public class RolePrefabDic {

    private Dictionary<int, GameObject> enemyPrefabDic = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> playerPrefabDic = new Dictionary<int, GameObject>();

    private static RolePrefabDic instance;

    public static RolePrefabDic Instance
    {
        get{
            if (instance == null)
            {
                instance = new RolePrefabDic();
            }
            return instance;
        }      
    }

    private RolePrefabDic()
    {
        LoadEenmyPrefabs();
        LoadPlayerPrefabs();
    }

    private void LoadEenmyPrefabs()
    {
        GameObject enemy1 = Resources.Load<GameObject>("BattleSceneRolePrefab/Enemys/Enemy1");
        enemyPrefabDic.Add(1, enemy1);
        GameObject enemy2 = Resources.Load<GameObject>("BattleSceneRolePrefab/Enemys/Enemy2");
        enemyPrefabDic.Add(2, enemy2);
    }

    private void LoadPlayerPrefabs()
    {
        GameObject player1 = Resources.Load<GameObject>("BattleSceneRolePrefab/Players/Player1");
        playerPrefabDic.Add(0, player1);
        GameObject player2 = Resources.Load<GameObject>("BattleSceneRolePrefab/Players/Player2");
        playerPrefabDic.Add(1, player2);
        GameObject player3 = Resources.Load<GameObject>("BattleSceneRolePrefab/Players/Player3");
        playerPrefabDic.Add(2, player3);
    }

    public GameObject GetEnemyPrefabById(int enemyId)
    {
        GameObject temp = null;
        enemyPrefabDic.TryGetValue(enemyId, out temp);
        return temp;
    }

    public GameObject GetPlayerPrefabById(int playerId)
    {
        GameObject temp = null;
        playerPrefabDic.TryGetValue(playerId, out temp);
        return temp;
    }
}
