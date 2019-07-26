using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivePanelCtrl : MonoBehaviour {

    private Button confirmBtn;

    void Awake()
    {
        confirmBtn = transform.Find("ConfirmBtn").GetComponent<Button>();
        confirmBtn.onClick.AddListener(OnConfirmBtnClick);
    }

    private void OnConfirmBtnClick()
    {
        ArchiveManager.Instance.SaveGame();
        MainPanelCtrl.Instance.HideArchivePanel();
    }
}
