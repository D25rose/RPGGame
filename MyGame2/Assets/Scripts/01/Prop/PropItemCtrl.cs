using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PropItemCtrl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private InventoryItem propItem;

    private Image image;
    private Text numText;

    void Awake()
    {
        image = transform.Find("Image").GetComponent<Image>();
        numText = transform.Find("numText").GetComponent<Text>();
    }

    public void Init(InventoryItem item)
    {
        propItem = item;
        image.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + propItem.Sprite);
        numText.text = propItem.CurNum.ToString();
    }

    private void UpdatePropNum()
    {
        numText.text = propItem.CurNum.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PropPanelCtrl.Instance.ShowPropInfo(propItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PropPanelCtrl.Instance.HidePropInfo();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //使用道具，产生效果
        PropManager.Instance.UseProp(propItem.ItemId, BattleManager.Instance.CurActRole);

        //消耗道具数目
        InventoryManager.Instance.RemoveItem(propItem.ItemId);
        UpdatePropNum();

        //如果道具使用后数目为零，那么销毁该道具
        if (propItem.CurNum == 0)
        {
            GameObject.Destroy(gameObject);
            PropPanelCtrl.Instance.HidePropInfo();
        }
    }
}
