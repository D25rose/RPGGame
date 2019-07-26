using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂载在商城面板中单个商品的图片上，用于鼠标移入时显示商品具体信息
/// </summary>
public class ShopItemCtrl : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler {

    private InventoryItem m_InventoryItem;

    public InventoryItem InventoryItem
    {
        get { return m_InventoryItem; }
        set { m_InventoryItem = value; }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TootipPanelManager.Instance.ShowItemInfoTootip(m_InventoryItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TootipPanelManager.Instance.HideItemInfoTootip();
    }
}
