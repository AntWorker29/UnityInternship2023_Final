using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    #region FIELDS
    private const string CUT = "Cut";
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }
    #endregion

    #region METHODS
    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
    #endregion
}
