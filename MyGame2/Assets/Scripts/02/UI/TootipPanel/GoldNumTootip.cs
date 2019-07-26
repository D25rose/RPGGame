using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家拥有的金钱量的显示框（在显示商店，背包等面板时会一同显示）
/// </summary>
public class GoldNumTootip : MonoBehaviour {

    private int goldNum;        //金钱数

    public int GoldNum
    {
        get { return goldNum; }
        set { goldNum = value;
            num_Text.text = goldNum.ToString();
        }
    }

    private Text num_Text;

    void Awake()
    {
        num_Text = transform.Find("Image/Num").GetComponent<Text>();

        GoldNum = GlobalPlayerData.Instance.GoldNum;
        GlobalPlayerData.eventUpdateGoldNum += GlobalPlayerData_eventUpdateGoldNum;//委托事件注册，当玩家金钱数改变时，改变该显示框里的值

        num_Text.text = goldNum.ToString();
    }

    private void GlobalPlayerData_eventUpdateGoldNum(int num)
    {
        GoldNum = num;
    }

    public void ShowGoldNum( Vector3 pos )
    {
        transform.localPosition = pos;
    }

    void OnDestroy()
    {
        GlobalPlayerData.eventUpdateGoldNum -= GlobalPlayerData_eventUpdateGoldNum;
    }
}
