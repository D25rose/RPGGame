using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequiredItemCtrl : MonoBehaviour {

    private Text curNum;    //任务条件当前完成度
    private Text needNum;   //任务条件总要求
    private Text descr;     //任务描述

    void Awake()
    {
        curNum = transform.Find("number/curNum").GetComponent<Text>();
        needNum = transform.Find("number/needNum").GetComponent<Text>();
        descr = transform.Find("descr").GetComponent<Text>();
    }
	
    public void InitView( int curNum , int needNum , string descr )
    {
        this.curNum.text = curNum.ToString();
        this.needNum.text = needNum.ToString();
        this.descr.text = descr;
    }

}
