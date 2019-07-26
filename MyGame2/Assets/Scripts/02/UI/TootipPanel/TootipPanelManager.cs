using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有消息提示框的管理器
/// </summary>
public class TootipPanelManager : MonoBehaviour {

    public static TootipPanelManager Instance;

    [SerializeField]
    private Canvas canvas;

    private GameObject warningTootip;
    private GameObject itemInfoTootip;
    private GameObject chooseNumTootip;
    private GameObject goldNumTootip;
    private GameObject questDialogueTootip;

    private bool isItemInfoShow = false;        //物品详细信息弹窗是否正在显示
    private Vector2 offset = new Vector2(20, -20);      //弹窗显示位置和相对鼠标位置的偏移

    void Awake()
    {
        Instance = this;

        Init();
    }

    private void Init()
    {
        warningTootip = transform.Find("WarningTootip").gameObject;
        itemInfoTootip = transform.Find("ItemInfoTootip").gameObject;
        chooseNumTootip = transform.Find("ChooseNumTootip").gameObject;
        goldNumTootip = transform.Find("GoldNumTootip").gameObject;
        questDialogueTootip = transform.Find("QuestDialogueTootip").gameObject;
    }

    void Update()
    {
        if (isItemInfoShow)//当物品详细信息弹窗显示时，跟随鼠标
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>() , Input.mousePosition, null, out pos);
            itemInfoTootip.GetComponent<ItemInfoTootip>().SetLocalPos(pos + offset);
        }
    }

    /// <summary>
    /// 显示警告提示框
    /// </summary>
    /// <param name="content">警告内容</param>
    public void ShowWarningTootip( string content )
    {
        warningTootip.transform.localPosition = Vector3.zero;
        warningTootip.GetComponent<WarningTootip>().Show(content);
    }
    
    /// <summary>
    /// 显示物品详细信息
    /// </summary>
    public void ShowItemInfoTootip( InventoryItem item )
    {
        isItemInfoShow = true;
        itemInfoTootip.GetComponent<ItemInfoTootip>().ShowItemInfo(item);
    }

    /// <summary>
    /// 隐藏物品详细信息
    /// </summary>
    public void HideItemInfoTootip()
    {
        isItemInfoShow = false;
        itemInfoTootip.GetComponent<ItemInfoTootip>().HideItemInfo();
    }

    /// <summary>
    /// 显示选择数量的弹窗
    /// </summary>
    public void ShowChooseNumTootip( int price , int maxNum )
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, null, out pos);
        chooseNumTootip.GetComponent<ChooseNumTootip>().ShowChooseNum(price, maxNum , pos + offset);
    }

    /// <summary>
    /// 显示玩家金钱数
    /// </summary>
    public void ShowGoldNumTootip()
    {
        goldNumTootip.GetComponent<GoldNumTootip>().ShowGoldNum(new Vector3( -400 , 295 , 0 ));
    }

    /// <summary>
    /// 隐藏玩家金钱数
    /// </summary>
    public void HideGoldNumTootip()
    {
        goldNumTootip.transform.localPosition = new Vector3(-1090, 0, 0);
    }

    /// <summary>
    /// 和任务发起人对话的对话弹窗
    /// </summary>
    public void ShowQuestDialogueTootip(QuestItem quest)
    {
        questDialogueTootip.transform.localPosition = new Vector3(0, -220, 0);
        questDialogueTootip.GetComponent<QuestDialogueTootip>().QuestItem = quest;
    }

    public void HideQuestDialogueTootip()
    {
        questDialogueTootip.transform.localPosition = new Vector3(1200, -220, 0);
    }

    /// <summary>
    /// 和任务中间者对话的对话弹窗
    /// </summary>
    public void ShowTalkWithRequireNPCTootip(QuestItem.QuestNPC npc)
    {
        questDialogueTootip.transform.localPosition = new Vector3(0, -220, 0);
        questDialogueTootip.GetComponent<QuestDialogueTootip>().TalkWithQuestRequireNPC(npc);
    }

    /// <summary>
    /// 和任务提交者对话的对话弹窗
    /// </summary>
    public void ShowTalkWithOverNPCTootip(QuestItem quest)
    {
        questDialogueTootip.transform.localPosition = new Vector3(0, -220, 0);
        questDialogueTootip.GetComponent<QuestDialogueTootip>().TalkWithQuestOverNPC(quest);
    }
}

