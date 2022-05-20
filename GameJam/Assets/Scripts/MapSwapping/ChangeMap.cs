using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapSwap
{
    ghostWorld,
    realWorld
}
public class ChangeMap : MonoBehaviour
{
    [SerializeField] MapSwap _mapSwap;
    SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject[] ghostGameObjects;

    private void Start()
    {

    }

    private void Update()
    {
        ChangeWorld();
    }

    private void ChangeWorld()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_mapSwap != MapSwap.ghostWorld)
            {
                _mapSwap = MapSwap.ghostWorld;
                for (int i = 0; i < ghostGameObjects.Length; i++)
                {
                    _spriteRenderer = ghostGameObjects[i].GetComponent<SpriteRenderer>();
                    _spriteRenderer.sortingOrder = 0;
                }

            }
            else if (_mapSwap == MapSwap.ghostWorld)
            {
                _mapSwap = MapSwap.realWorld;
                for (int i = 0; i < ghostGameObjects.Length; i++)
                {
                    ghostGameObjects[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
                }
            }
        }
    }
}
