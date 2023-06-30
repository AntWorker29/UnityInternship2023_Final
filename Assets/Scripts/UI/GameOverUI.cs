using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private TextMeshProUGUI recipesDeliveredTextNumber;
    [SerializeField] private TextMeshProUGUI earningsNumber;
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
            earningsNumber.text = CashEarnedUI.Instance.GetTotalEarningsNumber().ToString();
            earningsNumber.text = "$ " + earningsNumber.text ;
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
