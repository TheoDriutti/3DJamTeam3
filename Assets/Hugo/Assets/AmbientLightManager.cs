using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLightManager : MonoBehaviour
{
    public Color colorStart = Color.white;
    public Color colorEnd = Color.black;

    [Range(0f, 1f)]
    public float intensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.ambientLight = Color.Lerp(colorStart, colorEnd, intensity);
    }
}
