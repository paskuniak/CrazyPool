using System;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    private const int WarningTime = 5;
    private const int PowerupTime = 5;

    private bool timerRunning;
    private int timeRemaining;
    private float singleSecondTimer;
    private UIManager uiManager;
    private Action timeUpAction;

    public int TimeRemaining => timeRemaining;

    private void Update()
    {
        if (!timerRunning) return;

        singleSecondTimer += Time.deltaTime;
        if (singleSecondTimer > 1)
        {
            singleSecondTimer -= 1;
            UpdateUI();
            timeRemaining--;
            if (timeRemaining == WarningTime)
            {
                SFXPlayer.PlayClip(SFX.TimeAlmostUp);
            }
            else if (timeRemaining <= 0)
            {
                timeUpAction.Invoke();
            }
        }
    }
    
    private void UpdateUI()
    {
        uiManager.UpdateTime(timeRemaining);
    }

    internal void Init(UIManager ui, Action timeUp)
    {
        uiManager = ui;
        timeUpAction = timeUp;
    }

    internal void StartTimer()
    {
        timeRemaining = Config.GameTime;
        timerRunning = true;
        UpdateUI();
    }

    internal void CancelTimer()
    {
        timerRunning = false;
    }

    internal void AddTime()
    {
        timeRemaining += PowerupTime;
        UpdateUI();
    }
}
