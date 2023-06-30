using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipsListSO : ScriptableObject
{
    public AudioClip[] footsteps;
    public AudioClip[] chop;
    public AudioClip[] trash;
    public AudioClip[] deliverySuccess;
    public AudioClip[] deliveryFailed;
    public AudioClip[] objectDrop;
    public AudioClip[] objectPickUp;
    public AudioClip[] warning;
    public AudioClip stoveSizzle;
}
