using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellow : MonoBehaviour
{
    [SerializeField] private Material _myMaterial;

    [SerializeField] private float maxTwirlStrenght;
    [SerializeField] private Shader _ghostShader;
    [SerializeField] private float duration;
    [SerializeField] float currentmaxTwirlStrenght;
    SpriteRenderer _renderer;

    bool timeToGoUp;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        /*
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
            if (duration >= maxTwirlStrenght)
            {
                timeToGoUp = false;
            }
        }
*/

        currentmaxTwirlStrenght = Mathf.PingPong(Time.time * duration, maxTwirlStrenght);
        if (_myMaterial.shader == _ghostShader)
        {
            _myMaterial.SetFloat("_Twirl_Strenght", currentmaxTwirlStrenght);

        }



    }

}
