using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoPanelCtrl : MonoBehaviour {

    public static PlayerInfoPanelCtrl Instance;

    private PlayerInfoPanelView m_PlayerInfoPanelView;
    private PlayerInfoPanelModel m_PlayerInfoPanelModel;

    private int tabNum;
    private List<GameObject> tabsList;
    //private List<GameObject> skillList;         //当前角色技能列表

    private int curIndex = -1;          //当前选中的选项卡标号
    private int CurIndex {
        get { return curIndex; }
        set { curIndex = value;
            EquipPanelCtrl.Instance.CurPlayerId = curIndex;
        }
    }


    void Awake()
    {
        Instance = this;

        Init();
    }

    void Start()
    {
        tabNum = m_PlayerInfoPanelModel.GetPlayerNum();

        CreateAllTabs();
        ResetTabsAndPlayerInfo(0);
    }

    /// <summary>
    /// 再次显示该面板
    /// </summary>
    public void ReShow()
    {
        ResetTabsAndPlayerInfo(0);
    }


    void Init()
    {
        m_PlayerInfoPanelView = gameObject.GetComponent<PlayerInfoPanelView>();
        m_PlayerInfoPanelModel = gameObject.GetComponent<PlayerInfoPanelModel>();

        tabsList = new List<GameObject>();
        //skillList = new List<GameObject>();
    }

    /// <summary>
    /// 生成所有选项卡
    /// </summary>
    private void CreateAllTabs()
    {
        for (int i = 0; i < tabNum; i++)
        {
            GameObject tempTab = GameObject.Instantiate(m_PlayerInfoPanelView.Prefab_PlayerInfoTabItem, m_PlayerInfoPanelView.Tabs_Transform);
            //需要角色的名称，根据i获得
            string playerName = m_PlayerInfoPanelModel.GetPlayerNameByTabIndex(i);
            tempTab.GetComponent<PlayerInfoTabItemCtrl>().InitTab(i, playerName);
            tabsList.Add(tempTab);
        }
    }

    /// <summary>
    /// 重置选项卡和角色信息
    /// </summary>
    private void ResetTabsAndPlayerInfo( int index )
    {
        //选项卡状态切换
        for( int i = 0; i < tabsList.Count; i++)
        {
            tabsList[i].GetComponent<PlayerInfoTabItemCtrl>().NormalTab();
        }
        tabsList[index].GetComponent<PlayerInfoTabItemCtrl>().ActiveTab();

        CurIndex = index;
        PlayerKernelDataProxy player = m_PlayerInfoPanelModel.GetPlayerInfoByTabIndex(index);
        m_PlayerInfoPanelView.SetPlayerInfo(player);            //设置角色基础信息显示
        EquipPanelCtrl.Instance.ShowCurPlayerEquips(player.Id);

    }

    /*
    /// <summary>
    /// 设置角色技能信息显示
    /// </summary>
    private void SetPlayerSkills( string[] skills )
    {
        ResetSkills();

        for( int i = 0; i < skills.Length; i++)
        {
            int id = int.Parse(skills[i]);
            if (id != 0)
            {
                SkillItem temp = m_PlayerInfoPanelModel.GetSkillItemByID(id);
                GameObject tempSkill = GameObject.Instantiate(m_PlayerInfoPanelView.Prefab_PlayerInfoSkillItem, m_PlayerInfoPanelView.SkillArea_Transform);
                tempSkill.GetComponent<SkillItemCtrl>().Init(temp);
                skillList.Add(tempSkill);
            }
        }

    }

    /// <summary>
    /// 清空角色技能列表
    /// </summary>
    private void ResetSkills()
    {
        for( int i = 0; i < skillList.Count; i++)
        {
            GameObject.Destroy(skillList[i]);
        }
        skillList.Clear();
    }
    */
   
}
