using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _mobToSpawn;

    public int _numberToSpawn;

    bool _canSpawn;
    [HideInInspector] public bool _hasToWork;

    void Update()
    {
        if(_numberToSpawn >0)
        {
            if (_hasToWork)
            {
                StartCoroutine(SpawnMob());
                _hasToWork=false;
            }
        }
        if (_canSpawn)
        {
            Instantiate(_mobToSpawn, transform.position, Quaternion.identity);
            _canSpawn = false;
        }
    }

    IEnumerator SpawnMob()
    {
        yield return new WaitForSeconds(FindObjectOfType<WavesManager>()._numberOfWaves[FindObjectOfType<WavesManager>()._actualWave]._secondsBeforeSpawn);
        if(_numberToSpawn > 0)
        {
            _canSpawn= true;
            StartCoroutine(SpawnMob());
            _numberToSpawn--;
        }
    }
}
