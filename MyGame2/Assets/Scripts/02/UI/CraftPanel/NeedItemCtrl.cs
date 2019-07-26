using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在合成面板里一条需要的材料项上
/// </summary>
public class NeedItemCtrl : MonoBehaviour {

    private int itemId;//该材料的物品id

    private int needNum;//需要的数量

    private Text itemName;//需要的物品的名称
    private Text text_NeedNum;//需要的数量
    private Text have;//已拥有的数量

    void Awake()
    {
        itemName = transform.Find("name").GetComponent<Text>();
        text_NeedNum = transform.Find("num").GetComponent<Text>();
        have = transform.Find("have").GetComponent<Text>();

        CraftNumAreaCtrl.eventUpdateNeedItemNum += CraftNumAreaCtrl_eventUpdateNeedItemNum;
        CraftNumAreaCtrl.eventUpdateNeedItemHave += CraftNumAreaCtrl_eventUpdateNeedItemHave;
    }

    private void CraftNumAreaCtrl_eventUpdateNeedItemNum(int craftNum)
    {
        this.text_NeedNum.text = (needNum * craftNum).ToString();
    }

    private void CraftNumAreaCtrl_eventUpdateNeedItemHave()
    {
        int haveNum = InventoryPanelCtrl.Instance.GetItemCountById(itemId);
        have.text = haveNum.ToString();
    }

    public void InitView( int itemId , string itemName , int needNum , int haveNum )
    {
        this.itemId = itemId;
        this.itemName.text = itemName;
        this.needNum = needNum;
        text_NeedNum.text = needNum.ToString();
        have.text = haveNum.ToString();
    }
	
    void OnDestroy()
    {
        CraftNumAreaCtrl.eventUpdateNeedItemNum -= CraftNumAreaCtrl_eventUpdateNeedItemNum;
        CraftNumAreaCtrl.eventUpdateNeedItemHave -= CraftNumAreaCtrl_eventUpdateNeedItemHave;
    }

}

