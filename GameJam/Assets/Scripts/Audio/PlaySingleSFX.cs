using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySingleSFX : MonoBehaviour
{
    [SerializeField] private AudioClip clipSFX = null;
    public float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerController.instance.PlaySFX(clipSFX, volume);
    }

    
}
