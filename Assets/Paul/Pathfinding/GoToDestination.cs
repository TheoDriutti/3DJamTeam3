using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDestination : MonoBehaviour
{
    //Script à mettre sur les ennemis (les objets qui vont sur le joueur)
    [Header("Ennemy stats")]
    [Range(0,10)]
    public float _speed;
    NavMeshAgent _agent;
    Vector3 _destination;
    [Header("Name of object to follow")]
    public string _goTo = "Player";

    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }
    void Update()
    {
        _destination = GameObject.Find(_goTo).transform.position;
        _agent.SetDestination(_destination);
    }
}
