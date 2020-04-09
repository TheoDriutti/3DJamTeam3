using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [Header("La size correspond au nombres de vagues")]
    public Wave[] _numberOfWaves;
    [HideInInspector] public int _actualWave=-1;

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
        if (_actualWave == _numberOfWaves.Length)
        {
            Debug.Log("Vous avez fini le jeu");
        }
        else
        {
            Debug.Log("Vague " + (_actualWave + 1));

            //Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberPetitsMonstres + " petits monstres");
            FindObjectOfType<SpawnManager>()._nombreASpawnPetit = _numberOfWaves[_actualWave]._numberPetitsMonstres;

            //Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberGrosMonstres + " gros monstres");
            FindObjectOfType<SpawnManager>()._nombreASpawnGros = _numberOfWaves[_actualWave]._numberGrosMonstres;


            //Debug.Log("Je fais spawn " + _numberOfWaves[_actualWave]._numberOmbresMonstres + " ombres");
            FindObjectOfType<SpawnManager>()._nombreASpawnOmbres = _numberOfWaves[_actualWave]._numberOmbresMonstres;



            FindObjectOfType<SpawnManager>().AttribuerMobsParSpawner();


        }
    }
}
