using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在技能面板左侧技能列表里的单个技能上
/// </summary>
public class SkillItemCtrl : MonoBehaviour {

    private SkillItem m_SkillItem;

    public SkillItem SkillItem
    {
        get { return m_SkillItem; }
        set { m_SkillItem = value;
            skillImage.sprite = Resources.Load<Sprite>("SkillTextures/" + m_SkillItem.Image);
            skillName.text = m_SkillItem.SkillName;
        }
    }

    private Image skillImage;
    private Text skillName;
    private Button m_Button;

    void Awake()
    {
        skillImage = transform.Find("Image").GetComponent<Image>();
        skillName = transform.Find("name").GetComponent<Text>();
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("ResetSkillInfo", m_SkillItem);
    }

}
