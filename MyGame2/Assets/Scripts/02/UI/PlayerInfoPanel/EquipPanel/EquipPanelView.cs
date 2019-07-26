using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPanelView : MonoBehaviour {

    private EquipSlotCtrl[] equipSlotCtrls;           //六个装备槽的控制脚本

    public EquipSlotCtrl[] EquipSlotCtrls { get { return equipSlotCtrls; } }

    void Awake()
    {
        equipSlotCtrls = transform.GetComponentsInChildren<EquipSlotCtrl>();
    }

}
