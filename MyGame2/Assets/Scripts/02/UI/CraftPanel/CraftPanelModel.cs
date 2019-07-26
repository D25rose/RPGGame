using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPanelModel : MonoBehaviour {

    [SerializeField]
    private int[] equipItemList;            //可合成的装备的id的集合
    [SerializeField]
    private int[] consumeItemList;          //可合成的药品的id的集合

    public int[] EquipItemList { get { return equipItemList; } }
    public int[] ConsumeItemList { get { return consumeItemList; } }

    public int[] GetItemListByTabIndex( int index )
    {
        if (index == 0)
        {
            return equipItemList;
        }
        else
        {
            return consumeItemList;
        }
    }

}
