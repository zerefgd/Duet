using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;

    [SerializeField] private AudioClip _clickSound;

    private bool isSoundMuted;
    private bool IsSoundMuted
    {
        get
        {
            isSoundMuted = PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ?
                (PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND) == 0) : false;
            return isSoundMuted;
        }
        set
        {
            isSoundMuted = value;
            PlayerPrefs.SetInt(Constants.DATA.SETTINGS_SOUND, isSoundMuted ? 0 : 1);
        }
    } 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.SetInt(Constants.DATA.SETTINGS_SOUND, IsSoundMuted ? 0 : 1);
        _effectSource.mute = IsSoundMuted;
        _musicSource.mute = IsSoundMuted;
        _musicSource.Play();

        AddButtonSounds();
    }

    public void AddButtonSounds()
    {
        var buttons = FindObjectsOfType<Button>(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() =>
            {
                PlaySound(_clickSound);
            });
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void ToggleSound()
    {
        _musicSource.mute = IsSoundMuted;
        _effectSource.mute = IsSoundMuted;
    }
}