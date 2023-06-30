using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    #region FIELDS
    [SerializeField] private GameObject counterTop;
    private KitchenObject kitchenObject;
    public static event EventHandler OnAnyObjectPlacedHere;
    public static void ResetStaticData()
    {
        OnAnyObjectPlacedHere = null;
    }
    #endregion

    #region METHODS
    public virtual void Interact(PlayerBehavior player)
    {
        Debug.LogError("BaseCounter.Interact();");    
    }
    public virtual void InteractAlternate(PlayerBehavior player)
    {
        //Debug.LogError("BaseCounter.InteractAlternate();");    
    }

    public Transform GetKitchenObjectTransform()
    {
        return counterTop.transform;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if(kitchenObject!=null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    #endregion
}
