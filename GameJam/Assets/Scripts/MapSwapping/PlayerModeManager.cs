using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerModeManager : MonoBehaviour
{
    public GameObject ghostInstance;
    public GameObject realInstance;
    [SerializeField] CinemachineVirtualCamera followCam;

    public AudioClip realWorld = null;
    public AudioClip ghostWorld = null;
    public AudioClip ghostWorldBackgroundSound = null;

    PlayerMovement realPlayerMovement;
    MeleeAttack realMeleeAttack;

    PlayerMovement ghostPlayerMovement;
    MeleeAttack ghostMeleeAttack;

    public MapSwap currentMap;

    private bool fromGhostToReal = false;

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

        currentMap = map;

        if (map == MapSwap.realWorld)
        {
            if(fromGhostToReal)
            {
                realInstance.GetComponent<Animator>().SetTrigger("PutHeart");
                fromGhostToReal = false;
            }
            ghostInstance.SetActive(false);
            realPlayerMovement.enabled = true;
            realMeleeAttack.gameObject.SetActive(true);

            followCam.Follow = realInstance.transform;
            //followCam.LookAt = realInstance.transform;

            AudioManagerController.instance.PlayMusicWithFade(realWorld);
            AudioManagerController.instance.StopBackgroundSounds();
        }
        else if (map == MapSwap.ghostWorld)
        {
            if(!fromGhostToReal)
            {
                realInstance.GetComponent<Animator>().SetTrigger("RipHeart");
                fromGhostToReal = true;
            }
            ghostInstance.SetActive(true);
            realPlayerMovement.enabled = false;
            realPlayerMovement.rb.velocity = Vector2.zero;
            realMeleeAttack.gameObject.SetActive(false);

            followCam.Follow = ghostInstance.transform;
            //followCam.LookAt = ghostInstance.transform;

            AudioManagerController.instance.PlayMusicWithFade(ghostWorld);
            AudioManagerController.instance.PlayBackgroundSounds(ghostWorldBackgroundSound);
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