using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 技能UI控制，挂载在技能按钮上
/// </summary>
public class SkillBtn : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler {

    private GameObject prefab_InfoUI;

    private Text skillName;                     //技能名称
    private Image skillImage;                   //技能图标
    private string info = null;                 //技能介绍信息
    private GameObject infoUI = null;           //该技能的技能信息介绍UI物体

    private Button m_Button;

    void Awake()
    {
        prefab_InfoUI = Resources.Load<GameObject>("SkillInfoUI");

        skillName = transform.Find("SkillName").GetComponent<Text>();
        skillImage = transform.Find("SkillImage").GetComponent<Image>();
        m_Button = gameObject.GetComponent<Button>();
    }

    /// <summary>
    /// 更新技能面板UI信息显示以及按钮事件绑定
    /// </summary>
    public void UpdateSkill( SkillBase skill , UnityEngine.Events.UnityAction useSkill)
    {
        //如果该技能位置没有技能，那么隐藏
        if (skill == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            this.skillName.text = skill.skillName;
            this.info = skill.skillDescr + "\n威力：" + skill.attack.ToString();
            skillImage.sprite = Resources.Load<Sprite>("SkillTextures/" + skill.id.ToString());
            m_Button.onClick.RemoveAllListeners();
            m_Button.onClick.AddListener(useSkill);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (infoUI == null)
        {
            infoUI = GameObject.Instantiate(prefab_InfoUI, transform);
        }
        else
        {
            infoUI.SetActive(true);
        }
        infoUI.GetComponent<SkillInfoUI>().Init(info);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoUI.SetActive(false);
    }
}
