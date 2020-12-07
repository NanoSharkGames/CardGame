using UnityEngine;
using UnityEngine.UI;

public class WinState : CardGameState
{
    [SerializeField] Text _winTextUI = null;

    public override void Enter()
    {
        Debug.Log("Player Won!");
        _winTextUI.gameObject.SetActive(true);
        
        _winTextUI.text = "Player Won!";

        GameManager.gameManager.MatchWon();

        // Hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        Debug.Log("Player Win: Exiting...");

        // Unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        SaveSystem.SaveGameData(GameManager.gameManager);
        GameManager.gameManager.LoadNewScene(0);
    }
}
