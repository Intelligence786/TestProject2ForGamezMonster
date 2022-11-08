using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public WallSpawner wallSpawner;

    public GameOverPanel GameOverPanel;
    public MainMenuPanel MainMenuPanel;

    public Timer timer;
    public Attempt—ounter attempt—ounter;

    private void Start()
    {
        GameOverPanel.menuManager = this;
        MainMenuPanel.menuManager = this;
    }

    public void StartGame(int hardnessIndex)
    {
        levelManager.StartGame(hardnessIndex);
        levelManager.Ball.EndEvent = GameOver;
        timer.StartTimer();
    }

    public void GameOver(Ball ball)
    {
        timer.StopTimer();
        attempt—ounter.SetCounter();
        levelManager.started = false;
        Clear();
        GameOverPanel.OpenGameOverWindow();
    }

    public void Clear()
    {
        wallSpawner.Clear();
        levelManager.Clear();
    }
}
