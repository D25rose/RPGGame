using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemTootip : MonoBehaviour {

    private Text itemName;      //物品名称
    private Text descr;     //物品介绍
    private Text property;  //物品增加属性
    private Text price;     //物品购买价格
    private Text sellPrice; //物品出售价格

    void Awake()
    {
        itemName = transform.Find("name").GetComponent<Text>();
        descr = transform.Find("descr").GetComponent<Text>();
        property = transform.Find("property").GetComponent<Text>();
        price = transform.Find("price").GetComponent<Text>();
        sellPrice = transform.Find("sellPrice").GetComponent<Text>();
    }

    public void InitView(InventoryItem item)
    {
        itemName.text = item.ItemName;
        descr.text = item.Descr;
        property.text = GetProperty(item);
        price.text = "价格：" + item.Price.ToString();
        sellPrice.text = "出售价格：" + item.SellPrice.ToString();
    }

    /// <summary>
    /// 获取装备的增加属性的显示内容
    /// </summary>
    private string GetProperty( InventoryItem item )
    {
        string content = "";
        if( item.EquipHp != 0)
        {
            content += "生命值 +" + item.EquipHp.ToString() + "\n";
        }
        if (item.EquipMp != 0)
        {
            content += "蓝量 +" + item.EquipMp.ToString() + "\n";
        }
        if (item.EquipAttack != 0)
        {
            content += "攻击力 +" + item.EquipAttack.ToString() + "\n";
        }
        if (item.EquipDefense != 0)
        {
            content += "防御力 +" + item.EquipDefense.ToString() + "\n";
        }
        if (item.EquipSpeed != 0)
        {
            content += "速度 +" + item.EquipSpeed.ToString();
        }

        return content;
    }

}
