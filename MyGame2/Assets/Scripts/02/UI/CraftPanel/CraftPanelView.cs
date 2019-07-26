using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelView : MonoBehaviour {

    private string path = "UI/CraftPanel/";

    private Transform craftItemGrid_Transform;//可合成物品的Grid
    private Transform needItemGrid_Transform;//材料项的Grid

    private GameObject prefab_CraftItem;//可合成物品预制体
    private GameObject prefab_NeedItem;//合成物品时的单个材料项

    private Text text_CraftingItemName;//正要合成的物品的名称显示 

    private CraftNumAreaCtrl m_CraftNumAreaCtrl;//合成面板中关于合成数量和价格以及合成按钮的控制脚本

    public Transform CraftItemGrid_Transform { get { return craftItemGrid_Transform; } }
    public Transform NeedItemGrid_Transform { get { return needItemGrid_Transform; } }

    public GameObject Prefab_CraftItem { get { return prefab_CraftItem; } }
    public GameObject Prefab_NeedItem { get { return prefab_NeedItem; } }

    public Text Text_CraftingItemName { get { return text_CraftingItemName; } }

    public CraftNumAreaCtrl M_CraftNumAreaCtrl { get { return m_CraftNumAreaCtrl; } }

    void Awake()
    {
        craftItemGrid_Transform = transform.Find("Content/ItemArea/content/Grid");
        needItemGrid_Transform = transform.Find("Content/NeedsArea/content/Grid");

        prefab_CraftItem = Resources.Load<GameObject>(path + "CraftItem");
        prefab_NeedItem = Resources.Load<GameObject>(path + "NeedItem");

        text_CraftingItemName = transform.Find("Content/NeedsArea/CraftItemName").GetComponent<Text>();

        m_CraftNumAreaCtrl = transform.Find("Content/CraftNumArea").GetComponent<CraftNumAreaCtrl>();
    }

}
