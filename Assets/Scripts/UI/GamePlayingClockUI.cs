using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Image timerImage;
    #endregion

    #region SUBSCRIPTIONS
    private void Update()
    {
        timerImage.fillAmount = KitchenGameManager.Instance.GetGamePlayingTimerNormalized();
    }
    #endregion
}