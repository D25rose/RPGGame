using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在合成面板选项卡上
/// </summary>
public class CraftTabItemCtrl : MonoBehaviour {

    [SerializeField]
    private int index = -1;

    private Button m_Button;

    void Awake()
    {
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("ResetTabsAndItems", index);
    }

}
