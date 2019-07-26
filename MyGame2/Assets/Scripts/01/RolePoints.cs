using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePoints : MonoBehaviour {

    public static RolePoints Instance;

    public Transform[] enemyPoints;
    public Transform[] playerPoints;

    public Transform enemyParent;
    public Transform playerParent;

    void Awake()
    {
        Instance = this;
    }
}
