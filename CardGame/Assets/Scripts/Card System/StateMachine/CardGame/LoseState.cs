﻿using UnityEngine;
using UnityEngine.UI;

public class LoseState : CardGameState
{
    [SerializeField] Text _loseTextUI = null;

    public override void Enter()
    {
        Debug.Log("Player Lost...");
        _loseTextUI.gameObject.SetActive(true);

        _loseTextUI.text = "Player Lost...";

        GameManager.gameManager.MatchLost();

        // Hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        Debug.Log("Player Loss: Exiting...");

        // Unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        SaveSystem.SaveGameData(GameManager.gameManager);
        GameManager.gameManager.LoadNewScene(0);
    }
}