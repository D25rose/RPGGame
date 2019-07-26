using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class PlayerInfoPanelModel : MonoBehaviour {

    /// <summary>
    /// 获取角色数量
    /// </summary>
    public int GetPlayerNum()
    {
        return TeamManager.Instance.PlayerDic.Count;
    }

    public string GetPlayerNameByTabIndex(int i)
    {
        PlayerKernelDataProxy temp = null;
        TeamManager.Instance.PlayerDic.TryGetValue(i, out temp);
        return temp.Name;
    }

    public PlayerKernelDataProxy GetPlayerInfoByTabIndex(int i)
    {
        PlayerKernelDataProxy temp = null;
        TeamManager.Instance.PlayerDic.TryGetValue(i, out temp);
        return temp;
    }

    /*
    private Dictionary<int, SkillItem> skillItemDic;

    void Awake()
    {
        skillItemDic = GetAllSkillItems("SkillData");
    }

    /// <summary>
    /// 获取角色数量
    /// </summary>
    public int GetPlayerNum()
    {
        string jsonStr = Resources.Load<TextAsset>("JsonData/PlayerInfoData").text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        return jsonData.Count;
    }

	public string GetPlayerNameByTabIndex( int i )
    {
        string jsonStr = Resources.Load<TextAsset>("JsonData/PlayerInfoData").text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        return jsonData[i]["PlayerName"].ToString();
    }

    public PlayerInfoItem GetPlayerInfoByTabIndex( int i )
    {
        string jsonStr = Resources.Load<TextAsset>("JsonData/PlayerInfoData").text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        int playerID = int.Parse(jsonData[i]["PlayerID"].ToString());
        string playerName = jsonData[i]["PlayerName"].ToString();
        float hp = float.Parse(jsonData[i]["Hp"].ToString());
        float attack = float.Parse(jsonData[i]["Attack"].ToString()); 
        float defense = float.Parse(jsonData[i]["Defense"].ToString());
        float speed = float.Parse(jsonData[i]["Speed"].ToString());
        string[] skill = jsonData[i]["Skill"].ToString().Split(',');
        string image = jsonData[i]["Image"].ToString();
        PlayerInfoItem item = new PlayerInfoItem(playerID, playerName, hp , attack, defense, speed, skill , image);
        return item;
    }


    /// <summary>
    /// 通过技能id获取技能信息
    /// </summary>
    public SkillItem GetSkillItemByID(int id)
    {
        SkillItem item = null;
        skillItemDic.TryGetValue(id, out item);
        return item;
    }

    /// <summary>
    /// 从Json文件中加载所有技能信息，存储在字典中
    /// </summary>
    private Dictionary<int, SkillItem> GetAllSkillItems( string fileName )
    {
        Dictionary<int, SkillItem> tempDic = new Dictionary<int, SkillItem>();

        string jsonStr = Resources.Load<TextAsset>("JsonData/SkillData" ).text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        for( int i = 0; i < jsonData.Count; i++)
        {
            int id = int.Parse(jsonData[i]["SkillID"].ToString());
            SkillItem temp = JsonMapper.ToObject<SkillItem>(jsonData[i].ToJson());
            tempDic.Add(id, temp);
        }
        return tempDic;
    }
    */
}
