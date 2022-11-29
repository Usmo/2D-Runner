using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public AudioManager audioManager;
    bool isPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        isPlaying = false;
    }

    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
        if (audioManager != null) audioManager.Play("background");
        panel.SetActive(false);
    }

    void Update()
    {
        if(!isPlaying && Input.GetButtonDown("Jump"))
        {
            StartGame();
        }
    }
}
