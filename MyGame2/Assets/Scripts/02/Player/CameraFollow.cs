using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;
    public Transform m_PlayerTransform;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }



    void Update()
    {
        //Vector3 targetPos = new Vector3(0, 3.5f, -4.1f) + m_PlayerTransform.position;
        Vector3 targetPos = m_PlayerTransform.position - m_PlayerTransform.forward * 4 + new Vector3(0, 3.5f, 0);
        m_Transform.LookAt(m_PlayerTransform.position + new Vector3(0, 2, 0));
        m_Transform.position = Vector3.Lerp(m_Transform.position, targetPos, Time.deltaTime * 2);
    }
}
