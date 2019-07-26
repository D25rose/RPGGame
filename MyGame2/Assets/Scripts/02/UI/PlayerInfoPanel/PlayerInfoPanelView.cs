using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanelView : MonoBehaviour {

    private Transform m_Transform;
    private Transform tabs_Transform;
    private Transform info_Transform;
    //private Transform skillArea_Transform;

    private GameObject prefab_PlayerInfoTabItem;
    //private GameObject prefab_PlayerInfoSkillItem;

    private Image role_Image;           //角色图片
    private Text hp_Text;
    private Text attack_Text;
    private Text defense_Text;
    private Text speed_Text;

    private Dictionary<string, Sprite> playerImageDic;          //角色图片字典


    public Transform M_Transform { get { return m_Transform; } }
    public Transform Tabs_Transform { get { return tabs_Transform; } }
    //public Transform SkillArea_Transform { get { return skillArea_Transform; } }

    public GameObject Prefab_PlayerInfoTabItem { get { return prefab_PlayerInfoTabItem; } }
    //public GameObject Prefab_PlayerInfoSkillItem { get { return prefab_PlayerInfoSkillItem; } }

    public Image Role_Image { get { return role_Image; } set { role_Image = value; } }
    public Text Hp_Text { get { return hp_Text; } set { hp_Text = value; } }
    public Text Attack_Text { get { return attack_Text; } set { attack_Text = value; } }
    public Text Defense_Text { get { return defense_Text; } set { defense_Text = value; } }
    public Text Speed_Text { get { return speed_Text; } set { speed_Text = value; } }

    void Awake()
    {
        //委托事件注册
        PlayerKernelDataProxy.eventUpdatePlayerInfo += UpdatePlayerInfoUI;

        m_Transform = gameObject.GetComponent<Transform>();
        tabs_Transform = m_Transform.Find("Top/Tabs").GetComponent<Transform>();
        info_Transform = m_Transform.Find("Bottom/PlayerInfo").GetComponent<Transform>();
        //skillArea_Transform = info_Transform.Find("SkillArea");

        role_Image = info_Transform.Find("RoleImage").GetComponent<Image>();
        hp_Text = info_Transform.Find("InfoArea/Hp/num").GetComponent<Text>();
        attack_Text = info_Transform.Find("InfoArea/Attack/num").GetComponent<Text>();
        defense_Text = info_Transform.Find("InfoArea/Defense/num").GetComponent<Text>();
        speed_Text = info_Transform.Find("InfoArea/Speed/num").GetComponent<Text>();

        prefab_PlayerInfoTabItem = Resources.Load<GameObject>("PlayerInfoTabItem");
        //prefab_PlayerInfoSkillItem = Resources.Load<GameObject>("PlayerInfoSkillItem");

        playerImageDic = new Dictionary<string, Sprite>();

        playerImageDic = ResourcesTools.LoadFolderSprites("PlayerTextures", playerImageDic);
    }


    /// <summary>
    /// 设置角色信息显示内容
    /// </summary>
    public void SetPlayerInfo(PlayerKernelDataProxy player)
    {
        Hp_Text.text = player.TotalHp.ToString();
        Attack_Text.text = player.TotalAttack.ToString();
        Defense_Text.text = player.TotalDefense.ToString();
        Speed_Text.text = player.TotalSpeed.ToString();
        Role_Image.sprite = GetPlayerImageByName(player.Image);
    }

    /// <summary>
    /// 通过图片名称获取角色图片
    /// </summary>
    public Sprite GetPlayerImageByName( string name )
    {
        return ResourcesTools.GetSpriteByName(name, playerImageDic);
    }

    private void UpdatePlayerInfoUI( string pName , int value )
    {
        switch (pName)
        {
            case "Hp":
                Hp_Text.text = value.ToString();
                break;
            //case "Mp":
            //    Hp_Text.text = value.ToString();
            //    break;
            case "Attack":
                Attack_Text.text = value.ToString();
                break;
            case "Defense":
                Defense_Text.text = value.ToString();
                break;
            case "Speed":
                Speed_Text.text = value.ToString();
                break;
        }
    }

    void OnDestroy()
    {
        PlayerKernelDataProxy.eventUpdatePlayerInfo -= UpdatePlayerInfoUI;
    }

}
