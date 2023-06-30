using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCompleteVisual : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectsList;
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private GameObject plateCompleteVisual;
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateOnIngredientAdded;

        foreach (KitchenObjectSO_GameObject burger in kitchenObjectSOGameObjectsList)
        {
            burger.gameObject.SetActive(false);
        }
    }
    #endregion

    #region METHODS
    private void PlateOnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject burger in kitchenObjectSOGameObjectsList)
        {
            if (burger.kitchenObjectSO == e.kitchenObjectSO)
            {
                burger.gameObject.SetActive(true);
            }
        }
    }
    #endregion
}
