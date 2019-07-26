using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelCtrl : MonoBehaviour {

    public static SkillPanelCtrl Instance;

    private SkillPanelModel m_SkillPanelModel;
    private SkillPanelView m_SkillPanelView;

    [SerializeField]
    private List<GameObject> tabList;            //选项卡集合(拖拽赋值)
    private List<GameObject> skillList;         //当前显示角色的技能集合
    private List<GameObject> equipedSkillList;  //当前角色装备的技能集合

    private int curIndex = -1;                  //当前选中的选项卡标号（和角色id相对应）
    private SkillItem curShowSkillItem;         //当前显示详细信息的技能

    void Awake()
    {
        Instance = this;

        Init();
    }

    void Start()
    {
        ResetTabsAndSkillInfo(0);
    }

    /// <summary>
    /// 再次显示该面板
    /// </summary>
    public void ReShow()
    {
        ResetTabsAndSkillInfo(0);
    }

    private void Init()
    {
        m_SkillPanelModel = gameObject.GetComponent<SkillPanelModel>();
        m_SkillPanelView = gameObject.GetComponent<SkillPanelView>();

        skillList = new List<GameObject>();
        equipedSkillList = new List<GameObject>();
    }

    /// <summary>
    /// 生成某一角色的所有技能的列表
    /// </summary>
    private void CreateSkillsByTabIndex( int index )
    {
        List<SkillItem> list = m_SkillPanelModel.GetSkillsByTabIndex(index);

        for( int i = 0; i < list.Count; i++)
        {
            GameObject item = GameObject.Instantiate(m_SkillPanelView.Prefab_SkillItem, m_SkillPanelView.Grid_Transform);
            item.name = "Skill";
            item.GetComponent<SkillItemCtrl>().SkillItem = list[i];
            skillList.Add(item);
        }
    }

    /// <summary>
    /// 显示对应技能的详细信息
    /// </summary>
    public void ResetSkillInfo( SkillItem item )
    {
        curShowSkillItem = item;

        PlayerKernelDataProxy player = m_SkillPanelModel.GetPlayerInfoById(curIndex);
        bool canLearn = false;
        if (player.Level >= item.LearnLevel)
            canLearn = true;
        m_SkillPanelView.SetSkillInfo(item , canLearn);
    }

    /// <summary>
    /// 重置选项卡和对应信息
    /// </summary>
    /// <param name="index"></param>
    private void ResetTabsAndSkillInfo( int index )
    {
        if (index == curIndex)
            return;

        if (curIndex != -1)
            tabList[curIndex].GetComponent<SkillTabItemCtrl>().NormalTab();         //上一个选中的选项卡变为未选中状态

        tabList[index].GetComponent<SkillTabItemCtrl>().ActiveTab();                //当前选中的选项卡变为选中状态

        curIndex = index;
        ClearCurSkills();        //清除当前技能列表
        CreateSkillsByTabIndex(index);          //显示新的技能列表
        ResetSkillInfo(skillList[0].GetComponent<SkillItemCtrl>().SkillItem);       //显示当前技能列表中第一个技能的详细信息

        ClearEquipedSkills();               //清除当前装备的技能
        ResetEquipedSkills(index);          //显示新的装备的技能
    }

    /// <summary>
    /// 清除当前显示的技能列表
    /// </summary>
    private void ClearCurSkills()
    {
        for( int i = 0; i < skillList.Count; i++)
        {
            GameObject.Destroy(skillList[i]);
        }
        skillList.Clear();
    }

    /// <summary>
    /// 更新角色装备的技能
    /// </summary>
    private void ResetEquipedSkills( int index )
    {
        List<int> skills = m_SkillPanelModel.GetEquipedSkillsByPlayerId(index);
        for( int i = 0; i < skills.Count; i++)
        {
            GameObject slot = GameObject.Instantiate(m_SkillPanelView.Prefab_EquipedSkillSlot, m_SkillPanelView.GridOfESkillSlot_Transform);
            slot.GetComponent<SkillEquipSlotCtrl>().SkillItem = m_SkillPanelModel.GetSkillItemBySkillId(index, skills[i]);
            equipedSkillList.Add(slot);
        }
    }

    /// <summary>
    /// 清除当前装备的技能
    /// </summary>
    private void ClearEquipedSkills()
    {
        for (int i = 0; i < equipedSkillList.Count; i++)
        {
            GameObject.Destroy(equipedSkillList[i]);
        }
        equipedSkillList.Clear();
    }

    /// <summary>
    /// 装备按钮点击事件
    /// </summary>
    private void OnEquipBtnClick()
    {
        m_SkillPanelModel.SkillBeEquiped(curIndex, curShowSkillItem.SkillID);   //修改玩家数据类中信息和Model中记录的SkillItem实体类中的信息

        m_SkillPanelView.HideEquipBtn();        //隐藏装备按钮
        m_SkillPanelView.ShowRemoveBtn();       //显示卸下按钮

        //重新显示装备技能
        ClearEquipedSkills();                  //清除当前装备的技能
        ResetEquipedSkills(curIndex);          //显示新的装备的技能
    }

    /// <summary>
    /// 卸下按钮点击事件
    /// </summary>
    private void OnRemoveBtnClick()
    {
        m_SkillPanelModel.SkillBeRemove(curIndex, curShowSkillItem.SkillID);   //修改玩家数据类中信息和Model中记录的SkillItem实体类中的信息

        m_SkillPanelView.HideRemoveBtn();       //隐藏卸下按钮
        m_SkillPanelView.ShowEquipBtn();        //显示装备按钮

        //重新显示装备技能
        ClearEquipedSkills();                  //清除当前装备的技能
        ResetEquipedSkills(curIndex);          //显示新的装备的技能
    }

    /// <summary>
    /// 学习按钮点击事件
    /// </summary>
    private void OnLearnBtnClick()
    {
        m_SkillPanelModel.SkillBeLearned(curIndex, curShowSkillItem.SkillID);   //修改Model中记录的SkillItem实体类中的信息

        m_SkillPanelView.HideLearnBtn();    //隐藏学习按钮
        m_SkillPanelView.ShowEquipBtn();    //显示装备按钮
    }

}
