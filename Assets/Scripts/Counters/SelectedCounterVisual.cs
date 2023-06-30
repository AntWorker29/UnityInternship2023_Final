using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private BaseCounter currentCounter;
    [SerializeField] private GameObject[] selectedVisualsArray;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        PlayerBehavior.Instance.OnSelectedCounterChanged += Player_SelectedCounterChanged;
    }
    #endregion

    #region METHODS
    private void Player_SelectedCounterChanged(object sender, PlayerBehavior.OnSelectedCounterChangedEventArgs e)
    {
        //selectedVisuals.SetActive(e.selectedCounter == currentCounter);
        if (e.selectedCounter == currentCounter)
        {
            foreach (GameObject selectedVisuals in selectedVisualsArray)
            {
                selectedVisuals.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject selectedVisuals in selectedVisualsArray)
            {
                selectedVisuals.SetActive(false);
            }
        }
    }
    #endregion
}
