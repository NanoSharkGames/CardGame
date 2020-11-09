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
    }

    public override void Exit()
    {
        Debug.Log("Player Win: Exiting...");
    }
}
