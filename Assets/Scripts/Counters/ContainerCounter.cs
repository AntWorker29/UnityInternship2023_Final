using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter
{
    #region FIELDS
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnPlayerGrabbedObject;
    #endregion

    #region METHODS
    public override void Interact(PlayerBehavior player)
    {
        if (player.HasKitchenObject()) return;
        KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}
