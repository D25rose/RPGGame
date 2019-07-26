using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在合成面板右侧数量选择和合成价格的父物体上
/// </summary>
public class CraftNumAreaCtrl : MonoBehaviour {

    //改变合成数目时，更新每条合成材料项里的需要数目
    public static event GlobalParamters.del_VoidInt eventUpdateNeedItemNum;
    //每次合成完后，更新每条合成材料项里的拥有数目
    public static event GlobalParamters.del_Void eventUpdateNeedItemHave;

    private InventoryItem craftItem;//要合成物品
    public InventoryItem CraftItem
    {
        get { return craftItem; }
        set { craftItem = value;
            Num = 1;//每次选择一个合成物品后置合成数量默认为1
        }
    }

    private int num;    //合成数目
    public int Num
    {
        get { return num; }
        set { num = value;
            text_num.text = num.ToString();
            text_Price.text = (num * craftItem.DrawingPrice).ToString();//随数量改变更新合成总价
            eventUpdateNeedItemNum(num);//更新每条材料项里的需求数量
        }
    }

    private Button btn_Left;//减少合成数目的按钮
    private Text text_num;//合成数目
    private Button btn_Right;//增加合成数目的按钮
    private Text text_Price;//合成总价
    private Button btn_CraftBtn;//合成按钮 

    void Awake()
    {
        btn_Left = transform.Find("ChooseNumArea/Left/Arrow").GetComponent<Button>();
        btn_Right = transform.Find("ChooseNumArea/Right/Arrow").GetComponent<Button>();
        text_num = transform.Find("ChooseNumArea/Num").GetComponent<Text>();
        text_Price = transform.Find("Price/num").GetComponent<Text>();
        btn_CraftBtn = transform.Find("CraftBtn").GetComponent<Button>();

        btn_Left.onClick.AddListener(OnLeftBtnClick);
        btn_Right.onClick.AddListener(OnRightBtnClick);
        btn_CraftBtn.onClick.AddListener(OnCraftBtnClick);
    }

    private void OnLeftBtnClick()
    {
        Num--;
        if (Num < 1)
            Num = 1;
    }

    private void OnRightBtnClick()
    {
        Num++;
    }

    /// <summary>
    /// 合成按钮点击事件
    /// </summary>
    private void OnCraftBtnClick()
    {
        bool isSuccess = CraftPanelCtrl.Instance.CraftItem(craftItem, num);
        if (isSuccess)
        {
            Num = 1;//合成成功后置合成数量为1
            eventUpdateNeedItemHave();//更新材料项里的拥有数目
        }
    }

}
