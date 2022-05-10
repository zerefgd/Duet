using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Animator _mainPanelAnimator, _levelPanelAnimator;

    [SerializeField]
    private GameObject _activeSoundButton;

    private void Awake()
    {
        Time.timeScale = 1f;

        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ? PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND) : 1) == 1;
        _activeSoundButton.SetActive(!sound);
    }

    public void OpenLevels()
    {
        _mainPanelAnimator.Play(Constants.AnimationNames.MAINMENU_MENUPANEL_LEFT,-1,0f);
        _levelPanelAnimator.Play(Constants.AnimationNames.MAINMENU_LEVELPANEL_LEFT, -1, 0f);
    }

    public void CloseLevels()
    {
        _mainPanelAnimator.Play(Constants.AnimationNames.MAINMENU_MENUPANEL_RIGHT, -1, 0f);
        _levelPanelAnimator.Play(Constants.AnimationNames.MAINMENU_LEVELPANEL_RIGHT, -1, 0f);
    }

    public void ToggleSound()
    {
        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ? PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND) : 1) == 1;
        sound = !sound;
        PlayerPrefs.SetInt(Constants.DATA.SETTINGS_SOUND, sound ? 1 : 0);
        _activeSoundButton.SetActive(!sound);
        AudioManager.instance.ToggleSound();
    }
}
