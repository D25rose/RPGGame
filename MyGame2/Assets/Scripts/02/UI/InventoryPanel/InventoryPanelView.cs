using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelView : MonoBehaviour {

    private string path = "UI/InventoryPanel/";

    private GameObject prefab_ItemSlot;         //物品槽
    private GameObject prefab_InventoryItem;         //物品预制体

    private Transform m_transform;
    private Transform grid_Transform;           //所有物品槽的父物体

    public GameObject Prefab_ItemSlot { get { return prefab_ItemSlot; } }
    public GameObject Prefab_InventoryItem { get { return prefab_InventoryItem; } }

    public Transform Grid_Transform { get { return grid_Transform; } }
    public Transform M_transform { get { return m_transform; } }

    void Awake()
    {
        prefab_ItemSlot = Resources.Load<GameObject>( path + "ItemSlot");
        prefab_InventoryItem = Resources.Load<GameObject>(path + "InventoryItem");

        m_transform = gameObject.GetComponent<Transform>();
        grid_Transform = m_transform.Find("Content/SlotGrid");
    }

}
