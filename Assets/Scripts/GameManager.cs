using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public TMP_Text stageTotalItems;
    public TMP_Text acquiredItemsCount;
    public TMP_Text stageNumber;
    AudioSource playAudio;

    void Start()
    {
        playAudio = GameObject.FindGameObjectWithTag("PlayBgm").GetComponent<AudioSource>();
        stageTotalItems.text = "/ " + totalItemCount;
        stageNumber.text = "stage " + stage.ToString();
    }

    public void onGetItem(int count)
    {
        acquiredItemsCount.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (stage == 1)
            {
                Destroy(playAudio, 0.5f);
            }
            SceneManager.LoadScene("Stage_" + stage.ToString());
        }
    }
}
