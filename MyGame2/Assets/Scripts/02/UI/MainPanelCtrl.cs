using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理主界面上的各个面板按钮
/// </summary>
public class MainPanelCtrl : MonoBehaviour {

    public static MainPanelCtrl Instance;

    [SerializeField]
    private GameObject playerInfoPanel;     //角色信息面板
    [SerializeField]
    private GameObject inventoryPanel;      //背包面板
    [SerializeField]
    private GameObject skillPanel;          //技能面板
    [SerializeField]
    private GameObject shopPanel;           //商店面板
    [SerializeField]
    private GameObject craftPanel;          //合成面板
    [SerializeField]
    private GameObject questPanel;          //任务面板
    [SerializeField]
    private GameObject archivePanel;        //存档面板

    private bool isChangingEquip = false;           //是否正在进行装备更换操作
    public bool IsChangingEquip { get { return isChangingEquip; } set { isChangingEquip = value; } }

    private bool isSellItem = false;                //是否正在出售物品
    public bool IsSellItem { get { return isSellItem; } set { isSellItem = value; } }

    void Awake()
    {
        Instance = this;
    }

    public void ShowPlayerInfoPanel()
    {
        playerInfoPanel.transform.localPosition = new Vector3(-90, 0, 0);
        PlayerInfoPanelCtrl.Instance.ReShow();
    }

    public void HidePlayerInfoPanel()
    {
        playerInfoPanel.transform.localPosition = new Vector3(-1090, 0, 0);
    }

    public void ShowInventoryPanel()
    {
        inventoryPanel.transform.localPosition = new Vector3(-90, 0, 0);
        InventoryPanelCtrl.Instance.ReShow();
        if (!isSellItem)//在出售物品时，不需要显示，因为商店面板已经显示
        {
            TootipPanelManager.Instance.ShowGoldNumTootip();    //显示金钱数
        }
    }

    public void HideInventoryPanel()
    {
        inventoryPanel.transform.localPosition = new Vector3(-1090, 0, 0);
        isChangingEquip = false;
        if (!isSellItem)//在出售物品时，不需要关闭，因为关闭背包面板后，商店面板仍要显示
        {
            TootipPanelManager.Instance.HideGoldNumTootip();    //隐藏金钱数
        }
        isSellItem = false;
    }

    public void ShowSkillPanel()
    {
        skillPanel.transform.localPosition = new Vector3(-90, 0, 0);
        SkillPanelCtrl.Instance.ReShow();
    }

    public void HideSkillPanel()
    {
        skillPanel.transform.localPosition = new Vector3(-1090, 0, 0);
    }

    public void ShowShopPanel()
    {
        shopPanel.transform.localPosition = new Vector3(-90, 0, 0);
        //ShopPanelCtrl.Instance.ReShow();
        TootipPanelManager.Instance.ShowGoldNumTootip();    //显示金钱数
    }

    public void HideShopPanel()
    {
        shopPanel.transform.localPosition = new Vector3(-1090, 0, 0);
        TootipPanelManager.Instance.HideGoldNumTootip();    //隐藏金钱数
    }

    public void ShowCraftPanel()
    {
        craftPanel.transform.localPosition = new Vector3(-90, 0, 0);
        CraftPanelCtrl.Instance.ReShow();
        TootipPanelManager.Instance.ShowGoldNumTootip();    //显示金钱数
    }

    public void HideCraftPanel()
    {
        craftPanel.transform.localPosition = new Vector3(-1090, 0, 0);
        TootipPanelManager.Instance.HideGoldNumTootip();    //隐藏金钱数
    }

    public void ShowQuestPanel()
    {
        QuestPanelCtrl.Instance.ReShow();
        questPanel.transform.localPosition = new Vector3(-90, 0, 0);
    }

    public void HideQuestPanel()
    {     
        questPanel.transform.localPosition = new Vector3(-1090, 0, 0);
    }

    public void ShowArchivePanel()
    {
        archivePanel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void HideArchivePanel()
    {
        archivePanel.transform.localPosition = new Vector3(-1090, 0, 0);
    }
}
