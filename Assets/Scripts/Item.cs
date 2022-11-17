using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotateSpeed = 15;

    void Update()
    {
        // 세로축 기준으로 돌리기
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
