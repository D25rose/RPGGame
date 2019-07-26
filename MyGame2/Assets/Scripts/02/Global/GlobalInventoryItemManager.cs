using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来记录游戏中所有的物品实体类，为其他需要的地方提供索引
/// 挂载在GlobalManager物体上
/// </summary>
public class GlobalInventoryItemManager {

    #region 单例
    private static GlobalInventoryItemManager instance;

    public static GlobalInventoryItemManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GlobalInventoryItemManager();
            }
            return instance;
        }
    }
    #endregion

    private List<InventoryItem> itemList;               //游戏中所有存在的物品的实体类集合
    private Dictionary<int, InventoryItem> itemDic;     //方便根据id获取物品实体类

    private GlobalInventoryItemManager()
    {
        itemList = JsonTools.GetJsonList<InventoryItem>("AllItemData");
        itemDic = new Dictionary<int, InventoryItem>();
        for (int i = 0; i < itemList.Count; i++)
        {
            itemDic.Add(itemList[i].ItemId, itemList[i]);
        }
    }

    /// <summary>
    /// 根据物品id获取实体类对象
    /// </summary>
    /// <param name="id">物品id</param>
    public InventoryItem GetItemById(int id)
    {
        InventoryItem temp = null;
        itemDic.TryGetValue(id, out temp);
        return temp;
    }

    /// <summary>
    /// 根据物品id获取物品名称
    /// </summary>
    public string GetItemNameById(int id)
    {
        return GetItemById(id).ItemName;
    }

    /// <summary>
    /// 获得一个全新的Item地址
    /// </summary>
    /// <param name="id">物品id</param>
    /// <returns></returns>
    public InventoryItem NewItem(int id)
    {
        InventoryItem temp = GetItemById(id);
        return new InventoryItem(temp.ItemId, temp.ItemName, temp.Type, temp.EquipType, temp.CurNum, temp.Sprite, temp.EquipHp, temp.EquipMp, temp.EquipAttack, temp.EquipDefense, temp.EquipSpeed,
            temp.Descr, temp.Price, temp.SellPrice, temp.RecoverHp, temp.RecoverMp, temp.Drawings , temp.DrawingPrice);
    }
}
