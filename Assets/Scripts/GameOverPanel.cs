using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    [HideInInspector]
    public GameManager menuManager;

    public void RestartGame()
    {
        menuManager.StartGame(dropdown.value);
        gameObject.SetActive(false);
    }

    public void OpenGameOverWindow()
    {
        gameObject.SetActive(true);
    }
}
