using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerSelection : MonoBehaviour, IPointerClickHandler
{
    AudioSource startAudio;
    public static Material selectedMat;

    void Start()
    {
        // 유저 선택 완료 시 재생되는 오디오를 정지시키기 위해 StartAudio 를 불러옴
        startAudio = GameObject.FindGameObjectWithTag("StartBgm").GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 object 의 이름에 따라 selectedMat 클래스 변수에 각 material 을 저장해둠 
        switch (this.gameObject.name)
        {
            case "red":
                Debug.Log("clicked Red");
                Material red = Resources.Load<Material>("Materials/PlayerRed");
                selectedMat = red;
                break;
            case "green":
                Debug.Log("clicked Green");
                Material green = Resources.Load<Material>("Materials/PlayerGreen");
                selectedMat = green;
                break;
            case "blue":
                Debug.Log("clicked Blue");
                Material blue = Resources.Load<Material>("Materials/PlayerBlue");
                selectedMat = blue;
                break;
            default:
                break;

        }

        // 재생되는 오디오를 정지시키고 다음 씬 (stage 1) 을 불러옴
        startAudio.Stop();
        SceneManager.LoadScene(2);
    }
}
