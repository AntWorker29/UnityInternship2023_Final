using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoveCounterSound : MonoBehaviour
{
    #region FIELDS
    public static StoveCounterSound Instance { get; private set; }
    [SerializeField] private StoveCounter stoveCounter;
    private const string PLAYER_PREFS_STOVE_SIZZLE = "StoveSizzle";
    public AudioSource audioSource;
    private float volume = .2f;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_STOVE_SIZZLE, .2f);
        audioSource.volume = volume;
    }
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }
    #endregion

    #region METHODS
    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if(playSound)
        {
            audioSource.Play();
        } else
        {
            audioSource.Pause();
        }
    }
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
        PlayerPrefs.SetFloat(PLAYER_PREFS_STOVE_SIZZLE, volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;
    }
    #endregion
}
