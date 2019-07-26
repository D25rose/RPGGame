using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNumTootip : MonoBehaviour {

    //选择个数弹窗的确认按钮要执行的事件(比如购买或出售时事件不同，需要绑定)
    public static GlobalParamters.del_VoidInt eventChooseNumMethod;

    private int num = 1;
    private int singlePrice = 10;        //单个物品的价格(购买价格/出售价格)
    private int maxNum = 99;             //物品的最大选择数量

    public int Num
    {
        get { return num; }
        set { num = value;
            if( num > maxNum)
                num = maxNum;
            num_Text.text = num.ToString();
            price_Text.text = (num * singlePrice).ToString();   //改变数目时显示多个物品的价格
        }
    }

    public int SinglePrice
    {
        get { return singlePrice; }
        set { singlePrice = value;
        }
    }

    private Text num_Text;
    private Text price_Text;
    private Button left_Btn;
    private Button right_Btn;
    private Button confirm_Btn;
    private Button cancel_Btn;

    private GameObject mask;        //射线检测的遮挡

    void Awake()
    {
        num_Text = transform.Find("num").GetComponent<Text>();
        price_Text = transform.Find("Gold/Price").GetComponent<Text>();
        left_Btn = transform.Find("Left").GetComponent<Button>();
        right_Btn = transform.Find("Right").GetComponent<Button>();
        confirm_Btn = transform.Find("ConfirmBtn").GetComponent<Button>();
        cancel_Btn = transform.Find("CancelBtn").GetComponent<Button>();

        mask = transform.Find("Mask").gameObject;

        left_Btn.onClick.AddListener(OnLeftBtnClick);
        right_Btn.onClick.AddListener(OnRightBtnClick);
        confirm_Btn.onClick.AddListener(OnConfirmBtnClick);
        cancel_Btn.onClick.AddListener(() => { Hide(); });
    }

    private void OnLeftBtnClick()
    {
        Num--;
        if (Num < 1)
            Num = 1;
    }

    private void OnRightBtnClick()
    {
        Num++;
    }

    private void OnConfirmBtnClick()
    {
        eventChooseNumMethod(num);
        Hide();
    }

    /// <summary>
    /// 显示选择数目的弹窗
    /// </summary>
    public void ShowChooseNum( int singlePrice , int maxNum , Vector2 pos)
    {
        mask.SetActive(true);
        SinglePrice = singlePrice;
        Num = 1;
        this.maxNum = maxNum;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 隐藏选择数目的弹窗
    /// </summary>
    private void Hide()
    {
        transform.localPosition = new Vector3(-1090, 0, 0);
        mask.SetActive(false);
    }

}
