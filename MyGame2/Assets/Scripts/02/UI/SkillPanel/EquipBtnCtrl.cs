using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipBtnCtrl : MonoBehaviour {

    private Button m_Button;

    void Awake()
    {
        m_Button = gameObject.GetComponent<Button>();

        m_Button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SendMessageUpwards("OnEquipBtnClick");
    }

}
