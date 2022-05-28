using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisGameObject : MonoBehaviour
{


    public void DestroyThisGameObjectMethod()
    {
        Destroy(gameObject);
    }

    public void DestroyThisParentGameObjectMethod()
    {

        Destroy(transform.parent.gameObject, 0.1f);
    }

}
