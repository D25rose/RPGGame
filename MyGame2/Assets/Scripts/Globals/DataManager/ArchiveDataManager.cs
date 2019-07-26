using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiveDataManager {

    #region 单例
    private static ArchiveDataManager instance;

    public static ArchiveDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ArchiveDataManager();
            }
            return instance;
        }
    }
    #endregion

    private ArchiveItem archiveItem;

    public ArchiveItem ArchiveItem { get { return archiveItem; } }

    private ArchiveDataManager() { }

    public void SetArchiveItem()
    {
        archiveItem.GoldNum = GlobalPlayerData.Instance.GoldNum;
        GameObject player = GameObject.Find("Player");
        archiveItem.PosX = player.transform.position.x;
        archiveItem.PosY = player.transform.position.y;
        archiveItem.PosZ = player.transform.position.z;
        archiveItem.RotX = player.transform.rotation.x;
        archiveItem.RotY = player.transform.rotation.y;
        archiveItem.RotZ = player.transform.rotation.z;
    }

    public void LoadArchiveData()
    {
        archiveItem = JsonTools.GetJsonObject<ArchiveItem>("ArchiveData");
        GlobalPlayerData.Instance.LoadGoldNumData(archiveItem.GoldNum);
    }
}
