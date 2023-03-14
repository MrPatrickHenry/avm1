using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    bool inGameMenuButton = false;

    public void gameMenu(bool state)
    {
        inGameMenuButton = state;
    }

    private void Update()
    {
        if (inGameMenuButton)
        {
            PlayerManager.PauseGame();
        }
        if (!inGameMenuButton)

        {
            PlayerManager.ResumeGame();
        }
    }
}
