using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip music = null;

    // Start is called before the first frame update
    void Start()
    {
        AudioManagerController.instance.PlayMusicWithFade(music);
    }

}
