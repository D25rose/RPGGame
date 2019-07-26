using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPanelCtrl : MonoBehaviour {

    public static CraftPanelCtrl Instance;

    private CraftPanelView m_CraftPanelView;
    private CraftPanelModel m_CraftPanelModel;

    private List<GameObject> craftItemList;         //当前显示类型的可合成物品集合
    private List<GameObject> needsItemList;         //当前显示的材料项的集合

    //private int curIndex = -1;

    void Awake()
    {
        Instance = this;

        Init();
    }

    void Start()
    {
        ResetTabsAndItems(0);
    }

    /// <summary>
    /// 再次显示该面板
    /// </summary>
    public void ReShow()
    {
        ResetTabsAndItems(0);
    }

    private void Init()
    {
        m_CraftPanelModel = gameObject.GetComponent<CraftPanelModel>();
        m_CraftPanelView = gameObject.GetComponent<CraftPanelView>();

        craftItemList = new List<GameObject>();
        needsItemList = new List<GameObject>();
    }

    /// <summary>
    /// 重置选项卡和可合成物品
    /// </summary>
    /// <param name="index">选项卡标号</param>
    private void ResetTabsAndItems(int index)
    {
        //curIndex = index;

        ClearCraftItems();
        CreateAllCraftItems(index);
        ResetItemNeeds(craftItemList[0].GetComponent<CraftItemCtrl>().InventoryItem);//默认显示列表中第一个物品的合成材料列表
    }

    /// <summary>
    /// 生成面板左侧可合成物品列表
    /// </summary>
    /// <param name="index">选项卡标号（0：装备，1：药品）</param>
    private void CreateAllCraftItems( int index )
    {
        int[] itemList = m_CraftPanelModel.GetItemListByTabIndex(index);
        
        for( int i = 0; i < itemList.Length; i++)
        {
            GameObject item = GameObject.Instantiate(m_CraftPanelView.Prefab_CraftItem, m_CraftPanelView.CraftItemGrid_Transform);
            item.GetComponent<CraftItemCtrl>().InventoryItem = GlobalInventoryItemManager.Instance.GetItemById(itemList[i]);
            craftItemList.Add(item);
        }
    }

    /// <summary>
    /// 重置右侧需要的材料列表，数目选择和价格等
    /// </summary>
    /// <param name="item"></param>
    public void ResetItemNeeds(InventoryItem item)
    {
        ClearNeedsItems();

        //修改名称
        m_CraftPanelView.Text_CraftingItemName.text = item.ItemName;
        //生成材料项
        for( int i = 0; i < item.Drawings.Length; i++)
        {
            string name = GlobalInventoryItemManager.Instance.GetItemNameById(item.Drawings[i].ItemId);
            int haveNum = InventoryPanelCtrl.Instance.GetItemCountById(item.Drawings[i].ItemId);

            GameObject needItem = GameObject.Instantiate(m_CraftPanelView.Prefab_NeedItem, m_CraftPanelView.NeedItemGrid_Transform);
            needItem.GetComponent<NeedItemCtrl>().InitView(item.Drawings[i].ItemId, name, item.Drawings[i].ItemCount, haveNum);
            needsItemList.Add(needItem);
        }

        //修改选择数目和价格
        m_CraftPanelView.M_CraftNumAreaCtrl.CraftItem = item;
    }

    /// <summary>
    /// 清除当前可合成物品
    /// </summary>
    private void ClearCraftItems()
    {
        foreach (GameObject item in craftItemList)
        {
            GameObject.Destroy(item);
        }
        craftItemList.Clear();
    }

    /// <summary>
    /// 清除当前材料项
    /// </summary>
    private void ClearNeedsItems()
    {
        foreach (GameObject item in needsItemList)
        {
            GameObject.Destroy(item);
        }
        needsItemList.Clear();
    }

    /// <summary>
    /// 合成物品
    /// </summary>
    /// <param name="craftItem">要合成的物品</param>
    /// <param name="craftNum">合成数量</param>
    public bool CraftItem( InventoryItem craftItem , int craftNum )
    {
        //判断金钱是否足够
        int totalPrice = craftItem.DrawingPrice * craftNum;
        if( GlobalPlayerData.Instance.GoldNum < totalPrice)
        {
            TootipPanelManager.Instance.ShowWarningTootip("金钱不足，无法合成");
            return false;
        }

        for (int i = 0; i < craftItem.Drawings.Length; i++)
        {
            
            int haveNum = InventoryPanelCtrl.Instance.GetItemCountById(craftItem.Drawings[i].ItemId);
            if(haveNum < craftNum*craftItem.Drawings[i].ItemCount)
            {
                TootipPanelManager.Instance.ShowWarningTootip("材料不足，无法合成");
                return false;
            }     
        }

        //都足够，开始合成，往背包中添加合成后的物品（先添加，后扣除，避免添加失败后返回材料和金钱）
        for( int i = 0; i < craftNum; i++)
        {
            bool isAddSuccess = InventoryPanelCtrl.Instance.AddItem(craftItem.ItemId);
            if (isAddSuccess)//添加成功，扣除金钱和材料
            {
                //扣除金钱
                GlobalPlayerData.Instance.ConsumGold(craftItem.DrawingPrice);
                //扣除材料
                foreach (var drawing in craftItem.Drawings)
                {
                    for( int j = 0; j < drawing.ItemCount; j++ ){
                        InventoryPanelCtrl.Instance.RemoveItem(drawing.ItemId);
                    }
                }
                TootipPanelManager.Instance.ShowWarningTootip("合成成功！");
            }
            else//添加失败，结束
            {
                //背包已满的警告在添加物品逻辑中会报
                return false;
            }
        }
        return true;
    }

}
