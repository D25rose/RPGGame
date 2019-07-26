using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropItemTootip : MonoBehaviour {

    private Text itemName;      //物品名称
    private Text descr;     //物品介绍
    private Text price;     //物品购买价格
    private Text sellPrice; //物品出售价格

    void Awake()
    {
        itemName = transform.Find("name").GetComponent<Text>();
        descr = transform.Find("descr").GetComponent<Text>();
        price = transform.Find("price").GetComponent<Text>();
        sellPrice = transform.Find("sellPrice").GetComponent<Text>();
    }

    public void InitView(InventoryItem item)
    {
        itemName.text = item.ItemName;
        descr.text = item.Descr;
        price.text = "价格：" + item.Price.ToString();
        sellPrice.text = "出售价格：" + item.SellPrice.ToString();
    }
}
