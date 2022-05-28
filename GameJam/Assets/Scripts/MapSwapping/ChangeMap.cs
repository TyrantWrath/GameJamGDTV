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
    WorldSlowDown _worldSlowDown;

    EnemyModeManager[] _enemyModeManagers;

    [SerializeField] private GameObject[] underWorldMapItems;
    [SerializeField] private int underWorldLayerNumber = 2;
    [SerializeField] private int normalWorldLayerNumber = 0;

    [Range(0, 5)]
    [SerializeField] private float maxTime;

    [SerializeField] private GameObject underWorldPostProcessing;
    [SerializeField] private GameObject realWorldPostProcessing;
    [SerializeField] private GameObject transitionPostProcessing;
    [SerializeField] private Material _playerMaterial;
    [SerializeField] private Shader _ghostShader;
    [SerializeField] private Shader _dissolveShader;
    [SerializeField] private Shader _currentShaderInUse;


    private float dissolveAmount = 1;
    private bool isDissolving;

    private float timer;


    private void Start()
    {
        timer = maxTime;

        _worldSlowDown = GetComponent<WorldSlowDown>();
        _playerModeManager = FindObjectOfType<PlayerModeManager>();

        _playerModeManager.SetPlayerMode(_mapSwap);
        _worldSlowDown.UpdateWorldSpeed(_mapSwap);
        SetWorld();
        SetEnemyModes();
    }

    private void SetEnemyModes()
    {
        _enemyModeManagers = FindObjectsOfType<EnemyModeManager>();
        foreach (EnemyModeManager enemyModeManager in _enemyModeManagers)
        {
            enemyModeManager.SetEnemyMode(_mapSwap);
        }
    }

    private void Update()
    {
        DelayBeforeMapSwap();
        _currentShaderInUse = _playerMaterial.shader;
    }
    private void DelayBeforeMapSwap()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerMaterial.shader = _dissolveShader;
            _playerModeManager.EnablePlayers(false, _mapSwap);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            dissolveAmount = Mathf.Clamp01(timer);
            _playerMaterial.SetFloat("_DissolveAmount", dissolveAmount);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ChangeWorld();
                timer = maxTime;
            }
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            _playerModeManager.EnablePlayers(true, _mapSwap);
            _playerMaterial.SetFloat("_DissolveAmount", 1);
            _playerMaterial.shader = _ghostShader;
            timer = maxTime;
        }
    }

    private void ChangeWorld()
    {
        if (_mapSwap == MapSwap.ghostWorld)
        {
            _mapSwap = MapSwap.realWorld;

            realWorldPostProcessing.SetActive(true);
            underWorldPostProcessing.SetActive(false);

        }
        else if (_mapSwap == MapSwap.realWorld)
        {
            _mapSwap = MapSwap.ghostWorld;

            underWorldPostProcessing.SetActive(true);
            realWorldPostProcessing.SetActive(false);
        }

        _worldSlowDown.UpdateWorldSpeed(_mapSwap);
        SetWorld();
        SetEnemyModes();
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
