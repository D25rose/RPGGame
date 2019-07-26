using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ArchiveManager  {

    #region   单例
    private static ArchiveManager instance;

    public static ArchiveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ArchiveManager();
            }
            return instance;
        }
    }
    #endregion

    string filePath = null;

    private ArchiveManager()
    {
        filePath = Application.dataPath + "/Resources/JsonData";
    }

    public void LoadGame()
    {
        ArchiveDataManager.Instance.LoadArchiveData();
        PlayerInfoManager.Instance.LoadPlayerInfoData();
        InventoryManager.Instance.LoadInventoryData();
        SkillManager.Instance.LoadSkillData();
        QuestManager.Instance.LoadQuestData();
    }

    public void SaveGame()
    {
        SavePlayerData();
        SavePlayerInfoData();
        SaveInventoryData();
        SaveSkillData();
        SaveQuestData();
    }

    /// <summary>
    /// 存储角色位置信息和金币数
    /// </summary>
    private void SavePlayerData()
    {
        ArchiveDataManager.Instance.SetArchiveItem();
        string fileData = JsonTools.TransromToJsonString(ArchiveDataManager.Instance.ArchiveItem);
        string fileName = "ArchiveData.txt";
        WriteFile(filePath, fileName, fileData);
    }

    /// <summary>
    /// 存储角色个人信息
    /// </summary>
    private void SavePlayerInfoData()
    {
        TeamManager.Instance.UpdateDataInPlayerItem();
        string fileData = JsonTools.TransromToJsonString(TeamManager.Instance.PlayerItemList);
        string fileName = "PlayerInfoData.txt";
        WriteFile(filePath, fileName, fileData);
    }

    /// <summary>
    /// 存储背包物品信息
    /// </summary>
    private void SaveInventoryData()
    {
        string fileData1 = JsonTools.TransromToJsonString(InventoryManager.Instance.EquipItemList);
        string fileName1 = "EquipItemData.txt";
        WriteFile(filePath, fileName1, fileData1);

        string fileData2 = JsonTools.TransromToJsonString(InventoryManager.Instance.PropItemList);
        string fileName2 = "PropItemData.txt";
        WriteFile(filePath, fileName2, fileData2);

        string fileData3 = JsonTools.TransromToJsonString(InventoryManager.Instance.ConsumeItemList);
        string fileName3 = "ConsumeItemData.txt";
        WriteFile(filePath, fileName3, fileData3);
    }

    /// <summary>
    /// 存储技能信息
    /// </summary>
    private void SaveSkillData()
    {
        string fileData1 = JsonTools.TransromToJsonString(SkillManager.Instance.SaberSkillList);
        string fileName1 = "SkillData0.txt";
        WriteFile(filePath, fileName1, fileData1);

        string fileData2 = JsonTools.TransromToJsonString(SkillManager.Instance.ArcherSkillList);
        string fileName2 = "SkillData1.txt";
        WriteFile(filePath, fileName2, fileData2);

        string fileData3 = JsonTools.TransromToJsonString(SkillManager.Instance.CasterSkillList);
        string fileName3 = "SkillData2.txt";
        WriteFile(filePath, fileName3, fileData3);
    }

    /// <summary>
    /// 存储任务信息
    /// </summary>
    private void SaveQuestData()
    {
        string fileData = JsonTools.TransromToJsonString(QuestManager.Instance.AllQuestList);
        string fileName = "QuestData.txt";
        WriteFile(filePath, fileName, fileData);
    }

    /// <summary>
    /// 把字符串数据写入文件存储
    /// </summary>
    private void WriteFile(string filePath, string fileName, string fileData)
    {
        FileStream fs = new FileStream(filePath + "//" + fileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);   //文件写入流
       
        sw.Write(fileData);
        sw.Close();//关闭流
        sw.Dispose();//销毁流
    }

}
