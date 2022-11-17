using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Player player;
    private Collider playerCollider;
    public GameManager gameManager;
    AudioSource playAudio;

    void Awake()
    {
        // portal 과의 충돌을 감지하기 위해 player 의 collider 를 가지고 옴
        playerCollider = player.GetComponent<Collider>();
    }

    void Start()
    {
        playAudio = GameObject.FindGameObjectWithTag("PlayBgm").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // 포탈이 플레이어와 부딪혔을 때
        if (other = playerCollider)
        {
            if (gameManager.totalItemCount == player.itemCount)
            {
                // 스테이지의 총 아이템 수와 획득한 아이템 수가 같을 때 다음 스테이지로 넘어감
                switch (currentScene.name)
                {
                    case "Stage_1":
                        // Stage 가 넘어가도 배경음악이 꺼지지 않게 함
                        DontDestroyOnLoad(playAudio);
                        SceneManager.LoadScene("Stage_2");
                        break;
                    case "Stage_2":
                        SceneManager.LoadScene("Stage_3");
                        break;
                    default:
                        playAudio.Stop();
                        SceneManager.LoadScene("Complete");
                        break;
                }
            }
            else
            {
                // 획득한 아이템 수가 부족하다면 현재 scene 을 다시 로드
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
}


