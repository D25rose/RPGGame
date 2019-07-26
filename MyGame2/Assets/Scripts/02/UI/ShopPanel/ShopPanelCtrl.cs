using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelCtrl : MonoBehaviour {

    public static ShopPanelCtrl Instance;

    private ShopPanelModel m_ShopPanelModel;
    private ShopPanelView m_ShopPanelView;

    void Awake()
    {
        Instance = this;

        Init();
    }

    void Init()
    {
        m_ShopPanelModel = gameObject.GetComponent<ShopPanelModel>();
        m_ShopPanelView = gameObject.GetComponent<ShopPanelView>();
    }

    void Start()
    {
        CreateAllShopItems();

        m_ShopPanelView.Sell_Btn.onClick.AddListener(OnSellBtnClick);
    }

    private void OnSellBtnClick()
    {
        MainPanelCtrl.Instance.IsSellItem = true;
        MainPanelCtrl.Instance.ShowInventoryPanel();
    }

    /// <summary>
    /// 生成所有商品
    /// </summary>
    private void CreateAllShopItems()
    {
        for( int i = 0; i < m_ShopPanelModel.ShopItemList.Length; i++)
        {
            GameObject itemSlot = GameObject.Instantiate(m_ShopPanelView.Prefab_ShopItemSlot, m_ShopPanelView.Grid_Transform);
            itemSlot.GetComponent<ShopItemSlotCtrl>().InventoryItem = GlobalInventoryItemManager.Instance.GetItemById(m_ShopPanelModel.ShopItemList[i]);
        }
    }

    /// <summary>
    /// 购买物品
    /// </summary>
    /// <param name="item">物品类型</param>
    /// <param name="num">购买数量</param>
    public void BuyItem( InventoryItem item , int num )
    {
        int totalPrice = num * item.Price;
        if (totalPrice > GlobalPlayerData.Instance.GoldNum)//金钱不够
        {
            TootipPanelManager.Instance.ShowWarningTootip("金钱数目不足");
        }
        else
        {
            //向背包中添加物品
            for (int i = 0; i < num; i++)
            {
                bool isAddSuccess = InventoryPanelCtrl.Instance.AddItem(item.ItemId);
                if (isAddSuccess)//如果添加成功，扣除金钱
                {
                    GlobalPlayerData.Instance.ConsumGold(item.Price);
                }
                else//添加失败，停止后续添加
                {
                    //背包已满的警告在添加物品逻辑中会报
                    return;
                }
            }
            TootipPanelManager.Instance.ShowWarningTootip("购买成功！");
        }
    }

    /// <summary>
    /// 出售物品
    /// </summary>
    /// <param name="item">物品类型</param>
    /// <param name="num">出售数量</param>
    public void SellItem(InventoryItem item, int num)
    {
        int totalGoldNum = num * item.SellPrice;//计算能获得的金钱数
        GlobalPlayerData.Instance.AddGold(totalGoldNum);//添加金钱
        
        //移除背包中的物品
        for( int i = 0; i < num; i++)
        {
            InventoryPanelCtrl.Instance.RemoveItem(item.ItemId);
        }
    }

}
