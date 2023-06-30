using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    #region FIELDS
    public static DeliveryCounter Instance { private set; get; }
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region METHODS
    public override void Interact(PlayerBehavior player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {   // Only destroys plates
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

                player.GetKitchenObject().DestroySelf();
            }
        }
    }
    #endregion
}
