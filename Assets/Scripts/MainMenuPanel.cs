using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    [HideInInspector]
    public GameManager menuManager;

    public void StartGame()
    {
        menuManager.StartGame(dropdown.value);
        gameObject.SetActive(false);
    }
}
