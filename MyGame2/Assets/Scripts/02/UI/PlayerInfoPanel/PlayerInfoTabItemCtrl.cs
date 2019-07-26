using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在单个tab预制体上
/// </summary>
public class PlayerInfoTabItemCtrl : MonoBehaviour {

    private Transform m_Transfrom;

    private Text m_Name;
    private Image m_Image;
    private Button m_Btn;

    private int index = -1;             //选项卡标号

    void Awake()
    {
        m_Transfrom = gameObject.GetComponent<Transform>();
        m_Name = m_Transfrom.Find("name").GetComponent<Text>();
        m_Image = gameObject.GetComponent<Image>();
        m_Btn = gameObject.GetComponent<Button>();

        m_Btn.onClick.AddListener(OnButtonClick);
    }

    /// <summary>
    /// 初始化选项卡信息
    /// </summary>
    public void InitTab( int index , string playerName )
    {
        this.index = index;
        gameObject.name = "Tab" + index;
        m_Name.text = playerName;
    }

    /// <summary>
    /// 选项卡默认状态（没被按下）
    /// </summary>
    public void NormalTab()
    {
        m_Image.color = new Color(253/255f, 255/255f, 98/255f ,1f);
    }

    /// <summary>
    /// 选项卡被按下状态
    /// </summary>
    public void ActiveTab()
    {
        m_Image.color = new Color(255/255f, 169/255f, 77/255f,1f);
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("ResetTabsAndPlayerInfo", index);
    }

}
