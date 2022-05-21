using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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


    private void Start()
    {
        _playerModeManager = FindObjectOfType<PlayerModeManager>();

        _playerModeManager.SetPlayerMode(_mapSwap);
        SetWorld();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayBeforeMapSwap());
        }
    }
    private IEnumerator DelayBeforeMapSwap()
    {
        _playerModeManager.EnablePlayers(false);
        yield return new WaitForSeconds(timeBeforeMapSwap);
        _playerModeManager.EnablePlayers(true);
        ChangeWorld();
    }


    private void ChangeWorld()
    {
        if (_mapSwap == MapSwap.ghostWorld)
        {
            _mapSwap = MapSwap.realWorld;
        }
        else if (_mapSwap == MapSwap.realWorld)
        {
            _mapSwap = MapSwap.ghostWorld;
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
