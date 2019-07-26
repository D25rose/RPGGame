using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelModel : MonoBehaviour {

    private List<InventoryItem> equipItemList;      //所有装备物品集合
    private List<InventoryItem> propItemList;       //所有道具物品集合
    private List<InventoryItem> consumeItemList;    //所有消耗品物品集合

    void Awake()
    {
        equipItemList = InventoryManager.Instance.EquipItemList;
        propItemList = InventoryManager.Instance.PropItemList;
        consumeItemList = InventoryManager.Instance.ConsumeItemList;
    }


    /// <summary>
    /// 根据选项卡标号获取对应类型物品的实体类集合
    /// </summary>
    /// <param name="index">0：装备，1：道具，2：消耗品</param>
    /// <returns></returns>
    public List<InventoryItem> GetItemListByTabIndex(int index)
    {
        switch (index)
        {
            case 0:
                return equipItemList;
            case 1:
                return propItemList;
            case 2:
                return consumeItemList;
        }
        return null;
    }






}
