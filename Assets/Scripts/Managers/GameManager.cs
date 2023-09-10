using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StatsManager.Instance.SetStatValue("MaxHealth", 100);
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StatsManager.Instance.ResetStats();
        }
    }

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