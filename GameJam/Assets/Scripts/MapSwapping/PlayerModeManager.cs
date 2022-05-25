﻿using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerModeManager : MonoBehaviour
{
    [SerializeField] GameObject ghostInstance;
    [SerializeField] GameObject realInstance;
    [SerializeField] CinemachineVirtualCamera followCam;

    PlayerMovement realPlayerMovement;
    MeleeAttack realMeleeAttack;

    PlayerMovement ghostPlayerMovement;
    MeleeAttack ghostMeleeAttack;
    void Awake()
    {
        SetComponents();
    }

    private void SetComponents()
    {
        realPlayerMovement = realInstance.GetComponent<PlayerMovement>();
        realMeleeAttack = realInstance.GetComponentInChildren<MeleeAttack>();

        ghostPlayerMovement = ghostInstance.GetComponent<PlayerMovement>();
        ghostMeleeAttack = ghostInstance.GetComponentInChildren<MeleeAttack>();
    }

    public void SetPlayerMode(MapSwap map)
    {
        ghostInstance.transform.position = realInstance.transform.position;

        if (map == MapSwap.realWorld)
        {
            ghostInstance.SetActive(false);
            realPlayerMovement.enabled = true;
            realMeleeAttack.gameObject.SetActive(true);

            followCam.Follow = realInstance.transform;
            followCam.LookAt = realInstance.transform;
        }
        else if (map == MapSwap.ghostWorld)
        {
            ghostInstance.SetActive(true);
            realPlayerMovement.enabled = false;
            realPlayerMovement.rb.velocity = Vector2.zero;
            realMeleeAttack.gameObject.SetActive(false);

            followCam.Follow = ghostInstance.transform;
            followCam.LookAt = ghostInstance.transform;
        }
    }

    public void EnablePlayers(bool status, MapSwap mapSwap)
    {
        if (mapSwap == MapSwap.realWorld)
        {
            realInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            realPlayerMovement.enabled = status;
            realMeleeAttack.enabled = status;
        }
        else if (mapSwap == MapSwap.ghostWorld)
        {
            ghostInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ghostPlayerMovement.enabled = status;
            ghostMeleeAttack.enabled = status;
        }
    }
}