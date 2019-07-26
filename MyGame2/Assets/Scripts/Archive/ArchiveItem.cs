using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存档信息实体类
/// </summary>
public class ArchiveItem  {

    private double posX;
    private double posY;
    private double posZ;
    private double rotX;
    private double rotY;
    private double rotZ;

    private int goldNum;

    public ArchiveItem() { }

    public double PosX
    {
        get
        {
            return posX;
        }

        set
        {
            posX = value;
        }
    }

    public double PosY
    {
        get
        {
            return posY;
        }

        set
        {
            posY = value;
        }
    }

    public double PosZ
    {
        get
        {
            return posZ;
        }

        set
        {
            posZ = value;
        }
    }

    public double RotX
    {
        get
        {
            return rotX;
        }

        set
        {
            rotX = value;
        }
    }

    public double RotY
    {
        get
        {
            return rotY;
        }

        set
        {
            rotY = value;
        }
    }

    public double RotZ
    {
        get
        {
            return rotZ;
        }

        set
        {
            rotZ = value;
        }
    }

    public int GoldNum
    {
        get
        {
            return goldNum;
        }

        set
        {
            goldNum = value;
        }
    }
}
