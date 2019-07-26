using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在选项卡物体上
/// </summary>
public class TabItemCtrl : MonoBehaviour {

    [SerializeField]
    private int index = -1;

    private Button m_Button;
    private Image m_Image;

    private Sprite activeSprite;        //选中状态下按钮图片
    private Sprite normalSprite;        //未选中状态下按钮图片

    void Awake()
    {
        activeSprite = Resources.Load<Sprite>("UI/InventoryPanel/TextBTN_Big_Pressed");
        normalSprite = Resources.Load<Sprite>("UI/InventoryPanel/TextBTN_Big");

        m_Button = gameObject.GetComponent<Button>();
        m_Image = gameObject.GetComponent<Image>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    /// <summary>
    /// 变为选中状态
    /// </summary>
    public void ActiveTab()
    {
        m_Image.sprite = activeSprite;
    }

    /// <summary>
    /// 变为未选中状态
    /// </summary>
    public void NormalTab()
    {
        m_Image.sprite = normalSprite;
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("ResetTabsAndItems", index );
    }

}
