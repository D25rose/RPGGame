using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在商店面板单个商品上
/// </summary>
public class ShopItemSlotCtrl : MonoBehaviour {

    private InventoryItem m_InventoryItem;

    public InventoryItem InventoryItem
    {
        get { return m_InventoryItem; }
        set { m_InventoryItem = value;
            InitView();
        }
    }

    private Image itemImage;    //商品图片
    private Text itemName;      //商品名称
    private Text price;         //商品价格
    private Button buyBtn;      //购买按钮

    void Awake()
    {
        itemImage = transform.Find("ItemImage/Image").GetComponent<Image>();
        itemName = transform.Find("ItemName").GetComponent<Text>();
        price = transform.Find("Price/Num").GetComponent<Text>();
        buyBtn = transform.Find("BuyBtn").GetComponent<Button>();

        buyBtn.onClick.AddListener(OnBuyBtnClick);
    }

    private void InitView()
    {
        itemImage.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + m_InventoryItem.Sprite);
        itemName.text = m_InventoryItem.ItemName;
        price.text = m_InventoryItem.Price.ToString();
        transform.Find("ItemImage").GetComponent<ShopItemCtrl>().InventoryItem = m_InventoryItem;
    }

    private void OnBuyBtnClick()
    {
        TootipPanelManager.Instance.ShowChooseNumTootip(m_InventoryItem.Price , 99);
        ChooseNumTootip.eventChooseNumMethod = BuyItem;
    }

    /// <summary>
    /// 购买物品的逻辑
    /// </summary>
    /// <param name="num">购买数量</param>
    private void BuyItem( int num)
    {
        ShopPanelCtrl.Instance.BuyItem(m_InventoryItem, num);
    }

}
