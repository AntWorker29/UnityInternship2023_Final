using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashEarnedUI : MonoBehaviour
{
    #region FIELDS
    public static CashEarnedUI Instance { get; private set; }
    private  int totalEarningsNumber = 0;
    [SerializeField] private TextMeshProUGUI totalEarningsText;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
    }
    private void Update()
    {
        totalEarningsText.text = "$ " + totalEarningsNumber;
        KitchenGameManager.Instance.DisableTotalEarningsWindow();
    }
    #endregion

    #region METHODS
    private void DeliveryManager_OnRecipeSuccess(object sender, DeliveryManager.OnRecipeSuccessEventArgs e)
    {
        totalEarningsNumber += e.recipeSO.recipeCost;
    }
    public int GetTotalEarningsNumber()
    {
        return totalEarningsNumber;
    }
    #endregion
}
