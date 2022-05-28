using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisGameObject : MonoBehaviour
{

    private void Start() 
    {
        
    }

    public void DestroyThisGameObjectMethod()
    {
        Destroy(gameObject);
    }

    public void DestroyThisParentGameObjectMethod()
    {
        Destroy(transform.parent.gameObject);
    }

}
