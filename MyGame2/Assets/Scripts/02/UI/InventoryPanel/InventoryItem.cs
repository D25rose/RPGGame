using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem  {

    //更新物品数量的委托
    public event GlobalParamters.del_VoidInt eventUpdateItemNum;

    private int itemId;             //物品id
    private string itemName;        //物品名称
    private string type;            //物品类型
    private int equipType;          //装备的部位(0:武器，1：头部，2：护手，3：上装，4：下装，5：足具)
    private int curNum;             //当前数量
    private string sprite;          //物品图片
    private int equipHp;            //装备提升血量
    private int equipMp;            //装备提升蓝量
    private int equipAttack;        //装备提升攻击
    private int equipDefense;       //装备提升防御
    private int equipSpeed;         //装备提升速度

    private string descr;           //物品介绍
    private int price;              //物品购买价格
    private int sellPrice;          //物品出售价格

    private int recoverHp;          //回复血量的值
    private int recoverMp;          //回复蓝量的值

    private Drawing[] drawings;      //合成该物品需要的材料
    private int drawingPrice;       //合成该物品需要的金钱数目

    public class Drawing
    {
        int itemId;
        int itemCount;

        public int ItemId { get { return itemId; } set { itemId = value; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
    }

    public InventoryItem() { }

    public InventoryItem(int itemId, string itemName, string type , int equipType, int curNum , string sprite, int equipHp, int equipMp, int equipAttack, int equipDefense, int equipSpeed,
        string descr, int price, int sellPrice, int recoverHp, int recoverMp, Drawing[] drawings, int drawingPrice)
    {
        this.itemId = itemId;
        this.itemName = itemName;
        this.type = type;
        this.equipType = equipType;
        this.curNum = curNum;
        this.sprite = sprite;
        this.equipHp = equipHp;
        this.equipMp = equipMp;
        this.equipAttack = equipAttack;
        this.equipDefense = equipDefense;
        this.equipSpeed = equipSpeed;
        this.descr = descr;
        this.price = price;
        this.sellPrice = sellPrice;
        this.recoverHp = recoverHp;
        this.recoverMp = recoverMp;
        this.drawings = drawings;
        this.drawingPrice = drawingPrice;
    }

    public int ItemId
    {
        get
        {
            return itemId;
        }

        set
        {
            itemId = value;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public int CurNum
    {
        get
        {
            return curNum;
        }

        set
        {
            curNum = value;
            if (eventUpdateItemNum != null)
                eventUpdateItemNum(curNum);
        }
    }

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    public int EquipType
    {
        get
        {
            return equipType;
        }

        set
        {
            equipType = value;
        }
    }

    public int EquipHp
    {
        get
        {
            return equipHp;
        }

        set
        {
            equipHp = value;
        }
    }

    public int EquipMp
    {
        get
        {
            return equipMp;
        }

        set
        {
            equipMp = value;
        }
    }

    public int EquipAttack
    {
        get
        {
            return equipAttack;
        }

        set
        {
            equipAttack = value;
        }
    }

    public int EquipDefense
    {
        get
        {
            return equipDefense;
        }

        set
        {
            equipDefense = value;
        }
    }

    public int EquipSpeed
    {
        get
        {
            return equipSpeed;
        }

        set
        {
            equipSpeed = value;
        }
    }

    public string Descr
    {
        get
        {
            return descr;
        }

        set
        {
            descr = value;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int SellPrice
    {
        get
        {
            return sellPrice;
        }

        set
        {
            sellPrice = value;
        }
    }

    public int RecoverHp
    {
        get
        {
            return recoverHp;
        }

        set
        {
            recoverHp = value;
        }
    }

    public int RecoverMp
    {
        get
        {
            return recoverMp;
        }

        set
        {
            recoverMp = value;
        }
    }

    public Drawing[] Drawings
    {
        get
        {
            return drawings;
        }

        set
        {
            drawings = value;
        }
    }

    public int DrawingPrice
    {
        get
        {
            return drawingPrice;
        }

        set
        {
            drawingPrice = value;
        }
    }
}
