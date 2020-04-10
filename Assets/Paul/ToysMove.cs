using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToysMove : MonoBehaviour
{
    public bool _canRotate;
    bool _isIncreasing;
    float _distanceActuel;
    float _distance;
    float _speed;
    Rigidbody _rb;

    bool _canMove;

    void Start()
    {
        StartCoroutine(DeplacementOn());
        _distance = Random.Range(1, 5);
        _speed = Random.Range(1, 3);
        _rb = this.GetComponent<Rigidbody>();
        if (!_canRotate)
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void Update()
    {
        if (_canMove)
        {
            if (_isIncreasing)
                _distanceActuel += _speed / 100;
            else
                _distanceActuel -= _speed / 100;

            if (_distanceActuel >= _distance)
                _isIncreasing = false;
            else if (_distanceActuel <= -_distance)
                _isIncreasing = true;

            _rb.velocity = new Vector3(_distanceActuel, 0, _distanceActuel);
        }
    }

    IEnumerator DeplacementOn()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        _canMove = true;
        StartCoroutine(DeplacementOff());
    }
    IEnumerator DeplacementOff()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        _canMove = false;
        StartCoroutine(DeplacementOn());
    }
}