using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemCtrl : MonoBehaviour {

    private QuestItem m_QuestItem;

    public QuestItem QuestItem
    {
        get { return m_QuestItem; }
        set { m_QuestItem = value;
            text_QuestName.text = m_QuestItem.QuestName;
        }
    }

    private Text text_QuestName;
    private Button m_Button;

    void Awake()
    {
        text_QuestName = transform.Find("Text").GetComponent<Text>();
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }
	
    private void OnButtonClick()
    {
        SendMessageUpwards("SetQuestInfo", m_QuestItem);
    }

}
