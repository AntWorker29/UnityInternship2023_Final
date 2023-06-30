using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region FIELDS
    private const string ANIMATION_TRIGGER = "IsWalking";
    private Animator _animator;
    [SerializeField] private PlayerBehavior _player;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.SetBool(ANIMATION_TRIGGER, _player.IsWalking());
    }
    #endregion
}
