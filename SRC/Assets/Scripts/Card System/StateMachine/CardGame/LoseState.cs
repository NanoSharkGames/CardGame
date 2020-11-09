using UnityEngine;
using UnityEngine.UI;

public class LoseState : CardGameState
{
    [SerializeField] Text _loseTextUI = null;

    public override void Enter()
    {
        Debug.Log("Player Lost...");
        _loseTextUI.gameObject.SetActive(true);

        _loseTextUI.text = "Player Lost...";
    }

    public override void Exit()
    {
        Debug.Log("Player Loss: Exiting...");
    }
}
