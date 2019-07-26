using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager {

    #region 单例
    private static SkillManager instance;

    public static SkillManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkillManager();
            }
            return instance;
        }
    }
    #endregion

    private List<SkillItem> saberSkillList;          //saber角色所有技能
    private List<SkillItem> archerSkillList;         //archer角色所有技能
    private List<SkillItem> casterSkillList;         //caster角色所有技能

    public List<SkillItem> SaberSkillList { get { return saberSkillList; } }
    public List<SkillItem> ArcherSkillList { get { return archerSkillList; } }
    public List<SkillItem> CasterSkillList { get { return casterSkillList; } }
    
    private SkillManager()
    {
        
    }

    public void LoadSkillData()
    {
        saberSkillList = GetSkillsByPlayerId(0);
        archerSkillList = GetSkillsByPlayerId(1);
        casterSkillList = GetSkillsByPlayerId(2);
    }

    /// <summary>
    /// 根据角色id从Json文件中读出该角色的技能列表，存储在该脚本中
    /// </summary>
    private List<SkillItem> GetSkillsByPlayerId(int id)
    {
        string fileName = "SkillData" + id;
        return JsonTools.GetJsonList<SkillItem>(fileName);
    }
}
