using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在合成面板左侧列表里的可合成物品上
/// </summary>
public class CraftItemCtrl : MonoBehaviour {

    private InventoryItem m_InventoryItem;

    public InventoryItem InventoryItem
    {
        get { return m_InventoryItem; }
        set { m_InventoryItem = value;
            InitView();
        }
    }

    private Image itemImage;
    private Text itemName;
    private Button m_Button;

    void Awake()
    {
        itemImage = transform.Find("ItemSlot/Image").GetComponent<Image>();
        itemName = transform.Find("ItemName").GetComponent<Text>();
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    private void InitView()
    {
        itemImage.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + m_InventoryItem.Sprite);
        itemName.text = m_InventoryItem.ItemName;
    }

    private void OnButtonClick()
    {
        CraftPanelCtrl.Instance.ResetItemNeeds(m_InventoryItem);
    }

}
