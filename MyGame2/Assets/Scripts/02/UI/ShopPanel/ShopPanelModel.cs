using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelModel : MonoBehaviour {

    [SerializeField]
    private int[] shopItemList;         //商店出售的商品的id集合

    public int[] ShopItemList { get { return shopItemList; } }

}
