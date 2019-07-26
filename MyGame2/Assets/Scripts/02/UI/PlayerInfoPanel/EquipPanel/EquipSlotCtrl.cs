using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 挂载在角色信息面板里的角色装备槽上
/// </summary>
public class EquipSlotCtrl : MonoBehaviour , IPointerClickHandler {

    private int index;          //该装备槽的标号

    private InventoryItem m_EquipItem;

    public InventoryItem EquipItem
    {
        get { return m_EquipItem; }
        set { m_EquipItem = value;
            if( m_EquipItem != null)
            {
                image.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + m_EquipItem.Sprite);
            }
            else
            {
                image.sprite = nullEquipSprite;
            }
            m_EquipSlotImageCtrl.EquipItem = m_EquipItem;
        }
    }

    private Sprite nullEquipSprite;  //无装备时的加号图片

    private Image image;        //装备显示图片
    private Button removeBtn;   //卸下按钮

    private EquipSlotImageCtrl m_EquipSlotImageCtrl;//该装备槽用于显示装备的Image物体上的脚本

    void Awake()
    {
        index = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
        nullEquipSprite = Resources.Load<Sprite>("InventoryItemTextures/plusSign");

        image = transform.Find("Image").GetComponent<Image>();
        removeBtn = transform.Find("removeBtn").GetComponent<Button>();

        m_EquipSlotImageCtrl = image.GetComponent<EquipSlotImageCtrl>();

        removeBtn.onClick.AddListener(OnButtonClick);
    }

    /// <summary>
    /// 装备槽点击事件，点击后显示装备背包进行装备更换
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        MainPanelCtrl.Instance.IsChangingEquip = true;          //修改MainPanel中标志
        MainPanelCtrl.Instance.ShowInventoryPanel();            //显示背包面板
        EquipPanelCtrl.Instance.SetCurChangingIndex(index);     //把自身标号传递给装备面板控制器
    }

    private void OnButtonClick()
    {
        if (m_EquipItem == null)
            return;

        EquipPanelCtrl.Instance.SetCurChangingIndex(index);     //把自身标号传递给装备面板控制器
        EquipPanelCtrl.Instance.TakeOffEquipment(m_EquipItem.ItemId);       //卸下装备
    }
}
