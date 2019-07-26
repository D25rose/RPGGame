using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPanelCtrl : MonoBehaviour {

    public static PropPanelCtrl Instance;

    private GameObject prefab_PropItem;

    private GameObject propInfoUI;

    private Transform content_Transform;

    private List<GameObject> propItemList;

    void Awake()
    {
        Instance = this;

        prefab_PropItem = Resources.Load<GameObject>("UI/PropPanel/PropItem");
        propInfoUI = transform.parent.parent.Find("PropInfoUI").gameObject;
        content_Transform = transform.Find("Content");

        propItemList = new List<GameObject>();
    }

    void Start()
    {
        ShowAllProps();
    }

    private void ShowAllProps()
    {
        foreach(InventoryItem item in InventoryManager.Instance.ConsumeItemList)
        {
            GameObject temp = GameObject.Instantiate(prefab_PropItem, content_Transform);
            temp.GetComponent<PropItemCtrl>().Init(item);
            propItemList.Add(temp);
        }
    }

    public void ShowPropInfo(InventoryItem item)
    {
        propInfoUI.SetActive(true);
        propInfoUI.GetComponent<PropInfoUICtrl>().SetPropInfo(item);
    }

    public void HidePropInfo()
    {
        propInfoUI.SetActive(false);
    }
}
