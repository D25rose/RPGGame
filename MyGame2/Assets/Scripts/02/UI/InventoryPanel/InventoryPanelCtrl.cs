using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelCtrl : MonoBehaviour {

    public static InventoryPanelCtrl Instance;

    private InventoryPanelView m_InventoryPanelView;
    private InventoryPanelModel m_InventoryPanelModel;

    [SerializeField]
    private int slotsNum = 32;

    public List<GameObject> tabList;               //所有选项卡集合

    private List<GameObject> slotList;              //所有物品槽集合
  
    //物品集合
    private List<GameObject> itemList;  

    private int curIndex = -1;            //当前选中的选项卡标号

    void Awake()
    {
        Instance = this;

        Init();
    }

    void Start()
    {
        CreateAllSlots();
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
        m_InventoryPanelView = gameObject.GetComponent<InventoryPanelView>();
        m_InventoryPanelModel = gameObject.GetComponent<InventoryPanelModel>();

        slotList = new List<GameObject>();
        itemList = new List<GameObject>();
    }

    private void CreateAllSlots()
    {
        for( int i = 0; i < slotsNum; i++)
        {
            GameObject slot = GameObject.Instantiate(m_InventoryPanelView.Prefab_ItemSlot, m_InventoryPanelView.Grid_Transform);
            slot.name = "slot" + i;
            slotList.Add(slot);
        }
    }

    /// <summary>
    /// 生成对应类型的物品
    /// </summary>
    private void CreateItemsByTabIndex(int index)
    {
        List<InventoryItem> list = m_InventoryPanelModel.GetItemListByTabIndex(index);
        for (int i = 0; i < list.Count; i++)
        {
            GameObject item = GameObject.Instantiate(m_InventoryPanelView.Prefab_InventoryItem, slotList[i].transform);
            item.name = "InventoryItem";
            item.GetComponent<InventoryItemCtrl>().InventoryItem = list[i];
            itemList.Add(item);
        }
    }

    /// <summary>
    /// 重置选项卡和物品显示
    /// </summary>
    private void ResetTabsAndItems( int index )
    {
        if (curIndex != -1)
            tabList[curIndex].GetComponent<TabItemCtrl>().NormalTab();      //上一个选中的选项卡变为未选中状态

        tabList[index].GetComponent<TabItemCtrl>().ActiveTab();             //当前选中的选项卡变为选中状态
        ClearCurItems();        //清除当前显示物品
        CreateItemsByTabIndex(index);   //显示新的物品
        curIndex = index;
    }

    /// <summary>
    /// 清除当前显示的物品
    /// </summary>
    private void ClearCurItems()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject.Destroy(itemList[i]);
        }
        itemList.Clear();
    }

    /// <summary>
    /// 向背包中添加物品
    /// </summary>
    public bool AddItem( int itemId )
    {
        return InventoryManager.Instance.AddItem(itemId);
    }

    /// <summary>
    /// 移除物品
    /// </summary>
    public void RemoveItem( int itemId )
    {
        InventoryManager.Instance.RemoveItem(itemId);

        //如果该物品移除后数量为0，那么销毁该物品的GameObject
        int curNum = GetItemCountById(itemId);
        if(curNum == 0)
        {
            //删除该物品的GameObject
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].GetComponent<InventoryItemCtrl>().InventoryItem.ItemId == itemId)
                {
                    GameObject tempGo = itemList[i];//暂存itemList[i]这个物体
                    itemList.RemoveAt(i);//把它从集合中除去
                    GameObject.Destroy(tempGo);//再销毁这个物体
                    return;
                }
            }
        }
    }

    /// <summary>
    /// 根据物品id获取背包中该物品的数量
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public int GetItemCountById(int itemId)
    {
        return InventoryManager.Instance.GetItemCountById(itemId);
    }

    //测试
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.P))
    //    {
    //        AddItem(6);
    //    }
    //}

}
