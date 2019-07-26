using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RewardItemCtrl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    private InventoryItem m_InventroyItem;

    private Image itemImage;
    private Text itemNum;

    void Awake()
    {
        itemImage = transform.Find("Image").GetComponent<Image>();
        itemNum = transform.Find("num").GetComponent<Text>();
    }
	
    public void Init( int itemId , int itemNum )
    {
        m_InventroyItem = GlobalInventoryItemManager.Instance.GetItemById(itemId);
        itemImage.sprite = Resources.Load<Sprite>("InventoryItemTextures/" + m_InventroyItem.Sprite);
        this.itemNum.text = itemNum.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TootipPanelManager.Instance.ShowItemInfoTootip(m_InventroyItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TootipPanelManager.Instance.HideItemInfoTootip();
    }

}
