using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoveCounterVisual : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesOnGameObject;
    [SerializeField] private GameObject warningImage;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnWarning += ShowWarning;
    }
    #endregion

    #region METHODS
    private void ShowWarning(object sender, EventArgs e)
    {
        warningImage.SetActive(true);
    }
    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particlesOnGameObject.SetActive(showVisual);
        if (e.state != StoveCounter.State.Fried)
        {
            warningImage.SetActive(false);
        }
    }
    #endregion
}
