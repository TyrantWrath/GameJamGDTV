using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    Light2D _light = null;
    [SerializeField] float colorDuration = 1f;
    [SerializeField] Color _color1 = new Color(238, 104, 104);
    [SerializeField] Color _color2 = new Color(255, 211, 0);


    private void Start()
    {
        _light = GetComponent<Light2D>();
    }
    private void Update()
    {
        float t = Mathf.PingPong(Time.time, colorDuration) / colorDuration;
        _light.color = Color.Lerp(_color1, _color2, t);
    }
}
