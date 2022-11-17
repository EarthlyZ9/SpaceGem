using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        Destroy(GameObject.Find("PlayAudio"), 0.5f);
        Destroy(GameObject.Find("StartAudio"), 0.5f);
        SceneManager.LoadScene(0);
    }
}
