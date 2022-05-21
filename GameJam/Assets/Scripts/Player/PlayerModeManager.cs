using Cinemachine;
using System.Collections;
using UnityEngine;

 public class PlayerModeManager : MonoBehaviour
 {
    [SerializeField] GameObject ghostInstance;
    [SerializeField] GameObject realInstance;
    [SerializeField] CinemachineVirtualCamera followCam;

    PlayerMovement realPlayerMovement;
    void Start()
    {
        realPlayerMovement = realInstance.GetComponent<PlayerMovement>();
    }

    public void SetPlayerMode(MapSwap mapSwap)
    {
        ghostInstance.transform.position = realInstance.transform.position;

        if (mapSwap == MapSwap.realWorld)
        {
            ghostInstance.SetActive(false);
            realPlayerMovement.enabled = true;

            followCam.Follow = realInstance.transform;
        }
        else if(mapSwap == MapSwap.ghostWorld)
        {
            ghostInstance.SetActive(true);
            realPlayerMovement.enabled = false;

            followCam.Follow = ghostInstance.transform;
        }
    }
 }