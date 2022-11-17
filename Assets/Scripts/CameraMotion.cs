using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    Transform playerTransform;
    Vector3 cameraOffset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // 모든 Update 함수가 다 실행되고 나서 그 다음에 수정
        transform.position = playerTransform.position + cameraOffset;
    }
}
