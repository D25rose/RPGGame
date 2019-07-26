using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPanelModel : MonoBehaviour {

    /// <summary>
    /// 根据角色id获取角色当前穿戴的装备
    /// </summary>
	public int[] GetEquipsByPlayerId( int id )
    {
        return TeamManager.Instance.GetPlayerById(id).Equips;
    }

    /// <summary>
    /// 角色穿上装备
    /// </summary>
    /// <param name="playerId">角色id</param>
    /// <param name="itemId">装备物品id</param>
    /// <param name="equipType">装备类型</param>
    public void TakeOnEquipment( int playerId , int itemId , int equipType , InventoryItem item )
    {
        PlayerKernelDataProxy player = TeamManager.Instance.GetPlayerById(playerId);
        player.Equips[equipType] = itemId;
        player.IncreaseHpByEquip(item.EquipHp);
        player.IncreaseMpByEquip(item.EquipMp);
        player.IncreaseAttackByEquip(item.EquipAttack);
        player.IncreaseDefneseByEquip(item.EquipDefense);
        player.IncreaseSpeedByEquip(item.EquipSpeed);
    }

    /// <summary>
    /// 角色脱下装备
    /// </summary>
    /// <param name="playerId">角色id</param>
    /// <param name="equipType">装备类型</param>
    public void TakeOffEquipment(int playerId,  int equipType , InventoryItem item)
    {
        PlayerKernelDataProxy player = TeamManager.Instance.GetPlayerById(playerId);
        player.Equips[equipType] = 0;
        player.DecreaseHpByEquip(item.EquipHp);
        player.DecreaseMpByEquip(item.EquipMp);
        player.DecreaseAttackByEquip(item.EquipAttack);
        player.DecreaseDefenseByEquip(item.EquipDefense);
        player.DecreaseSpeedByEquip(item.EquipSpeed);
    }

}
