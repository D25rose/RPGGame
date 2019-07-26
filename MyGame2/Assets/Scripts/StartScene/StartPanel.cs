using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

    private Button continueGameBtn;

    void Awake()
    {
        continueGameBtn = transform.Find("ContinueGameBtn").GetComponent<Button>();
        continueGameBtn.onClick.AddListener(OnContinueGameBtnClick);
    }

    private void OnContinueGameBtnClick()
    {
        ArchiveManager.Instance.LoadGame();
        PlayerPrefs.SetString(Globals.PP_TargetScene, "02");
        SceneManager.LoadScene("LoadingScene");
    }

}
