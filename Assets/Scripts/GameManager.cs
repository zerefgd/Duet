using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject _pauseButton, _pausePanel;

    [SerializeField]
    private List<GameObject> _levels;

    [SerializeField]
    private TMP_Text _startMessage;

    [SerializeField]
    private AudioClip _explosionClip, _coinClip;

    private bool isGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isGameOver = false;
        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;

        int level = PlayerPrefs.GetInt(Constants.DATA.CURRENT_LEVEL);
        if (level == Constants.DATA.START_MESSAGES.Count + 1) level = 1;
        _startMessage.text = Constants.DATA.START_MESSAGES[level - 1];
        Instantiate(_levels[level - 1], Vector3.up * 15f, Quaternion.identity);
        AudioManager.instance.AddButtonSounds();
    }

    public void GameOver()
    {
        isGameOver = true;
        AudioManager.instance.PlaySound(_explosionClip);
        GamePause();
    }

    public void GameWin()
    {
        AudioManager.instance.PlaySound(_coinClip);
        int level = PlayerPrefs.GetInt(Constants.DATA.CURRENT_LEVEL) + 1;
        PlayerPrefs.SetInt(Constants.DATA.CURRENT_LEVEL, level);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void GamePause()
    {
        _pauseButton.SetActive(false);
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameUnPause()
    {
        if(isGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            return;
        }

        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
