using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyDownActivate : MonoBehaviour
{
    private DestroyThisGameObject destroyThisGameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        destroyThisGameObject = GetComponent<DestroyThisGameObject>();

        destroyThisGameObject.enabled = false;
       
    }

    public void TurnOnComponents()
    {
        Debug.Log("Turned On");
        destroyThisGameObject.enabled = true;
        this.gameObject.AddComponent<Health>();
    }
}
