using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Player _player = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn " + _playerTurnCount.ToString();

        // Hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;

        _player.BeginTurn();
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        Debug.Log("Player Turn: Exiting...");

        // Unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnCardGameState>();
    }
}
