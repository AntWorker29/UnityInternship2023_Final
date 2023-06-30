using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region FIELDS
    private const string PLAYER_PREFS_MUSIC = "MusicVolume";
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;
    private float volume = .3f;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC, .3f);
        audioSource.volume = volume;
    }
    #endregion

    #region METHODS
    public void ChangeVolume(float changeAmount)
    {
        volume = changeAmount;
        if (changeAmount > 1)
        {
            Debug.Log("Change amount between 0 and 1");
        }
        if (volume > 1)
        {
            volume = 0;
        }
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC, volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;
    }
    #endregion
}
