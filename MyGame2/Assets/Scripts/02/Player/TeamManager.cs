using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理所有玩家角色
/// </summary>
public class TeamManager {

    private static TeamManager instance;

    public static TeamManager Instance
    {
        get {
                if (instance == null)
                {
                    instance = new TeamManager();
                }
                return instance;
            }
    }

    private TeamManager()
    {
        InitPlayers();
    }

    //玩家角色数据类集合
    private List<PlayerKernelDataProxy> playerList = new List<PlayerKernelDataProxy>();
    //玩家角色Id和数据类的字典
    private Dictionary<int, PlayerKernelDataProxy> playerDic = new Dictionary<int, PlayerKernelDataProxy>();
    //玩家角色信息实体类集合
    List<PlayerItem> playerItemList;

    public Dictionary<int, PlayerKernelDataProxy> PlayerDic
    {
        get { return playerDic; }
    }

    public List<PlayerKernelDataProxy> PlayerList
    {
        get { return playerList; }
    }

    public List<PlayerItem> PlayerItemList
    {
        get { return playerItemList; }
    }

    private void InitPlayers()
    {
        playerItemList = PlayerInfoManager.Instance.PlayerList;

        foreach(PlayerItem playerItem in playerItemList)
        {
            PlayerKernelDataProxy player = new PlayerKernelDataProxy(playerItem.PlayerId, playerItem.PlayerName, playerItem.Image, playerItem.Hp, playerItem.Mp, playerItem.Attack, playerItem.Defense,
                playerItem.Speed, playerItem.Level, playerItem.Skills, playerItem.Equips, playerItem.HpByEquip, playerItem.MpByEquip, playerItem.AttackByEquip, playerItem.DefenseByEquip, playerItem.SpeedByEquip);
            playerDic.Add(player.Id, player);
            playerList.Add(player);
        }
    }

    /// <summary>
    /// 通过角色id获取角色信息代理类
    /// </summary>
    /// <param name="id"></param>
    public PlayerKernelDataProxy GetPlayerById( int id )
    {
        PlayerKernelDataProxy temp = null;
        PlayerDic.TryGetValue(id, out temp);
        return temp;
    }

    /// <summary>
    /// 将PlayerKernelDataProxy代理类中更改过的值更新到PlayerItem中去
    /// </summary>
    public void UpdateDataInPlayerItem()
    {
        for(int i = 0; i < playerList.Count; i++)
        {
            playerItemList[i].SetInfo(playerList[i]);
        }
    }

}
