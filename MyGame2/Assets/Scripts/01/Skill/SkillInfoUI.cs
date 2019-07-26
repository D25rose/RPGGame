using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoUI : MonoBehaviour {

    private Text m_Text;

    void Awake()
    {
        m_Text = transform.Find("Text").GetComponent<Text>();
    }

    public void Init(string info)
    {
        m_Text.text = info;
    }
}
