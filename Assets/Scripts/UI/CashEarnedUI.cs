using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashEarnedUI : MonoBehaviour
{
    #region FIELDS
    private  int totalEarningsNumber = 0;
    [SerializeField] private TextMeshProUGUI totalEarningsText;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        
    }
    private void Update()
    {
        totalEarningsText.text = "$ " + totalEarningsNumber;
    }
    #endregion
}
