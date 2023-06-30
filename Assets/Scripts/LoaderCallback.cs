using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    #region FIELDS
    private bool isFirstUpdate = true;
    #endregion

    #region SUBSCRIPTIONS
    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
    #endregion
}
