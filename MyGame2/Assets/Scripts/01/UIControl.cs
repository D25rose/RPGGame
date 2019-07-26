using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI控制
/// </summary>
public class UIControl : MonoBehaviour {

    public static UIControl Instance;

    private GameObject battlePanel;              //战斗操作面板

    private SkillBtn skillBtn1;                 //技能1按钮脚本
    private SkillBtn skillBtn2;                 //技能2按钮脚本
    private SkillBtn skillBtn3;                 //技能3按钮脚本
    private SkillBtn skillBtn4;                 //技能4按钮脚本

    void Awake()
    {
        Instance = this;

        battlePanel = GameObject.Find("Canvas/BattlePanel");

        skillBtn1 = battlePanel.transform.Find("SkillPanel/Skill1").GetComponent<SkillBtn>();
        skillBtn2 = battlePanel.transform.Find("SkillPanel/Skill2").GetComponent<SkillBtn>();
        skillBtn3 = battlePanel.transform.Find("SkillPanel/Skill3").GetComponent<SkillBtn>();
        skillBtn4 = battlePanel.transform.Find("SkillPanel/Skill4").GetComponent<SkillBtn>();

    }

    void Start()
    {
        BattleManager.Instance.OnNewRound += this.OnNewRound;
    }

    /// <summary>
    /// 更新成对应角色的技能面板信息显示以及技能按钮注册
    /// </summary>
    public void UpdateSkillPanel( GameObject role )
    {
        PlayerBase playerBase = role.GetComponent<PlayerBase>();

        skillBtn1.UpdateSkill(playerBase.skills[0] , playerBase.UseSkill1);
        skillBtn2.UpdateSkill(playerBase.skills[1] , playerBase.UseSkill2);
        skillBtn3.UpdateSkill(playerBase.skills[2] , playerBase.UseSkill3);
        skillBtn4.UpdateSkill(playerBase.skills[3] , playerBase.UseSkill4);
    }


    private void OnNewRound( string curRoundName)
    {
        if( curRoundName == "Player")
        {
            battlePanel.SetActive(true);
        }
        else
        {
            battlePanel.SetActive(false);
        }
    }

}
