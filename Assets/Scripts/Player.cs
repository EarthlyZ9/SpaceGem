using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rBody;
    bool isJumping;
    public int itemCount;
    public GameManager manager;
    AudioSource itemAudio;
    public float jumpPwr;
    
    void Awake()
    {
        // 점프 여부
        isJumping = false;

        // 오디오
        itemAudio = GetComponent<AudioSource>();

        // RigidBody 가지고 오기
        rBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // PlayerSelection 에서 저장해둔 material
        GetComponent<Renderer>().material = PlayerSelection.selectedMat;
    }

    void Update()
    {
        // 이중 점프 방지
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rBody.AddForce(new Vector3(0, jumpPwr, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

         //위로는 점프하므로 0
        rBody.AddForce(new Vector3(horizontal, 0, vertical), ForceMode.Impulse);
        //transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
    }

    // 이벤트 - 바닥과 닿으면 다시 점프할 수 있게 해줘야함
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // audio source 재생
            itemAudio.Play();

            // 아이템 사라지게 하기
            other.gameObject.SetActive(false);

            // 플레이어의 itemCount 변수 1 늘리기
            itemCount++;

            // Acquired Items Text UI
            manager.onGetItem(itemCount);
        }
    }
}
