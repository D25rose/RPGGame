using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 单个物品控制脚本
/// </summary>
public class InventoryItemCtrl : MonoBehaviour , IPointerClickHandler  , IPointerEnterHandler, IPointerExitHandler{

    private InventoryItem inventoryItem;

    public InventoryItem InventoryItem
    {
        get { return inventoryItem; }
        set { inventoryItem = value;
            image.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + inventoryItem.Sprite);
            num.text = inventoryItem.CurNum.ToString();

            //物品数量UI更新的委托事件注册
            inventoryItem.eventUpdateItemNum += InventoryItem_eventUpdateItemNum;
        }
    }

    private Image image;        //物品图片
    private Text num;           //物品数量

	void Awake () {
        image = gameObject.GetComponent<Image>();
        num = transform.Find("num").GetComponent<Text>(); 
	}

    void OnDestroy()
    {
        inventoryItem.eventUpdateItemNum -= InventoryItem_eventUpdateItemNum;//自身被销毁时删除注册事件
    }

    /// <summary>
    /// 物品点击事件，更换装备时点击该装备物品即会穿戴上该装备
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        TootipPanelManager.Instance.HideItemInfoTootip();//点击物品时也要隐藏物品详细信息弹窗

        //如果正在进行装备更换操作
        if (MainPanelCtrl.Instance.IsChangingEquip)
        {
            //对应装备槽更换上该装备
            bool changeResult = EquipPanelCtrl.Instance.TakeOnEquipment(inventoryItem.ItemId);
            if (changeResult)
            {
                MainPanelCtrl.Instance.IsChangingEquip = false;
                MainPanelCtrl.Instance.HideInventoryPanel();
            }
        }

        //如果正在进行出售物品操作
        if (MainPanelCtrl.Instance.IsSellItem)
        {
            //点击物品后显示出售数量选择的弹窗
            TootipPanelManager.Instance.ShowChooseNumTootip(inventoryItem.SellPrice , inventoryItem.CurNum);
            ChooseNumTootip.eventChooseNumMethod = (num) => { ShopPanelCtrl.Instance.SellItem(inventoryItem , num); };//给选择出售数量的弹窗的确认按钮注册事件
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TootipPanelManager.Instance.ShowItemInfoTootip(inventoryItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TootipPanelManager.Instance.HideItemInfoTootip();
    }

    /// <summary>
    /// 委托方法
    /// </summary>
    /// <param name="curNum">物品当前数量</param>
    private void InventoryItem_eventUpdateItemNum(int curNum)
    {
        num.text = curNum.ToString();
    }

}
