using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _points;
    [SerializeField]
    private Text _lose;
    [SerializeField]
    private Text _restart;
    [SerializeField]
    private Text _lives;
    [SerializeField]
    private Text _record;
    private int _recordSave;

    private GameManager _gameManager;
    



    void Start()
    {
        _points.text = "Points: " + 0;
        _recordSave = PlayerPrefs.GetInt("Record", 0);
        _record.text = "Record: " + _recordSave;
        _lives.text = "Lives: " + 1;
        _lose.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void UpdatePunti(int puntiPlayer)
    {
        _points.text = "Points: " + puntiPlayer.ToString();
    }

    public void UpdateRecord(int record)
    {
        if (record > _recordSave)
        {
            _recordSave = record;
            PlayerPrefs.SetInt("Record", _recordSave);
            _record.text = "Record: " + _recordSave.ToString();
        }
    }

    public void UpdateLives(int vitePlayer)
    {
        _lives.text = "Lives: " + vitePlayer.ToString();
    }

    public void Lose()
    {
        _lose.gameObject.SetActive(true);
        _restart.gameObject.SetActive(true);
        StartCoroutine(LoseRoutine());
        _gameManager.GameOver();
    }

    IEnumerator LoseRoutine()
    {
        while (true)
        {
            _lose.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _lose.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void Continue()
    {
        _gameManager.Resume();
    }

    public void MainMenu()
    {
        _gameManager.Menu();
    }

   
}
