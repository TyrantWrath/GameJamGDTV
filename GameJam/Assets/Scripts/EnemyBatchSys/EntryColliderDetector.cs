using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryColliderDetector : MonoBehaviour
{
    [SerializeField] BatchHandler _batchHandler;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
            _batchHandler.PlayerCanMoveOn(false);
            _batchHandler.EnableEnemyScripts(true);
            gameObject.SetActive(false);
        }
    }
}
