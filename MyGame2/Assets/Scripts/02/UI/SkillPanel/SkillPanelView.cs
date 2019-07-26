using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelView : MonoBehaviour {

    private string path = "UI/SkillPanel/";

    private GameObject prefab_SkillItem;
    private GameObject prefab_EquipedSkillSlot;

    private Transform m_Transfrom;
    private Transform grid_Transform;                       //技能列表父物体
    private Transform gridOfESkillSlot_Transform;           //四个技能槽的父物体

    //技能信息显示UI
    private Transform skillInfo_Transform;
    private Text skillName;
    private Text skillDescr;
    private Text skillAttack;
    private Text mpConsume;
    private Text learnLevel;
    private Button equipBtn;
    private Button removeBtn;
    private Button learnBtn;

    public Transform M_Transform { get { return m_Transfrom; } }
    public Transform Grid_Transform { get { return grid_Transform; } }
    public Transform GridOfESkillSlot_Transform { get { return gridOfESkillSlot_Transform; } }

    public GameObject Prefab_SkillItem { get { return prefab_SkillItem; } }
    public GameObject Prefab_EquipedSkillSlot { get { return prefab_EquipedSkillSlot; } }

    void Awake()
    {
        prefab_SkillItem = Resources.Load<GameObject>(path + "SkillItem");
        prefab_EquipedSkillSlot = Resources.Load<GameObject>(path + "EquipedSkillSlot");

        m_Transfrom = gameObject.GetComponent<Transform>();
        grid_Transform = m_Transfrom.Find("Content/Left/Content/SkillGrid");
        gridOfESkillSlot_Transform = m_Transfrom.Find("Content/Right/EquipedSkills/skills");

        skillInfo_Transform = m_Transfrom.Find("Content/Right/SkillInfo");
        skillName = skillInfo_Transform.Find("skillName").GetComponent<Text>();
        skillDescr = skillInfo_Transform.Find("skillDescr").GetComponent<Text>();
        skillAttack = skillInfo_Transform.Find("skillAttack").GetComponent<Text>();
        mpConsume = skillInfo_Transform.Find("mpConsume").GetComponent<Text>();
        learnLevel = skillInfo_Transform.Find("learnLevel").GetComponent<Text>();
        equipBtn = skillInfo_Transform.Find("equipBtn").GetComponent<Button>();
        removeBtn = skillInfo_Transform.Find("removeBtn").GetComponent<Button>();
        learnBtn = skillInfo_Transform.Find("learnBtn").GetComponent<Button>();


    }

    /// <summary>
    /// 设置技能具体信息UI显示
    /// </summary>
    public void SetSkillInfo( SkillItem item , bool canLearn )
    {
        skillName.text = item.SkillName;
        skillDescr.text = item.SkillDescr;
        skillAttack.text = "威力：" + item.Attack.ToString();
        mpConsume.text = "消耗蓝量：" + item.MpConsume.ToString();
        learnLevel.text = "学习等级：" + item.LearnLevel.ToString();

        if( canLearn && !item.IsLearn)//只有在角色达到了技能学习等级且未学习该技能时才显示
        {
            if (learnBtn.gameObject.activeSelf == false)
                learnBtn.gameObject.SetActive(true);
        }
        else
        {
            if (learnBtn.gameObject.activeSelf == true)
                learnBtn.gameObject.SetActive(false);
        }

        if(item.IsEquip)//如果该技能已装备，那么隐藏装备按钮，显示卸下按钮
        {
            if (equipBtn.gameObject.activeSelf == true)
                equipBtn.gameObject.SetActive(false);
            if (removeBtn.gameObject.activeSelf == false)
                removeBtn.gameObject.SetActive(true);
        }
        else if( item.IsEquip == false  && item.IsLearn == true )//如果该技能未装备且已学习，那么显示装备按钮，隐藏卸下按钮
        {
            if (equipBtn.gameObject.activeSelf == false)
                equipBtn.gameObject.SetActive(true);
            if (removeBtn.gameObject.activeSelf == true)
                removeBtn.gameObject.SetActive(false);
        }
        else if (item.IsEquip == false && item.IsLearn == false)//如果该技能未装备且为学习，那么隐藏装备按钮，隐藏卸下按钮
        {
            if (equipBtn.gameObject.activeSelf == true)
                equipBtn.gameObject.SetActive(false);
            if (removeBtn.gameObject.activeSelf == true)
                removeBtn.gameObject.SetActive(false);
        }
    }

    public void HideEquipBtn()
    {
        equipBtn.gameObject.SetActive(false);
    }

    public void ShowEquipBtn()
    {
        equipBtn.gameObject.SetActive(true);
    }

    public void ShowRemoveBtn()
    {
        removeBtn.gameObject.SetActive(true);
    }

    public void HideRemoveBtn()
    {
        removeBtn.gameObject.SetActive(false);
    }

    public void HideLearnBtn()
    {
        learnBtn.gameObject.SetActive(false);
    }

}
