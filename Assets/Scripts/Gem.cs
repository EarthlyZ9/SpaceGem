using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Gem : MonoBehaviour, IPointerClickHandler
{
    public float speed;
    Vector3 trans;

    void Awake()
    {
        // Gem 초기 위치
        trans = transform.position;
    }


    void Update()
    {
        // 최솟값과 최대값 사이를 왔다갔다하며 y 축 position 을 조정해줌
        float y = Mathf.PingPong(Time.time * speed, 2) * 6 - 3;
        transform.position = new Vector3(trans.x, trans.y + y, trans.z);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭 시 유저 선택 화면으로 넘어
        SceneManager.LoadScene(1);
    }
}


