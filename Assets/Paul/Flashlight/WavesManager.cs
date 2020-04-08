using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [Header("La size correspond au nombres de vagues")]
    public Wave[] _numberOfWaves;
    int _actualWave=-1;

    void Start()
    {
        NewWave();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NewWave();
        }
    }
    public void NewWave()
    {
        _actualWave++;
        if(_actualWave == _numberOfWaves.Length)
        {
            Debug.Log("Vous avez fini le jeu");
        }
        else
        {
            Debug.Log("Vague " + (_actualWave + 1));
            Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberPetitsMonstres + " petits monstres");
            Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberGrosMonstres + " gros monstres");
            Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberOmbresMonstres + " ombres");
        }
    }
}
