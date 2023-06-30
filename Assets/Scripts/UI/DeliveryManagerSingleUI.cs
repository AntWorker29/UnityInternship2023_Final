using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private TextMeshProUGUI recipeEarningsText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;
    [SerializeField] private Transform iconTemplateCoins;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    #endregion

    #region METHODS
    public void SetRecipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
        recipeEarningsText.text = "$ " + recipeSO.recipeCost.ToString();
        foreach (Transform child in iconContainer)
        {
            if (child != iconTemplate) Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            Transform iconTransform = Instantiate(iconTemplate, iconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
        }
    }
    #endregion
}
