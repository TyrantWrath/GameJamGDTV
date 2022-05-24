using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellow : MonoBehaviour
{
    [SerializeField] private Material _myMaterial;

    [SerializeField] private float twirlStrenght;
    [SerializeField] private float duration;
    [SerializeField] private float currentTwirlStrenght;
    bool timeToGoUp;

    private void Update()
    {
        duration -= Time.deltaTime * 5;
        if (!timeToGoUp)
        {
            if (duration <= 5)
            {
                timeToGoUp = true;
            }
        }
        else if (timeToGoUp)
        {
            duration += Time.deltaTime * 5;
            if (duration >= twirlStrenght)
            {
                timeToGoUp = false;
            }
        }



        _myMaterial.SetFloat("_Twirl_Strenght", duration);

    }

}
