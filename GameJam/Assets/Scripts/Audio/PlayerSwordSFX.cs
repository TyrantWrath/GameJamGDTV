using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] swordSwingSFX = null;

    private void SwingSFX()
    {
        int randomNumber = Random.Range(0, swordSwingSFX.Length);
        AudioManagerController.instance.PlaySFX(swordSwingSFX[randomNumber]);
    }


}
