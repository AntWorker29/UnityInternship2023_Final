using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateKitchenObject : KitchenObject
{
    #region FIELDS
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    [SerializeField] private List<KitchenObjectSO> ingredientList;
    [SerializeField] private List<KitchenObjectSO> validIngredientList;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        ingredientList = new List<KitchenObjectSO>();
    }
    #endregion

    #region METHODS
    public bool TryAddIngredient(KitchenObjectSO ingredient)
    {
        if (!validIngredientList.Contains(ingredient)) return false;
        if (ingredientList.Contains(ingredient)) return false;
        ingredientList.Add(ingredient);
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenObjectSO = ingredient });
        return true;
    }
    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return ingredientList;
    }
    #endregion
}
