using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private float footstepTimerMax = 0.5f;
    [SerializeField] private float volume = 0.4f;
    private PlayerBehavior player;
    private float footstepTimer;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        player = GetComponent<PlayerBehavior>();
    }
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f && player.IsWalking())
        {
            footstepTimer = footstepTimerMax;
            SoundManager.Instance.PlayFootstepSound(player.transform.position, volume);
        }
    }
    #endregion
}
