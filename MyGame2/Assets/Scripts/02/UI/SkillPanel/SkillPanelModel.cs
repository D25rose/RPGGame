using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelModel : MonoBehaviour {

    private List<SkillItem> saberSkillList;          //saber角色所有技能
    private List<SkillItem> archerSkillList;         //archer角色所有技能
    private List<SkillItem> casterSkillList;         //caster角色所有技能

    void Awake()
    {
        saberSkillList = SkillManager.Instance.SaberSkillList;
        archerSkillList = SkillManager.Instance.ArcherSkillList;
        casterSkillList = SkillManager.Instance.CasterSkillList;
    }

    /// <summary>
    /// 根据选项卡id（和角色id对应）获取该角色的技能列表
    /// </summary>
    public List<SkillItem> GetSkillsByTabIndex( int index )
    {
        switch (index)
        {
            case 0:
                return saberSkillList;
            case 1:
                return archerSkillList;
            case 2:
                return casterSkillList;
        }
        return null;
    }

    /// <summary>
    /// 根据角色id获取该角色当前装备的技能
    /// </summary>
    public List<int> GetEquipedSkillsByPlayerId( int id )
    {
        List<int> skills = TeamManager.Instance.GetPlayerById(id).Skills;
        return skills;
    }

    /// <summary>
    /// 根据角色id获取角色核心类信息
    /// </summary>
    /// <returns></returns>
    public PlayerKernelDataProxy GetPlayerInfoById( int id )
    {
        return TeamManager.Instance.GetPlayerById(id);
    }

    /// <summary>
    /// 根据技能id从对应角色的技能集合中找出对应技能
    /// </summary>
    /// <param name="playerId">角色id（和选项卡id对应）</param>
    /// <param name="skillId">技能id</param>
    /// <returns></returns>
    public SkillItem GetSkillItemBySkillId( int playerId , int skillId)
    {
        switch (playerId)
        {
            case 0:
                for( int i = 0; i < saberSkillList.Count; i++)
                {
                    if (saberSkillList[i].SkillID == skillId)
                        return saberSkillList[i];
                }
                break;
            case 1:
                for (int i = 0; i < archerSkillList.Count; i++)
                {
                    if (archerSkillList[i].SkillID == skillId)
                        return archerSkillList[i];
                }
                break;
            case 2:
                for (int i = 0; i < casterSkillList.Count; i++)
                {
                    if (casterSkillList[i].SkillID == skillId)
                        return casterSkillList[i];
                }
                break;
        }
        return null;
    }

    /// <summary>
    /// 该技能被装备
    /// </summary>
    /// <param name="playerId">角色id</param>
    /// <param name="skillId">技能id</param>
    public void SkillBeEquiped(int playerId, int skillId)
    {
        PlayerKernelDataProxy player = GetPlayerInfoById(playerId);
        if (player.Skills.Count >= 4)               //已装备4个技能，不能再装备
        {
            Debug.Log("最多只能装备四个技能");
            return;
        }
        player.Skills.Add(skillId);                            //修改玩家数据类中的已装备技能

        switch (playerId)
        {
            case 0:
                for (int i = 0; i < saberSkillList.Count; i++)
                {
                    if (saberSkillList[i].SkillID == skillId)
                        saberSkillList[i].IsEquip = true;
                }
                break;
            case 1:
                for (int i = 0; i < archerSkillList.Count; i++)
                {
                    if (archerSkillList[i].SkillID == skillId)
                        archerSkillList[i].IsEquip = true;
                }
                break;
            case 2:
                for (int i = 0; i < casterSkillList.Count; i++)
                {
                    if (casterSkillList[i].SkillID == skillId)
                        casterSkillList[i].IsEquip = true;
                }
                break;
        }
    }

    /// <summary>
    /// 该技能被卸下
    /// </summary>
    /// <param name="playerId">角色id</param>
    /// <param name="skillId">技能id</param>
    public void SkillBeRemove(int playerId, int skillId)
    {
        PlayerKernelDataProxy player = GetPlayerInfoById(playerId);
        player.Skills.Remove(skillId);                            //修改玩家数据类中的已装备技能

        switch (playerId)
        {
            case 0:
                for (int i = 0; i < saberSkillList.Count; i++)
                {
                    if (saberSkillList[i].SkillID == skillId)
                        saberSkillList[i].IsEquip = false;
                }
                break;
            case 1:
                for (int i = 0; i < archerSkillList.Count; i++)
                {
                    if (archerSkillList[i].SkillID == skillId)
                        archerSkillList[i].IsEquip = false;
                }
                break;
            case 2:
                for (int i = 0; i < casterSkillList.Count; i++)
                {
                    if (casterSkillList[i].SkillID == skillId)
                        casterSkillList[i].IsEquip = false;
                }
                break;
        }
    }

    /// <summary>
    /// 该技能被学会 
    /// </summary>
    /// <param name="playerId">角色id</param>
    /// <param name="skillId">技能id</param>
    public void SkillBeLearned(int playerId, int skillId)
    {
        switch (playerId)
        {
            case 0:
                for (int i = 0; i < saberSkillList.Count; i++)
                {
                    if (saberSkillList[i].SkillID == skillId)
                        saberSkillList[i].IsLearn = true;
                }
                break;
            case 1:
                for (int i = 0; i < archerSkillList.Count; i++)
                {
                    if (archerSkillList[i].SkillID == skillId)
                        archerSkillList[i].IsLearn = true;
                }
                break;
            case 2:
                for (int i = 0; i < casterSkillList.Count; i++)
                {
                    if (casterSkillList[i].SkillID == skillId)
                        casterSkillList[i].IsLearn = true;
                }
                break;
        }
    }

}
