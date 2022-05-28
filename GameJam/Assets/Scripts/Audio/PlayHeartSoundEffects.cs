using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHeartSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip hitSFX = null;
    [SerializeField] private AudioClip heartMushSFX = null;

    public void PlayHitSfx()
    {
        AudioManagerController.instance.PlaySFX(hitSFX);
    }
  
    public void PlayHeartMushSfx()
    {
        AudioManagerController.instance.PlaySFX(heartMushSFX);
    }

}
