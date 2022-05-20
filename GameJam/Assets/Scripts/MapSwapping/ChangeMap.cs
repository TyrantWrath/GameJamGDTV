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
    [SerializeField] private GameObject[] underWorldMapItems;
    [SerializeField] private int underWorldLayerNumber = 2;
    [SerializeField] private int normalWorldLayerNumber = 0;

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
                _mapSwap = MapSwap.realWorld;
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
        }
    }
}
