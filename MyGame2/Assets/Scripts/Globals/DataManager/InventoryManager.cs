using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局存储玩家背包物品数据的管理器
/// </summary>
public class InventoryManager  {

    #region 单例
    private static InventoryManager instance;

    public static InventoryManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new InventoryManager();
            }
            return instance;
        }
    }
    #endregion

    private int slotsNum = 32;

    private List<InventoryItem> equipItemList;      //所有装备物品集合
    private List<InventoryItem> propItemList;       //所有道具物品集合
    private List<InventoryItem> consumeItemList;    //所有消耗品物品集合

    public List<InventoryItem> EquipItemList { get { return equipItemList; } }
    public List<InventoryItem> PropItemList { get { return propItemList; } }
    public List<InventoryItem> ConsumeItemList { get { return consumeItemList; } }
    

    private InventoryManager()
    {
        
    }

    /// <summary>
    /// 读取存档数据
    /// </summary>
    public void LoadInventoryData()
    {
        equipItemList = GetEquipItems();
        propItemList = GetPropItems();
        consumeItemList = GetConsumeItems();
    }

    #region  从Json文件中获取对应类型物品实体类的集合
    /// <summary>
    /// 获取所有装备
    /// </summary>
    private List<InventoryItem> GetEquipItems()
    {
        return JsonTools.GetJsonList<InventoryItem>("EquipItemData");
    }

    /// <summary>
    /// 获取所有道具
    /// </summary>
	private List<InventoryItem> GetPropItems()
    {
        return JsonTools.GetJsonList<InventoryItem>("PropItemData");
    }

    /// <summary>
    /// 获取所有消耗品
    /// </summary>
	private List<InventoryItem> GetConsumeItems()
    {
        return JsonTools.GetJsonList<InventoryItem>("ConsumeItemData");
    }
    #endregion

    public bool AddItem(int itemId)
    {
        InventoryItem temp = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        InventoryItem item = IsItemContained(temp);

        if (item != null)//如果背包内已有该物品
        {
            item.CurNum++;//该物品数量加1
            return true;
        }
        else
        {
            int curNum = GetItemNum(temp);
            if (curNum < slotsNum)//还有空的物品槽，可以添加
            {
                AddItem(GlobalInventoryItemManager.Instance.NewItem(itemId));
                return true;
            }
            else
            {
                //该面板显示在战斗场景中不适用
                TootipPanelManager.Instance.ShowWarningTootip("背包已满！");
                return false;
            }
        }
    }

    /// <summary>
    /// 移除物品
    /// </summary>
    public void RemoveItem(int itemId)
    {
        InventoryItem temp = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        InventoryItem item = IsItemContained(temp);

        //若没有该物品
        if (item == null)
        {
            //在战斗场景中不适用
            TootipPanelManager.Instance.ShowWarningTootip("物品不足");
            return;
        }
        else
        {
            if (item.CurNum > 1)//如果物品数量大于1，把数量减1
            {
                item.CurNum--;
            }
            else//数量等于1，移除该物品
            {
                item.CurNum--;
                //把该物品从InventoryItem集合中移除
                RemoveItem(item);
            }
        }
    }

    /// <summary>
    /// 根据物品id获取背包中该物品的数量
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public int GetItemCountById(int itemId)
    {
        InventoryItem temp = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        InventoryItem item = IsItemContained(temp);

        if (item == null)
            return 0;

        return item.CurNum;
    }

    /// <summary>
    /// 判断背包里是否有该物品，有则返回该物品对象，无则返回null
    /// </summary>
    private InventoryItem IsItemContained(InventoryItem item)
    {
        switch (item.Type)
        {
            case "Equip":
                for (int i = 0; i < equipItemList.Count; i++)
                {
                    if (equipItemList[i].ItemId == item.ItemId)
                        return equipItemList[i];
                }
                break;
            case "Prop":
                for (int i = 0; i < propItemList.Count; i++)
                {
                    if (propItemList[i].ItemId == item.ItemId)
                        return propItemList[i];
                }
                break;
            case "Consume":
                for (int i = 0; i < consumeItemList.Count; i++)
                {
                    if (consumeItemList[i].ItemId == item.ItemId)
                        return consumeItemList[i];
                }
                break;
        }
        return null;
    }

    /// <summary>
    /// 获取该物品对应的物品类型的物品数量
    /// </summary>
    /// <returns></returns>
    private int GetItemNum(InventoryItem item)
    {
        switch (item.Type)
        {
            case "Equip":
                return equipItemList.Count;
            case "Prop":
                return propItemList.Count;
            case "Consume":
                return consumeItemList.Count;
        }
        return -1;
    }

    /// <summary>
    /// 添加物品
    /// </summary>
    public void AddItem(InventoryItem item)
    {
        switch (item.Type)
        {
            case "Equip":
                equipItemList.Add(item);
                break;
            case "Prop":
                propItemList.Add(item);
                break;
            case "Consume":
                consumeItemList.Add(item);
                break;
        }
    }

    /// <summary>
    /// 移除物品
    /// </summary>
    public void RemoveItem(InventoryItem item)
    {
        switch (item.Type)
        {
            case "Equip":
                equipItemList.Remove(item);
                break;
            case "Prop":
                propItemList.Remove(item);
                break;
            case "Consume":
                consumeItemList.Remove(item);
                break;
        }
    }
}
