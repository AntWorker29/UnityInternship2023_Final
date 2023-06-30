using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour
{
    #region FIELDS
    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;
    private List<RecipeSO> waitingRecipeSOList;
    private float spawnedRecipeTime;
    private float spawnedRecipeTimeMax = 10f;
    private int waitingRecipesMax = 4;
    private int successfulDeliveredRecipesAmount;

    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;

        waitingRecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnedRecipeTime -= Time.deltaTime;
        if (spawnedRecipeTime <= 0f && waitingRecipeSOList.Count < waitingRecipesMax)
        {
            spawnedRecipeTime = spawnedRecipeTimeMax;

            RecipeSO nextRecipe = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
            waitingRecipeSOList.Add(nextRecipe);

            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion

    #region METHODS
    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            
            bool recipeOk = false;
            if (plateKitchenObject.GetKitchenObjectSOList().Count == waitingRecipeSO.kitchenObjectSOList.Count)
            {
                recipeOk = true;
                // If plate has same nr of elements as waiting recipe
                foreach (var ingredient in plateKitchenObject.GetKitchenObjectSOList())
                {
                    // verify if plate has same ingredient as recipe
                    if (!waitingRecipeSO.kitchenObjectSOList.Contains(ingredient))
                    {
                        recipeOk = false;
                    }
                }
            }
            if (recipeOk)
            {
                successfulDeliveredRecipesAmount++;
                waitingRecipeSOList.RemoveAt(i);

                OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                return;
            }
        }
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }
    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }
    public int GetSuccessfulRecipesAmount()
    {
        return successfulDeliveredRecipesAmount;
    }
    #endregion
}
