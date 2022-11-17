using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAudio : MonoBehaviour, IPointerClickHandler
{
    AudioSource clickAudio;

    void Awake()
    {
        // 클릭하려는 Object 의 오디오 소스 불러옴
        clickAudio = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭 시 재생
        clickAudio.Play();
    }
}
