using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    #region FIELDS
    public static event EventHandler OnAnyObjectTrashed;
    new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;
    }
    #endregion

    #region METHODS
    public override void Interact(PlayerBehavior player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();

            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion
}
