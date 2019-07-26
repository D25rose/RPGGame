using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂载在角色信息面板中装备槽里用于显示装备的Image物体上，专门用来控制鼠标移入移出时装备详细信息弹窗的显示
/// </summary>
public class EquipSlotImageCtrl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItem m_EquipItem;

    public InventoryItem EquipItem
    {
        get { return m_EquipItem; }
        set { m_EquipItem = value; }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_EquipItem != null)
            TootipPanelManager.Instance.ShowItemInfoTootip(m_EquipItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_EquipItem != null)
            TootipPanelManager.Instance.HideItemInfoTootip();
    }
}
