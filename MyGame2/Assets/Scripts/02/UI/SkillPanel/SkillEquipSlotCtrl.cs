using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 挂载在技能面板四个装备技能的技能槽上
/// </summary>
public class SkillEquipSlotCtrl : MonoBehaviour {

    private SkillItem m_SkillItem;

    public SkillItem SkillItem
    {
        get { return m_SkillItem; }
        set { m_SkillItem = value;
            skillImage.sprite = Resources.Load<Sprite>("SkillTextures/" + m_SkillItem.Image);
        }
    }

    private Image skillImage;       //技能图片
    private Button m_Button;

    void Awake()
    {
        skillImage = transform.Find("Image").GetComponent<Image>();
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("ResetSkillInfo", m_SkillItem);
    }

}
