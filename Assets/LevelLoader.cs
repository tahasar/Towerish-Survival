using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadNextLevel();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadPreviousLevel();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(0);
    }
    
}
