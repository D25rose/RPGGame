using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPanelCtrl : MonoBehaviour {

    public static EquipPanelCtrl Instance;

    private EquipPanelView m_EquipPanelView;
    private EquipPanelModel m_EquipPanelModel;

    private int curPlayerId = -1;               //当前显示的角色的id
    public int CurPlayerId { get { return curPlayerId; } set { curPlayerId = value; } }

    private int curChangingSlotIndex = -1;      //当前正在更换装备的装备槽的标号

    void Awake()
    {
        Instance = this;

        Init();
    }


    void Init()
    {
        m_EquipPanelModel = gameObject.GetComponent<EquipPanelModel>();
        m_EquipPanelView = gameObject.GetComponent<EquipPanelView>();
    }

    /// <summary>
    /// 显示当前角色的装备
    /// </summary>
    public void ShowCurPlayerEquips( int playerId )
    {
        int[] equips = m_EquipPanelModel.GetEquipsByPlayerId(playerId);
        for( int i = 0; i < equips.Length; i++)
        {
            m_EquipPanelView.EquipSlotCtrls[i].EquipItem = GlobalInventoryItemManager.Instance.GetItemById(equips[i]);
        }
    }

    /// <summary>
    /// 设置变量(当前正在更换装备的装备槽标号)的值
    /// </summary>
    /// <param name="index"></param>
    public void SetCurChangingIndex( int index )
    {
        curChangingSlotIndex = index;
    }

    /// <summary>
    /// 穿上装备
    /// </summary>
    public bool TakeOnEquipment(int itemId)
    {
        InventoryItem item = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        if( item.Type != "Equip")//如果要穿上的物品不是装备，那么不能装备
        {
            TootipPanelManager.Instance.ShowWarningTootip("不能装备该类型的物品！");
            return false;
        }
        else if ( item.EquipType != curChangingSlotIndex )//如果要穿上的装备类型和装备槽类型不匹配，那么不能装备
        {
            TootipPanelManager.Instance.ShowWarningTootip("装备类型不符合！");
            return false;
        }
        else
        {
            //如果该装备槽内已有装备，那么先脱下,并把它放回背包中
            if(m_EquipPanelView.EquipSlotCtrls[curChangingSlotIndex].EquipItem != null)
            {
                m_EquipPanelModel.TakeOffEquipment(curPlayerId , curChangingSlotIndex , item);                       //更改角色实体类里的信息
                InventoryPanelCtrl.Instance.AddItem(m_EquipPanelView.EquipSlotCtrls[curChangingSlotIndex].EquipItem.ItemId);        //把脱下的装备放入背包中
            }
            m_EquipPanelView.EquipSlotCtrls[curChangingSlotIndex].EquipItem = item;                           //给装备槽的属性赋值
            m_EquipPanelModel.TakeOnEquipment(curPlayerId, item.ItemId , curChangingSlotIndex , item);               //更改角色实体类里的信息
            InventoryPanelCtrl.Instance.RemoveItem(item.ItemId);                                              //把该装备从背包中移除
        }
        return true;
    }
    
    /// <summary>
    /// 脱下装备
    /// </summary>
    public void TakeOffEquipment(int itemId)
    {
        InventoryItem item = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        m_EquipPanelModel.TakeOffEquipment(curPlayerId, curChangingSlotIndex ,item);                       //更改角色实体类里的信息
        InventoryPanelCtrl.Instance.AddItem(m_EquipPanelView.EquipSlotCtrls[curChangingSlotIndex].EquipItem.ItemId);    //把脱下的装备放入背包中
        m_EquipPanelView.EquipSlotCtrls[curChangingSlotIndex].EquipItem = null;                      //把装备槽的属性赋值为空
    }

}
