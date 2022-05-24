using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering;

public enum MapSwap
{
    ghostWorld,
    realWorld
}

public class ChangeMap : MonoBehaviour
{
    [SerializeField] MapSwap _mapSwap;
    SpriteRenderer _spriteRenderer;
    PlayerModeManager _playerModeManager;

    [SerializeField] private GameObject[] underWorldMapItems;
    [SerializeField] private int underWorldLayerNumber = 2;
    [SerializeField] private int normalWorldLayerNumber = 0;

    [Range(0, 5)]
    [SerializeField] private float timeBeforeMapSwap;
    [SerializeField] private float maxTime;

    [SerializeField] private GameObject underWorldPostProcessing;
    [SerializeField] private GameObject realWorldPostProcessing;
    [SerializeField] private GameObject transitionPostProcessing;

    private float timer;


    private void Start()
    {
        timer = maxTime;
        _playerModeManager = FindObjectOfType<PlayerModeManager>();

        _playerModeManager.SetPlayerMode(_mapSwap);
        SetWorld();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerModeManager.EnablePlayers(false, _mapSwap);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                DelayBeforeMapSwap();
                timer = maxTime;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            _playerModeManager.EnablePlayers(true, _mapSwap);
            timer = maxTime;
        }

    }
    private void DelayBeforeMapSwap()
    {
        ChangeWorld();
    }


    private void ChangeWorld()
    {
        if (_mapSwap == MapSwap.ghostWorld)
        {
            _mapSwap = MapSwap.realWorld;


            realWorldPostProcessing.SetActive(true);

        }
        else if (_mapSwap == MapSwap.realWorld)
        {
            _mapSwap = MapSwap.ghostWorld;
            underWorldPostProcessing.SetActive(true);
            realWorldPostProcessing.SetActive(false);
        }

        SetWorld();
    }

    private void SetWorld()
    {
        if (_mapSwap == MapSwap.realWorld)
        {
            for (int i = 0; i < underWorldMapItems.Length; i++)
            {
                if (underWorldMapItems[i].GetComponent<SpriteRenderer>())
                {
                    _spriteRenderer = underWorldMapItems[i].GetComponent<SpriteRenderer>();
                    _spriteRenderer.sortingOrder = normalWorldLayerNumber;
                }
                else
                {
                    underWorldMapItems[i].GetComponent<TilemapRenderer>().sortingOrder = normalWorldLayerNumber;
                }
            }

        }
        else if (_mapSwap == MapSwap.ghostWorld)
        {
            _mapSwap = MapSwap.ghostWorld;
            for (int i = 0; i < underWorldMapItems.Length; i++)
            {
                if (underWorldMapItems[i].GetComponent<SpriteRenderer>())
                {
                    _spriteRenderer = underWorldMapItems[i].GetComponent<SpriteRenderer>();
                    _spriteRenderer.sortingOrder = underWorldLayerNumber;
                }
                else
                {
                    underWorldMapItems[i].GetComponent<TilemapRenderer>().sortingOrder = underWorldLayerNumber;
                }
            }
        }
        _playerModeManager.SetPlayerMode(_mapSwap);
    }
}
