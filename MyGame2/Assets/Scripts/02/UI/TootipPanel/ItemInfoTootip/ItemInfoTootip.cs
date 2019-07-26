using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理所有物品详细信息弹窗
/// </summary>
public class ItemInfoTootip : MonoBehaviour {

    private EquipItemTootip m_EquipItemTootip;
    private PropItemTootip m_PropItemTootip;
    private ConsumeItemTootip m_ConsumeItemTootip;

    void Awake()
    {
        m_EquipItemTootip = transform.Find("EquipItem").GetComponent<EquipItemTootip>();
        m_PropItemTootip = transform.Find("PropItem").GetComponent<PropItemTootip>();
        m_ConsumeItemTootip = transform.Find("ConsumeItem").GetComponent<ConsumeItemTootip>();
    }

    public void ShowItemInfo( InventoryItem item  )
    {
        switch (item.Type)
        {
            case "Equip":
                m_EquipItemTootip.gameObject.SetActive(true);
                m_EquipItemTootip.InitView(item);
                break;
            case "Prop":
                m_PropItemTootip.gameObject.SetActive(true);
                m_PropItemTootip.InitView(item);
                break;
            case "Consume":
                m_ConsumeItemTootip.gameObject.SetActive(true);
                m_ConsumeItemTootip.InitView(item);
                break;
        }
    }

    public void HideItemInfo()
    {
        if (m_EquipItemTootip.gameObject.activeSelf == true)
        {
            m_EquipItemTootip.gameObject.SetActive(false);
            return;
        }
        if (m_PropItemTootip.gameObject.activeSelf == true)
        {
            m_PropItemTootip.gameObject.SetActive(false);
            return;
        }
        if (m_ConsumeItemTootip.gameObject.activeSelf == true)
        {
            m_ConsumeItemTootip.gameObject.SetActive(false);
            return;
        }
    }

    public void SetLocalPos(Vector2 pos)
    {
        transform.localPosition = pos;
    }

}
