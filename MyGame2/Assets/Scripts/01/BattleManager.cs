using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager Instance;

    private GameObject failedResultPanel;
    private GameObject successResultPanel;

    private bool isGameOver = false;
    public int roundIndex = 0;              //当前回合数
    private string curRoundName = "Player";     //当前回合是谁的回合

    private List<GameObject> players = new List<GameObject>();          //战斗场景中的存活的玩家角色
    private List<GameObject> enemys = new List<GameObject>();           //战斗场景中的存活的敌人角色

    private List<GameObject> unActPlayers = new List<GameObject>();     //本回合还未行动的玩家角色
    private List<GameObject> unActEnemys = new List<GameObject>();      //本回合还未行动的敌人角色

    private int roleIndex = 0;                  //当前要行动的角色的下标
    private GameObject curActRole;          //当前要行动的角色
    public Transform actRoleSign;           //当前要行动的角色标记特效

    private int targetIndex = 0;                //当前攻击目标的下标
    private GameObject curAttackTarget;     //当前攻击目标
    public Transform atkTargetSign;         //当前攻击目标标记特效


    public bool isWaitForPlayer = true;            //是否在等待玩家输入
    public bool isEnemyAction = false;              //是否是敌人行动

    public delegate void OnNewRoundEvent(string curRoundName);
    public event OnNewRoundEvent OnNewRound;

    public GameObject CurActRole { get { return curActRole; } }

    void Awake()
    {
        Instance = this;

        failedResultPanel = GameObject.Find("Canvas/FailedResultPanel");
        failedResultPanel.SetActive(false);
        successResultPanel = GameObject.Find("Canvas/SuccessResultPanel");
        successResultPanel.SetActive(false);
    }

    void Start () {
        //生成玩家角色和敌人角色
        SetPlayerList();
        SetEnemyList();

        //设定初始行动角色和攻击目标
        SetCurActRole(players[roleIndex]);
        SetCurAtkTarget(enemys[targetIndex]);

        UIControl.Instance.UpdateSkillPanel(curActRole);

        unActPlayers.AddRange(players);
        unActEnemys.AddRange(enemys);
	}
	


	void Update () {     
        if (!isGameOver)
        {
            //有一方集合元素数目为零，游戏结束
            if (enemys.Count == 0 || players.Count == 0)
            {
                GameOver();
                return;
            }

            if (isWaitForPlayer)
            {
                ChooseRoleAndTarget();
            }

            if (isEnemyAction)
            {
                StartCoroutine(EnemyRound());
            }
        }
    }

    /// <summary>
    /// 敌人回合的AI操作
    /// </summary>
    private IEnumerator EnemyRound()
    {
        isEnemyAction = false;
        for( int i = 0; i < enemys.Count; i++)
        {
            if (isGameOver)
                yield break;
            roleIndex = i;
            SetCurActRole(enemys[roleIndex]);

            targetIndex = Random.Range(0, players.Count);
            SetCurAtkTarget(players[targetIndex]);

            curActRole.GetComponent<EnemyBase>().EnemyAct();
            yield return new WaitForSeconds(1);
        }
        ChangeRound();
        StartCoroutine(ChangeRoundDelay());
    }

    /// <summary>
    /// 更新未操作的玩家角色
    /// </summary>
    public void UpdateUnActPlayers()
    {
        //先将刚行动过的角色移出可行动角色集合
        unActPlayers.Remove(curActRole);

        //如果已没有可行动角色
        if( unActPlayers.Count == 0)
        {
            isWaitForPlayer = false;
            //切换回合
            ChangeRound();

            StartCoroutine(ChangeRoundDelay());
        }
        else//还有可行动角色，先自动切换到下一个可行动角色
        {
            roleIndex++;
            if (roleIndex >= unActPlayers.Count)
            {
                roleIndex = 0;
            }
            SetCurActRole(unActPlayers[roleIndex]);
            UIControl.Instance.UpdateSkillPanel(curActRole);
        }
    }

    /// <summary>
    /// 敌人死亡后更新攻击目标
    /// </summary>
    public void UpdateCurAtkTarget()
    {
        if (enemys.Count != 0)
        {
            targetIndex = 0;
            SetCurAtkTarget(enemys[targetIndex]);
        }
    }

    /// <summary>
    /// 切换回合
    /// </summary>
    private void ChangeRound()
    {
        if (enemys.Count == 0 || players.Count == 0)
            return;

        roundIndex++;
        roleIndex = 0;
        targetIndex = 0;

        //调整行动角色和攻击目标以及标记
        if ( curRoundName == "Player")
        {
            curRoundName = "Enemy";
            SetCurActRole(enemys[roleIndex]);
            SetCurAtkTarget(players[targetIndex]);
        }
        else
        {
            curRoundName = "Player";
            SetCurActRole(players[roleIndex]);
            SetCurAtkTarget(enemys[targetIndex]);

            UIControl.Instance.UpdateSkillPanel(curActRole);

            unActPlayers.AddRange(players);
            unActEnemys.AddRange(enemys);
        }

        OnNewRound(curRoundName);
    }

    /// <summary>
    /// 回合切换延迟
    /// </summary>
    IEnumerator ChangeRoundDelay()
    {
        yield return new WaitForSeconds(1);
        if( curRoundName == "Enemy")
        {
            isEnemyAction = true;
        }
        else
        {
            isWaitForPlayer = true;
        }
    }

    #region 按键选择行动角色和目标
    /// <summary>
    /// 按键选择行动角色和攻击目标
    /// </summary>
    private void ChooseRoleAndTarget()
    {
        //按键选择行动角色
        if (Input.GetKeyDown(KeyCode.A))
        {
            roleIndex--;
            if (roleIndex < 0)
            {
                roleIndex = unActPlayers.Count - 1;
            }
            SetCurActRole(unActPlayers[roleIndex]);
            UIControl.Instance.UpdateSkillPanel(curActRole);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            roleIndex++;
            if (roleIndex >= unActPlayers.Count)
            {
                roleIndex = 0;
            }
            SetCurActRole(unActPlayers[roleIndex]);
            UIControl.Instance.UpdateSkillPanel(curActRole);
        }

        //按键选择攻击目标
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetIndex--;
            if (targetIndex < 0)
            {
                targetIndex = enemys.Count - 1;
            }
            SetCurAtkTarget(enemys[targetIndex]);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetIndex++;
            if (targetIndex == enemys.Count)
            {
                targetIndex = 0;
            }
            SetCurAtkTarget(enemys[targetIndex]);
        }
    }
    #endregion


    /// <summary>
    /// 设置当前行动角色
    /// </summary>
    private void SetCurActRole( GameObject role )
    {
        curActRole = role;
        ResetActRoleSignPos(curActRole);

        //设置当前行动角色的攻击目标
        curActRole.GetComponent<RoleBase>().AttackTarget = curAttackTarget;

        //设置当前行动角色的技能持有(只涉及玩家角色)
        PlayerBase playerBase = curActRole.GetComponent<PlayerBase>();
        if (playerBase != null)
            playerBase.SetSkillOwner();

    }

    /// <summary>
    /// 设置当前攻击目标
    /// </summary>
    private void SetCurAtkTarget( GameObject target )
    {
        curAttackTarget = target;
        ResetAtkTargetSignPos(curAttackTarget);

        //更新当前行动角色的攻击目标
        curActRole.GetComponent<RoleBase>().AttackTarget = curAttackTarget;
    }

    /// <summary>
    /// 改变行动角色标记特效位置
    /// </summary>
    private void ResetActRoleSignPos( GameObject role )
    {
        actRoleSign.position = new Vector3(role.transform.position.x, actRoleSign.position.y, role.transform.position.z);
    }

    /// <summary>
    /// 改变攻击目标标记特效位置
    /// </summary>
    private void ResetAtkTargetSignPos(GameObject target)
    {
        atkTargetSign.position = new Vector3(target.transform.position.x, atkTargetSign.position.y, target.transform.position.z);
    }

    /// <summary>
    /// 更新存活玩家角色集合
    /// </summary>
    public void UpdatePlayerList( GameObject deadRole )
    {
        players.Remove(deadRole);
    }

    /// <summary>
    /// 更新存活敌人角色集合
    /// </summary>
    public void UpdateEnemyList(GameObject deadRole)
    {
        enemys.Remove(deadRole);
    }

    /// <summary>
    /// 生成初始敌人配置
    /// </summary>
    private void SetEnemyList()
    {
        int enemyId = PlayerPrefs.GetInt(Globals.PP_BattleEnemyId);
        EnemyItem enemyItem = EnemyManager.Instance().GetEnemyById(enemyId);

        int pointIndex = 0;     //敌人生成点数组的下标
        foreach(EnemyItem.Enemy enemy in enemyItem.BattleEnemys)
        {
            GameObject enemyPrefab = RolePrefabDic.Instance.GetEnemyPrefabById(enemy.EnemyId);
            for(int i = 0; i < enemy.EnemyNum; i++)
            {
                GameObject tempEnemy = GameObject.Instantiate(enemyPrefab, RolePoints.Instance.enemyPoints[pointIndex].position, RolePoints.Instance.enemyPoints[pointIndex].rotation, RolePoints.Instance.enemyParent);
                enemys.Add(tempEnemy);
                pointIndex++;
            }
        }
    }

    /// <summary>
    /// 生成玩家配置
    /// </summary>
    private void SetPlayerList()
    {
        int pointIndex = 0;     //玩家生成点数组的下标
        foreach(PlayerKernelDataProxy player in TeamManager.Instance.PlayerList)
        {
            GameObject playerPrefab = RolePrefabDic.Instance.GetPlayerPrefabById(player.Id);
            GameObject tempPlayer = GameObject.Instantiate(playerPrefab, RolePoints.Instance.playerPoints[pointIndex].position, RolePoints.Instance.playerPoints[pointIndex].rotation, RolePoints.Instance.playerParent);
            tempPlayer.GetComponent<PlayerBase>().SetPlayerProPerty(player);        //赋值角色的各项属性
            players.Add(tempPlayer);
            pointIndex++;
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        //玩家胜利
        if(players.Count != 0)
        {
            successResultPanel.SetActive(true);
            int enemyId = PlayerPrefs.GetInt(Globals.PP_BattleEnemyId);
            successResultPanel.GetComponent<SuccessResultPanelCtrl>().SetRewardItems(enemyId);
        }
        else//玩家失败
        {
            failedResultPanel.SetActive(true);
        }
    }
}
