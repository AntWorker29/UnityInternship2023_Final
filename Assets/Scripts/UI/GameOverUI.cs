using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private TextMeshProUGUI recipesDeliveredTextNumber;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }
    #endregion

    #region METHODS
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            recipesDeliveredTextNumber.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        } else
        {
            Hide();
        }
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
