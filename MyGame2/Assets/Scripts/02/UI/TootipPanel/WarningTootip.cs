using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningTootip : MonoBehaviour {

    private Text m_Text;
    private Button m_Button;

	void Awake()
    {
        m_Text = transform.Find("content").GetComponent<Text>();
        m_Button = transform.Find("Button").GetComponent<Button>();

        m_Button.onClick.AddListener(() => transform.localPosition = new Vector3(1000 , 0 , 0));
    }

    public void Show( string content )
    {
        m_Text.text = content;
    }

}
