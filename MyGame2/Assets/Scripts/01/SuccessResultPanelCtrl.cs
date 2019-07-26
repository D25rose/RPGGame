using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuccessResultPanelCtrl : MonoBehaviour {

    private Text rewardText;
    private Button confirmBtn;

    void Awake()
    {
        rewardText = transform.Find("rewardText").GetComponent<Text>();
        confirmBtn = transform.Find("confirmBtn").GetComponent<Button>();

        confirmBtn.onClick.AddListener(OnConfirmBtn);
    }

    /// <summary>
    /// 显示奖励物品，同时向玩家发放奖励
    /// </summary>
    /// <param name="enemyId"></param>
    public void SetRewardItems(int enemyId)
    {
        EnemyItem enemyItem = EnemyManager.Instance().GetEnemyById(enemyId);

        string temp = "";
        temp += enemyItem.EnemyRewards.Gold + "\n";

        //发放金钱
        GlobalPlayerData.Instance.AddGoldInOtherScene(enemyItem.EnemyRewards.Gold);

        foreach(EnemyItem.RewardItem item in enemyItem.EnemyRewards.RewardItems)
        {
            string itemName = GlobalInventoryItemManager.Instance.GetItemNameById(item.ItemId);
            temp += itemName + " x" + item.ItemNum + "\n";

            //发放物品
            for(int i = 0; i < item.ItemNum; i++)
            {
                InventoryManager.Instance.AddItem(item.ItemId);
            }
        }
        rewardText.text = temp;
    }

    private void OnConfirmBtn()
    {
        PlayerPrefs.SetString(Globals.PP_TargetScene, "02");
        SceneManager.LoadScene("LoadingScene");
    }

}
