using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {

    private Transform m_Transform;
    private Animator m_Anim;
    private CharacterController m_CC;

    public float runSpeed = 1f;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Anim = gameObject.GetComponent<Animator>();
        m_CC = gameObject.GetComponent<CharacterController>();

        InitPos(ArchiveDataManager.Instance.ArchiveItem);
    }

    private void InitPos(ArchiveItem item)
    {
        m_Transform.position = new Vector3((float)item.PosX, (float)item.PosY, (float)item.PosZ);
        m_Transform.rotation = Quaternion.Euler((float)item.RotX, (float)item.RotY, (float)item.RotZ);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Vector3 dir = new Vector3(h, 0, v);

        if ( Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            m_Anim.SetBool("run", true);
            m_Transform.Rotate(Vector3.up , h*3);
            m_CC.SimpleMove(m_Transform.forward * v*runSpeed);
            //m_Transform.LookAt(m_Transform.position + dir);
        }
        else
        {
            m_Anim.SetBool("run", false);
        }
    }

    /// <summary>
    /// 碰到敌人，进入战斗场景
    /// </summary>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            //传递碰到的敌人的Id
            int enemyId = hit.gameObject.GetComponent<EnemyCtrl>().EnemyId;
            PlayerPrefs.SetInt(Globals.PP_BattleEnemyId, enemyId);

            PlayerPrefs.SetString(Globals.PP_TargetScene, "01");
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
