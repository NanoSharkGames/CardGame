using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] AudioClip battleMusic;

    int currentSceneIndex;

    [HideInInspector] public int matchesWon = 0;
    [HideInInspector] public int matchesLost = 0;

    void Awake()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        LoadGameData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void StartBattle()
    {
        if (battleMusic != null)
        {
            AudioManager.audioInstance.PlaySong(battleMusic);
        }
    }

    public void MatchWon()
    {
        matchesWon++;
    }

    public void MatchLost()
    {
        matchesLost++;
    }

    public void SaveGameData()
    {
        SaveSystem.SaveGameData(this);
    }

    public void LoadGameData()
    {
        GameData data = SaveSystem.LoadGameData();

        if (data != null)
        {
            matchesWon = data.matchesWon;
            matchesLost = data.matchesLost;
        }
    }

    public void ResetGameData()
    {
        string saveDataPath = Application.persistentDataPath + "/savedata.txt";

        if (File.Exists(saveDataPath))
        {
            File.Delete(saveDataPath);
        }

        matchesLost = 0;
        matchesWon = 0;
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNewScene(int sceneIndex)
    {
        currentSceneIndex = sceneIndex;

        LoadCurrentScene();
    }

    public void ReloadScene()
    {
        LoadCurrentScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
