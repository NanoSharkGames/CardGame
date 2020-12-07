using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] Text matchesWonTxt;
    [SerializeField] Text matchesLostTxt;

    [SerializeField] AudioClip menuTrack;

    void Start()
    {
        AudioManager.audioInstance.PlaySong(menuTrack);

        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        matchesWonTxt.text = "Matches Won: " + GameManager.gameManager.matchesWon;
        matchesLostTxt.text = "Matches Lost: " + GameManager.gameManager.matchesLost;
    }

    public void ChangeScene(int sceneIndex)
    {
        GameManager.gameManager.LoadNewScene(sceneIndex);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.audioInstance.AdjustMusicVolume(volume);
    }

    public void SetSoundVolume(float volume)
    {
        AudioManager.audioInstance.AdjustSoundVolume(volume);
    }

    public void ClearSaveData()
    {
        GameManager.gameManager.ResetGameData();

        matchesWonTxt.text = "Matches Won: 0";
        matchesLostTxt.text = "Matches Lost: 0";
    }

    public void QuitGame()
    {
        GameManager.gameManager.QuitGame();
    }
}
