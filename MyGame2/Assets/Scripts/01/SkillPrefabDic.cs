using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 根据id获取技能预制体
/// </summary>
public class SkillPrefabDic  {

    private Dictionary<int, GameObject> skillPrefabDic = new Dictionary<int, GameObject>();

    private static SkillPrefabDic instance;

    public static SkillPrefabDic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkillPrefabDic();
            }
            return instance;
        }      
    }

    private SkillPrefabDic()
    {
        LoadSkillPrefabs();
    }

    private void LoadSkillPrefabs()
    {
        GameObject skill1 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill1");
        skillPrefabDic.Add(1, skill1);
        GameObject skill2 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill2");
        skillPrefabDic.Add(2, skill2);
        GameObject skill3 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill3");
        skillPrefabDic.Add(3, skill3);
        GameObject skill4 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill4");
        skillPrefabDic.Add(4, skill4);
        GameObject skill5 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill5");
        skillPrefabDic.Add(5, skill5);
        GameObject skill6 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill6");
        skillPrefabDic.Add(6, skill6);
        GameObject skill7 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill7");
        skillPrefabDic.Add(7, skill7);
        GameObject skill8 = Resources.Load<GameObject>("BattleSceneSkillPrefabs/Skill8");
        skillPrefabDic.Add(8, skill8);
    }

    public GameObject GetSkillPrefabById(int skillId)
    {
        GameObject temp = null;
        skillPrefabDic.TryGetValue(skillId, out temp);
        return temp;
    }
}
