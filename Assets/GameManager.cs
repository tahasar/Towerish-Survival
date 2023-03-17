using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public void PauseToggle()
    {
        if (GameIsPaused)
        {
            Resume();
            GameIsPaused = false;
        }
        else
        {
            Pause();
            GameIsPaused = true;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
