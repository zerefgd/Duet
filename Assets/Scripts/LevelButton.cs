using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private int level;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        PlayerPrefs.SetInt(Constants.DATA.CURRENT_LEVEL, level);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
