using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _mobToSpawn;

    [HideInInspector] public int _numberToSpawn;
    

    public IEnumerator SpawnMob()
    {
        yield return new WaitForSeconds(FindObjectOfType<WavesManager>()._numberOfWaves[FindObjectOfType<WavesManager>()._actualWave]._secondsBeforeSpawn);
        Instantiate(_mobToSpawn);
        if(_numberToSpawn > 0)
        {
            StartCoroutine(SpawnMob());
            _numberToSpawn--;
        }
    }
}
