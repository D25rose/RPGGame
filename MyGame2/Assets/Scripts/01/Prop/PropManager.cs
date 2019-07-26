using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager  {

    #region 单例
    private static PropManager instance;
    
    public static PropManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PropManager();
            }
            return instance;
        }
    }
    #endregion

    private PropManager() { }

	public void UseProp(int propId, GameObject targetRole)
    {
        switch (propId)
        {
            case 21:
                UseProp21(targetRole);
                break;
            case 22:
                UseProp22(targetRole);
                break;
        }
        //该角色使用完道具后，该角色操作结束，切换到下一个角色
        BattleManager.Instance.UpdateUnActPlayers();
    }

    /// <summary>
    /// 使用道具21
    /// </summary>
    private void UseProp21(GameObject targetRole)
    {
        int hp = GlobalInventoryItemManager.Instance.GetItemById(21).RecoverHp;
        targetRole.GetComponent<RoleBase>().TakeDamage(-hp);
    }

    /// <summary>
    /// 使用道具22
    /// </summary>
    private void UseProp22(GameObject targetRole)
    {
        int mp = GlobalInventoryItemManager.Instance.GetItemById(22).RecoverMp;
        targetRole.GetComponent<RoleBase>().TakeDamage(mp);
    }
}
