using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoAreaView : MonoBehaviour {

    private string path = "UI/QuestPanel/"; 

    private GameObject prefab_RequiredItem;
    private GameObject prefab_RewardItem;

    private Text text_QuestName;
    private Text text_QuestDescr;
    private Transform requiredGrid;

    private Text text_RewardGold;
    private Transform rewardGrid;

    private Button giveUpBtn;

    public GameObject Prefab_RequiredItem { get { return prefab_RequiredItem; } }
    public GameObject Prefab_RewardItem { get { return prefab_RewardItem; } }

    public Text Text_QuestName { get { return text_QuestName; } }
    public Text Text_QuestDescr { get { return text_QuestDescr; } }
    public Transform RequiredGrid { get { return requiredGrid; } }

    public Text Text_RewardGold { get { return text_RewardGold; } }
    public Transform RewardGrid { get { return rewardGrid; } }

    public Button GiveUpBtn { get { return giveUpBtn; } }

    void Awake()
    {
        prefab_RequiredItem = Resources.Load<GameObject>(path + "RequiredItem");
        prefab_RewardItem = Resources.Load<GameObject>(path + "RewardItem");

        text_QuestName = transform.Find("QuestInfo/questName").GetComponent<Text>();
        text_QuestDescr = transform.Find("QuestInfo/questDescr").GetComponent<Text>();
        requiredGrid = transform.Find("QuestInfo/questRequiredGrid");

        text_RewardGold = transform.Find("QuestReward/rewardGold/Text").GetComponent<Text>();
        rewardGrid = transform.Find("QuestReward/rewardGrid");

        giveUpBtn = transform.Find("giveUpBtn").GetComponent<Button>();
    }

}
