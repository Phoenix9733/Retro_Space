using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    private bool _gameOver;
    [SerializeField]
    private GameObject _pause;

    private void Update()
    {
        MainMenu();
    }

    void MainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _gameOver == true)
        {
            Menu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOver = true;
    }
}
