using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private StoveCounter stoveCounter;
    private AudioSource audioSource;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
    #endregion
}
