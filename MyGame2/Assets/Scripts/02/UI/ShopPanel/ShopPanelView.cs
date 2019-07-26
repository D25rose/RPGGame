using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelView : MonoBehaviour {

    private string path = "UI/ShopPanel/";

    private GameObject prefab_ShopItemSlot;

    private Transform grid_Transform;

    private Button sell_Btn;

    public GameObject Prefab_ShopItemSlot { get { return prefab_ShopItemSlot; } }

    public Transform Grid_Transform { get { return grid_Transform; } }

    public Button Sell_Btn { get { return sell_Btn; } }

    void Awake()
    {
        prefab_ShopItemSlot = Resources.Load<GameObject>(path + "ShopItemSlot");

        grid_Transform = transform.Find("Bg/Content/Grid");

        sell_Btn = transform.Find("Bg/SellBtn").GetComponent<Button>();
    }

}
