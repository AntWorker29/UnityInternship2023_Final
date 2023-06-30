using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region FIELDS
    private const string PLAYER_PREFS_SOUND_EFFFECTS = "SoundEffects";
    [SerializeField] private AudioClipsListSO audioClipsListSO;
    [SerializeField] private StoveCounter stoveCounter;
    public static SoundManager Instance { get; private set; }
    private float volume = 1f;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFFECTS, 1f);
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += Trash_OnAnyObjectTrashed;
        PlayerBehavior.Instance.OnPickedSomething += Player_OnPickedSomething;
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }
    #endregion

    #region METHODS
    private void StoveCounter_OnStateChanged(object sender, System.EventArgs e)
    {
        StoveCounter stove = sender as StoveCounter;
        PlaySound(audioClipsListSO.stoveSizzle, stove.transform.position);
    }

    private void Trash_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trash = sender as TrashCounter;
        PlaySound(audioClipsListSO.trash, trash.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipsListSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsListSO.objectPickUp, PlayerBehavior.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipsListSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipsListSO.deliverySuccess, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipsListSO.deliveryFailed, deliveryCounter.transform.position);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    public void PlayFootstepSound(Vector3 position, float volume)
    {
        PlaySound(audioClipsListSO.footsteps, position, volume);
    }
    public void ChangeVolume(float changeAmount)
    {
        volume = changeAmount;
        if (changeAmount > 1)
        {
            Debug.Log("Change amount between 0 and 1");
        }
        if (volume > 1)
        {
            volume = 0;
        }
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFFECTS, volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;
    }
    #endregion
}
