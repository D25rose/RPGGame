using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParamters {

    /// <summary>
    /// 更新角色信息面板UI的委托
    /// </summary>
    /// <param name="key">要更新的UI的属性名称</param>
    /// <param name="value">更新后的值</param>
    public delegate void del_UpdatePlayerInfoUI(string key , int value);

    /// <summary>
    /// void类型单int参数的委托类型
    /// </summary>
    public delegate void del_VoidInt( int value );

    /// <summary>
    /// void类型无参数的委托类型
    /// </summary>
    public delegate void del_Void();
}
