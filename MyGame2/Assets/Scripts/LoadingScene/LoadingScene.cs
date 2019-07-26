using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    private AsyncOperation m_Async = null;

    private string targetScene = null;

    private float m_Progerss = 0;   //当前进度
    private int m_Cur = 0;  //实际进度

    private Slider m_Slider;    //进度条UI

	void Start () {

        targetScene = PlayerPrefs.GetString(Globals.PP_TargetScene);

        m_Slider = GameObject.Find("Canvas/Panel/Slider").GetComponent<Slider>();

        //异步加载场景
        m_Async = SceneManager.LoadSceneAsync(targetScene);

        //设置场景加载完毕后不能自动切换
        m_Async.allowSceneActivation = false;
	}
	
	
	void Update () {
        m_Cur = System.Convert.ToInt32(m_Async.progress * 100);

        if (m_Cur == 90)
        {
            m_Cur = 100;
        }

        if (m_Progerss == 100)
        {
            m_Async.allowSceneActivation = true;
        }
        else if(m_Progerss < m_Cur)
        {
            m_Progerss++;
            m_Slider.value = m_Progerss / 100;
        }
	}
}
