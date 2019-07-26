using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingCamera : MonoBehaviour {

    private bool reverFace = false;

    void Update()
    {
        //refCamera.transform.rotation * Vector3.forward就是对Vector3.forward施加rotation的旋转后得到的向量
        Vector3 targetPos = transform.position + Camera.main.transform.rotation * (reverFace ? Vector3.back : Vector3.forward);
        Vector3 targetOrientation = Camera.main.transform.rotation * Vector3.up;

        transform.LookAt(targetPos, targetOrientation);
    }
}
