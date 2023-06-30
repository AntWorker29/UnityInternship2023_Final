using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;
    private IProgressBar hasProgress;
    #endregion

    #region SUBSCRIPTIONS
    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IProgressBar>();
        if(hasProgress == null)
        {
            Debug.LogError("GameObject" + hasProgressGameObject + "does not implement IProgressBar!");
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }
    #endregion

    #region METHODS
    private void HasProgress_OnProgressChanged(object sender, IProgressBar.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
