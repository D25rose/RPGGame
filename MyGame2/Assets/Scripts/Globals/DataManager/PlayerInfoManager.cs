using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager {

    #region 单例
    private static PlayerInfoManager instance;

    public static PlayerInfoManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerInfoManager();
            }
            return instance;
        }
    }
    #endregion

    private List<PlayerItem> playerList;

    public List<PlayerItem> PlayerList { get { return playerList; } }

    private PlayerInfoManager() { }

    public void LoadPlayerInfoData()
    {
        playerList = GetPlayerItems();
    }

    private List<PlayerItem> GetPlayerItems()
    {
        return JsonTools.GetJsonList<PlayerItem>("PlayerInfoData");
    }
}
