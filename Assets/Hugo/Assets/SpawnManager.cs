﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _spawnerPetits;
    public GameObject[] _spawnerGros;
    public GameObject[] _spawnerOmbres;

    int _compteurSpawnerPetits, _compteurSpawnerGros, _compteurSpawnerOmbres;

    [HideInInspector] public int _nombreASpawnPetit, _nombreASpawnGros, _nombreASpawnOmbres; 

    void Awake()
    {
        _spawnerPetits = GameObject.FindGameObjectsWithTag("SpawnerPetits");
        _compteurSpawnerPetits = _spawnerPetits.Length;


        _spawnerGros = GameObject.FindGameObjectsWithTag("SpawnerGros");
        _compteurSpawnerGros = _spawnerGros.Length;


        _spawnerOmbres = GameObject.FindGameObjectsWithTag("SpawnerOmbres");
        _compteurSpawnerOmbres = _spawnerOmbres.Length;
    }

    public void AttribuerMobsParSpawner()
    {
        //petits

        for (int i = 0; i < _spawnerPetits.Length-1; i++)
        {
           int _randomPetit = Random.Range(0, _nombreASpawnPetit);
           _spawnerPetits[i].GetComponent<Spawner>()._numberToSpawn = _randomPetit;
           _nombreASpawnPetit -= _randomPetit;
            StartCoroutine(_spawnerPetits[i].GetComponent<Spawner>().SpawnMob());

        }

        _spawnerPetits[_spawnerPetits.Length-1].GetComponent<Spawner>()._numberToSpawn = _nombreASpawnPetit;
        StartCoroutine(_spawnerPetits[_spawnerPetits.Length - 1].GetComponent<Spawner>().SpawnMob());


        //gros

        for (int i = 0; i < _spawnerGros.Length - 1; i++)
        {
            int _randomGros = Random.Range(0, _nombreASpawnGros);
            _spawnerGros[i].GetComponent<Spawner>()._numberToSpawn = _randomGros;
            _nombreASpawnGros -= _randomGros;
            StartCoroutine(_spawnerGros[i].GetComponent<Spawner>().SpawnMob());

        }

        _spawnerGros[_spawnerGros.Length - 1].GetComponent<Spawner>()._numberToSpawn = _nombreASpawnGros;
        StartCoroutine(_spawnerGros[_spawnerGros.Length - 1].GetComponent<Spawner>().SpawnMob());


        //ombres

        for (int i = 0; i < _spawnerOmbres.Length - 1; i++)
        {
            int _randomOmbres = Random.Range(0, _nombreASpawnOmbres);
            _spawnerOmbres[i].GetComponent<Spawner>()._numberToSpawn = _randomOmbres;
            _nombreASpawnOmbres -= _randomOmbres;
            StartCoroutine(_spawnerOmbres[i].GetComponent<Spawner>().SpawnMob());


        }

        _spawnerOmbres[_spawnerOmbres.Length - 1].GetComponent<Spawner>()._numberToSpawn = _nombreASpawnOmbres;
        StartCoroutine(_spawnerOmbres[_spawnerOmbres.Length - 1].GetComponent<Spawner>().SpawnMob());
    }
}
