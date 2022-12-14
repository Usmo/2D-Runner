using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject panel;
    public Player player;

    void Start()
    {
    }

    void Update()
    {
    }

    public void ShowDeathScreen()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void resetLevel()
    {
        ShowDeathScreen();
        player.resetLevel();
    }
}
