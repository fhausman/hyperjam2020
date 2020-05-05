using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseScreen;

    private bool isPaused = false;

    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;

            if (pauseScreen)
            {
                pauseScreen.enabled = false;
            }

            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;

            if (pauseScreen)
            {
                pauseScreen.enabled = true;
            }

            isPaused = true;
        }
    }
}
